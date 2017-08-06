using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnExitBondaries : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bullet")
        {
            other.GetComponent<Bullet>().dispose();
        }
        
        if (other.tag == "Powerup")
        {
            other.GetComponent<PowerupManager>().dispose();
        }
    }
}
