using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Class that manage power ups
/// </summary>
public class PowerupManager : MonoBehaviour {

    public GameGlobalVariables.PowerupType powerupType;
    public FastPool powerupPool;

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            activatePowerup();
        }
    }

    public void dispose()
    {
        powerupPool.FastDestroy(this);
    }

    private void activatePowerup()
    {
        SoundManager.instance.PlaySfx(GameGlobalVariables.SFX_GAMEPLAY_POWERUP);
        switch (powerupType)
        {
            case GameGlobalVariables.PowerupType.POWERUP_WEAPON:
                PlayerManager.controllerFire.OnPowerup();
                break;
            case GameGlobalVariables.PowerupType.POWERUP_SHIELD:
                break;
            case GameGlobalVariables.PowerupType.POWERUP_SPECIAL_ATTACK:
                break;
            default:
                break;
        }
    }
}
