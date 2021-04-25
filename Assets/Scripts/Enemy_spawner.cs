using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
	public int distanceBetweenSpawnpoints;
	public int rangeX;
	public int rangeY;
	public GameObject enemyPrefab;


	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < (int)rangeX/distanceBetweenSpawnpoints; i++)
		{
			GameObject fish = Instantiate(enemyPrefab, new Vector3(i*distanceBetweenSpawnpoints, UnityEngine.Random.Range(0, -rangeY) - 5, 0), transform.rotation);
			float scaling = Mathf.Abs(fish.transform.position.y) / rangeY;
			fish.transform.localScale *= (1 + scaling);
		}
	}
}
