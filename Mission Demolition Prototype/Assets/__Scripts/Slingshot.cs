using System.Collections;
using UnityEngine;

public class Slingshot : MonoBehaviour {
	static private Slingshot S;
	//fields set in the Unity Inspector Pane
	[Header("Set in Inspector")]
	public GameObject prefabProjectile;
	public float velocityMult = 8f;

	//fields set dynamically
	[Header("Set Dynamically")]
	private bool aimingMode;
	private bool shotFiredRecently = false;
	private GameObject jumping;
	private GameObject launchPoint;
	private GameObject projectile;
	private GameObject standing;
	private GameObject throwing;
	private Rigidbody projectileRigidbody;
	private Vector3 launchPos;

	static public Vector3 LAUNCH_POS
	{
		get
		{
			if (S == null) return Vector3.zero;
			return S.launchPos;
		}
	}

	void Awake()
	{
		S = this;
		standing = GameObject.Find("MarioStanding");
		throwing = GameObject.Find("MarioThrowing");
		jumping = GameObject.Find("MarioJumping");
		throwing.SetActive(false);
		jumping.SetActive(false);
		Transform launchPointTrans = transform.Find("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive(false);
		launchPos = launchPointTrans.position;
	}

	void Update()
	{
		// If Slinghsot is not in aimingMode, don't run this code
		if (!aimingMode) return;

		//Get the current mouse position in 2d screen coordinates
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

		//Find the delta from the launchPos to the mousePos3d
		Vector3 mouseDelta = mousePos3D - launchPos;

		//Limit mouseDelta to the radius of the Slingshot SphereCollider
		float maxMagnitude = this.GetComponent<BoxCollider>().size.x;
		if (mouseDelta.magnitude > maxMagnitude)
		{
			mouseDelta.Normalize();
			mouseDelta *= maxMagnitude;
		}

		//Move the projectile to this new position
		Vector3 projPos = launchPos + mouseDelta;
		if (projectile != null)
			projectile.transform.position = projPos;

		if (Input.GetMouseButtonUp(0))
		{
			throwing.SetActive(false);
			jumping.SetActive(true);
			Invoke("ShouldBeStanding", 1f);
			//The mouse has been released
			aimingMode = false;
			projectileRigidbody.isKinematic = false;
			projectileRigidbody.velocity = -mouseDelta * velocityMult;
			FollowCam.POI = projectile;
			projectile = null;
			MissionDemolition.ShotFired();
			//ShowProjectilesLeft.GetClosestBall(true);
			ProjectileLine.S.poi = projectile;
			shotFiredRecently = true;
			Invoke("ShotCanBeFired", 3f);
		}
	}

	void ShotCanBeFired()
	{
		shotFiredRecently = false;
	}

	void ShouldBeStanding()
	{
		standing.SetActive(true);
		jumping.SetActive(false);
	}
	void OnMouseEnter()
	{
		//print("Slingshot:OnMouseEnter()");
		launchPoint.SetActive(true);
	}

	void OnMouseExit()
	{
		//print("Slingshot:OnMouseExit()");
		launchPoint.SetActive(false);
	}

	void OnMouseDown()
	{
		if (shotFiredRecently) return;
		//The player has pressed the mouse button while over Slingshot
		throwing.SetActive(true);
		standing.SetActive(false);
		aimingMode = true;
		//Instantiate a projectile
		GameObject prefabToUse = ShowProjectilesLeft.GetClosestPrefab();
		if (prefabToUse == null)
		{
			// Do something to trigger end game
		}
		else {
			projectile = Instantiate(prefabToUse) as GameObject;
			projectile.tag = "Projectile";
			//Start it at the launchPoint
			projectile.transform.position = launchPos;
			//Set it to isKinematic for now
			projectileRigidbody = projectile.GetComponent<Rigidbody>();
			projectileRigidbody.isKinematic = true;
			ShowProjectilesLeft.GetClosestBall(true);
		}

	}

}
