using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleGeneration : MonoBehaviour {

	public GameObject prefabCastle1;
	public GameObject prefabCastle2;
	public GameObject prefabCastle3;
	public GameObject flagPrefab;
	public Vector3 castlePosition;
	public Vector3 flagPosition;

	private GameObject castle;
	private GameObject flag;
	void Start () {
		PlaceCastle();
		PlaceFlag();
	}

	private void PlaceCastle()
	{
		if (castle != null)
		{
			Destroy(castle);
		}

		int random = Random.Range(1,4);
		if (random == 1)
			castle = Instantiate(prefabCastle1);
		else if (random == 2)
			castle = Instantiate(prefabCastle2);
		else if (random == 3)
			castle = Instantiate(prefabCastle3);
		castle.transform.position = castlePosition;
	}

	private void PlaceFlag()
	{
		if (flag != null)
		{
			Destroy(flag);
		}
		flag = Instantiate(flagPrefab);
		flag.transform.position = flagPosition;
	}
}
