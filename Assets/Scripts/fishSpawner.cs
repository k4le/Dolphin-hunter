using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishSpawner : MonoBehaviour
{
	public int fishAmount;
	public int rangeX;
	public int rangeY;
	public GameObject[] fishPrefab;


	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < fishAmount; i++) {
			Instantiate(fishPrefab[Random.Range(0, fishPrefab.Length - 1)], new Vector3(UnityEngine.Random.Range(0, rangeX), UnityEngine.Random.Range(0, -rangeY), 0), transform.rotation);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
