using System.Collections;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble = 0;

    private Rigidbody objectRigidBody;

	// Use this for initialization
	void Start () {
        objectRigidBody = this.GetComponent<Rigidbody>();
        objectRigidBody.angularVelocity = Random.insideUnitSphere * tumble;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
