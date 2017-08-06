using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float moveSpeed= 5.0f;
	public int enemyType = 0;
	int health=5;

	public Transform bulletEnemyObj;

	[SerializeField] private float fireRate;
	private float nextFire;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		checkForFire ();
		Move ();
	}
		
	void Move(){
		//destroy if out of screen
		if (transform.position.z <= -18) {
			Destroy (gameObject);
		}

		//speed * Time.deltaTime

		switch (enemyType) {

		//derecho
		case 0:	transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);

			break;

		case 1: 
			
			break;
		case 2:
			
			break;
		case 3:
			
			break;
		default: 
			break;

		}
			
	}

	private void checkForFire()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			FireBullet(transform.position );
		}
	}

	void FireBullet(Vector3 myPos)
	{
		Instantiate (bulletEnemyObj, myPos , bulletEnemyObj.rotation);
	}

}
