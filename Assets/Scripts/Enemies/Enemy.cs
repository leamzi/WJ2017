using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float moveSpeed= 5.0f;
	public int enemyType = 0;
	public bool canFire;

    //int health = 5;

	public Transform bulletEnemyObj;

	[SerializeField] private float fireRate;
	private float nextFire;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (canFire) {
			checkForFire ();
		}

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
		case 0:	transform.Translate (Vector3.down * Time.deltaTime * moveSpeed);
				break;

		case 1: transform.Translate (Vector3.down * Time.deltaTime * moveSpeed);
				break;
		
		//si aun no bajo, seguir bajando al boss,
		case 2:
			if (transform.position.z > 27) {
				transform.Translate (Vector3.down * Time.deltaTime * moveSpeed);
			}
	

			//si baja a pos.Z 27 o menos, mover de costado
			if (transform.position.z <= 27) {
				transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
			}

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
		myPos.z -= 3;



		//Instantiate (bulletEnemyObj, myPos, bulletEnemyObj.rotation);

		//GameObject bullet = Instantiate(bulletTrailPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;

		//Instantiate (, this.transform.position, this.transform.rotation);


	}

}
