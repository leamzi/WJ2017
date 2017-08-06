using UnityEngine;

// Gonza

public class BulletEnemy : MonoBehaviour {

    public float speed = 20.0f;
	int damage = 5;

    private void Start()
    {
       
    
    }

	public void Update()
	{
		//destroy if out of bounds
		if (transform.position.z <= -18) {
			Destroy (gameObject);
		}

		Move ();

	}

	public void Move(){
		transform.Translate (Vector3.back * Time.deltaTime * speed);
	}

}
