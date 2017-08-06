using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Class that manage power ups
/// </summary>
public class PowerupManager : MonoBehaviour {

    private GameGlobalVariables.PowerupType type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.controllerFire.OnPowerup();
            dispose();
        }
    }

    private void dispose()
    {
        this.gameObject.SetActive(false);
    }
}
