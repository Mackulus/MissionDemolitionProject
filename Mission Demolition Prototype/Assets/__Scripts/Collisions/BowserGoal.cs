using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BowserGoal : MonoBehaviour {

    //A static field accessible by code anywhere
    //static public bool goalMet = false;
    
    private Image[] icons;
    private int collisionCount = 0;
    private JumpingBowser js;

    void Start()
    {
        Invoke("getIcons", 0.1f);
        js = GetComponent<JumpingBowser>();
    }

    void OnCollisionEnter(Collision other)
    {
        collisionCount++;
        //When the trigger is hit by something
        //Check to see if it's a projectile
        if (!IsInvoking("RemoveBowser"))
        {
            if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "CanHurtEnemy")
            {
                bowserDeath();
            }
            else if (collisionCount >= 7 && js == null)
            {
                bowserDeath();
            }
        }
    }

    public void bowserDeath()
    {
        GameObject.Find("Icons").GetComponent<UI_IconDisplay>().UpdateIconDisplay();
        MissionDemolition.PointsGained(10);
        Invoke("RemoveBowser", 1.5f);
        if (isGameOver())
            Goal.goalMet = true;
    }

	private void getIcons()
	{
		icons = GameObject.Find("Icons").GetComponent<UI_IconDisplay>().GetImages();
	}

	private void RemoveBowser()
	{
		gameObject.SetActive(false);
	}

	private bool isGameOver()
	{
		bool result = true;
		foreach (Image icon in icons)
		{
			if (icon.sprite.name == "bowser_icon2")
				result = false;
		}
		return result;
	}
}