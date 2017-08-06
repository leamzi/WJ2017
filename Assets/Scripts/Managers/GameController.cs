using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Class that manage the gameplay events
/// </summary>
public class GameController : SingletonMonoBehaviour<GameController>
{
    public GameObject powerupSpawnPoint;
    public GameObject powerupWeapon;
    private FastPool powerupWeaponPool;
    //public float puStartWait = 10.0f;
    public float puStartWait = 1f;
    //public float puSpawnWait = 20.0f;
    public float puSpawnWait = 3f;

	// Use this for initialization
	protected override void Start () {
        base.Start();

        powerupWeaponPool = FastPoolManager.GetPool(GameGlobalVariables.gamePowerupType.powerupWeaponID, null, false);
        SoundManager.instance.PlayBgm(GameGlobalVariables.BGM_GAMEPLAY);

        StartCoroutine(spawnPowerupWeapon());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawnPowerupWeapon()
    {
        yield return new WaitForSeconds(puStartWait);
        while (true)
        {
            Vector3 spawnValues = new Vector3(8.8f, 0f, 0f);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0f, 25f);

            powerupSpawnPoint.transform.position = spawnPosition;

            powerupWeaponPool.FastInstantiate(powerupSpawnPoint.transform);
            //print("instantiate powerup");
            yield return new WaitForSeconds(puSpawnWait);
        }
    }
}
