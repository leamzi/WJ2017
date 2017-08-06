using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float moveSpeed= 5.0f;
	public int enemyType = 0;
	public bool canFire;

    public GameObject enemyModel;
    public GameObject explosionVFX;

    public GameObject life01;
    public GameObject life02;

    //int health = 5;

    public Transform bulletEnemyObj;

	[SerializeField] private float fireRate;
	private float nextFire;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            print("Me pego bala");
            PlayerManager.Instance.playerAddScore(10);
            enemyModel.SetActive(false);
            StartCoroutine(destroyAnim());
            other.GetComponent<Bullet>().dispose();
        }

        if (other.tag == "Player")
        {
            if (PlayerManager.healthManager.invulnerable)
                return;

            print("le pego a player");
            PlayerManager.healthManager.playerDamage();
            PlayerManager.Instance.removePlayerLife();
        }
    }

    IEnumerator destroyAnim()
    {
        explosionVFX.SetActive(true);
        SoundManager.instance.PlaySfx(GameGlobalVariables.SFX_ENEMY_DEATH);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
