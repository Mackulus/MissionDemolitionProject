using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleGeneration : MonoBehaviour {

	public GameObject prefabCastle1;
	public GameObject prefabCastle2;
	public GameObject prefabCastle3;
	public Vector3 castlePosition;

	private GameObject castle;
	void Start () {
		PlaceCastle();
	}

	private void PlaceCastle()
	{
		int random = Random.Range(1, 3);
		if (random == 1)
			castle = Instantiate(prefabCastle1);
		else if (random == 2)
			castle = Instantiate(prefabCastle2);
		else if (random == 3)
			castle = Instantiate(prefabCastle3);
		castle.transform.position = castlePosition;
	}
}
