using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage Player Fire
/// </summary>
public class PlayerFire : MonoBehaviour {

    [HideInInspector] public FastPool bulletPool;

    public int playerFrLvl; //Player fire rate level
    public int playerWpLvl; //Player weapon level

    [SerializeField] private float fireRate;
    private List<GameObject> bullets;
    private float nextFire;

    // Use this for initialization
    void Start () {
        setBulletPool();
    }

    // Update is called once per frame
    void Update () {
        checkForFire();
    }

    #region PlayerFire
    private void setBulletPool()
    {
        if(bullets == null)
            bullets = new List<GameObject>();

        switch (GameGlobalVariables.Instance.currentBulletType)
        {
            case GameGlobalVariables.PlayerBulletType.BULLET_FORK:
            bulletPool = FastPoolManager.GetPool(GameGlobalVariables.bulletType.bulletForkID, null, false);
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_KNIFE:
            bulletPool = FastPoolManager.GetPool(GameGlobalVariables.bulletType.bulletKnifeID, null, false);
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_MIXER:
            bulletPool = FastPoolManager.GetPool(GameGlobalVariables.bulletType.bulletMixerID, null, false);
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_CUTTER:
            bulletPool = FastPoolManager.GetPool(GameGlobalVariables.bulletType.bulletCutterID, null, false);
                break;
        }
        //print("Setting Bullet pool: " + GameGlobalVariables.Instance.currentBulletType.ToString());
    }

    private void checkForFire()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fireBulletType();
        }
    }

    public void destroyBullet()
    {
        PlayerManager.controllerFire.bulletPool.FastDestroy(bullets[0]);
    }

    private void fireBulletType()
    {
        //print("Firing Bullet: " + GameGlobalVariables.Instance.currentBulletType.ToString());
        switch (GameGlobalVariables.Instance.currentBulletType)
        {
            case GameGlobalVariables.PlayerBulletType.BULLET_FORK:
                bullets.Add(bulletPool.FastInstantiate(PlayerManager.Instance.bulletForkMP));
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_KNIFE:
                bullets.Add(bulletPool.FastInstantiate(PlayerManager.Instance.bulletKnifeMP01));
                bullets.Add(bulletPool.FastInstantiate(PlayerManager.Instance.bulletKnifeMP02));
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_MIXER:
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_CUTTER:
                break;
        }
        //print("play sfx");
        SoundManager.instance.PlaySfx(GameGlobalVariables.SFX_PLAYER_BLAST_01);
    }

    public void OnPowerup()
    {
        playerFrLvl++;
        print("Player gun level: " + playerFrLvl);

        if (playerFrLvl > 2)
        {
            print("Changing arm");
            changeBulletTypes(GameGlobalVariables.PlayerBulletType.BULLET_KNIFE);
            fireRate = 0.75f;
        }
        else
        {
            print("Upgrading fire rate");
            fireRate = fireRate - 0.20f;
        }
    }

    private void changeBulletTypes(GameGlobalVariables.PlayerBulletType _bulletType)
    {
        GameGlobalVariables.Instance.currentBulletType = _bulletType;
        setBulletPool();
    }
    #endregion
}
