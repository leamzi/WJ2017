using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonMonoBehaviour<PlayerManager> {

    public static PlayerMovement controllerMovement;
    public static PlayerFire controllerFire;

    public Transform bulletForkMP;
    public Transform bulletKnifeMP01;
    public Transform bulletKnifeMP02;

    protected override void Start() {
        base.Start();

        controllerMovement = GetComponent<PlayerMovement>();
        controllerFire = GetComponent<PlayerFire>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
