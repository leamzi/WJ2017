using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Gonza 

public class EnemyManager : SingletonMonoBehaviour<EnemyManager>  {


	//public Transform enemyShipObj; // prefab nave enemigo

	public Transform[] enemyTypes = new Transform[2];

	public int enemiesPerWave;
	public int numWaves;
	public int currentWave=1;
	public float spawnWaveWait;
	public float spawnWait;
	public float startWait;

	//public List<enemyShip> enemyList = new List<enemyShip>();

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();

		StartCoroutine ( SpawnWave() );
	}
	
	// Update is called once per frame
	 void Update () 
	{

		//debug
		if (Input.GetKeyUp (KeyCode.Q)) {
		
			SpawnWave ();
		}

			
	}

	IEnumerator SpawnWave()
	{
		yield return new WaitForSeconds (startWait);

		for (currentWave=1; currentWave <= numWaves; currentWave++)
		{
			for (int i = 0; i < enemiesPerWave; i++)
			{
				// x -8 a 8
				SpawnEnemy ( 0, new Vector3 ( Random.Range(-8,8),0,26) ); 
				//enemyList.Add ();

				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (spawnWaveWait);
		}
	}
		

	void SpawnEnemy(int myType, Vector3 myPos)	
	{

		Instantiate (enemyTypes[myType], myPos, enemyTypes[myType].rotation);

	}

}
