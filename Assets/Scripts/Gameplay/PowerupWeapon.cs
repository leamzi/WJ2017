using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Class that manage powerup type weapon
/// </summary>
public class PowerupWeapon : PowerupManager {


    // Use this for initialization
    void Start () {
        powerupType = GameGlobalVariables.PowerupType.POWERUP_WEAPON;
        powerupPool = FastPoolManager.GetPool(GameGlobalVariables.gamePowerupType.powerupWeaponID, null, false);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.tag == "Player")
        {
            powerupPool.FastDestroy(this);
        }
    }
}
