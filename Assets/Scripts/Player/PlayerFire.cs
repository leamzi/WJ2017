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
    public GameObject muzzle_fork;
    public GameObject muzzle_knife01;
    public GameObject muzzle_knife02;
    public GameObject muzzle_cutter01;
    public GameObject muzzle_cutter02;
    public GameObject muzzle_cutter03;

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
        if (bullets == null)
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
        muzzle_fork.SetActive(false);
        muzzle_knife01.SetActive(false);
        muzzle_knife02.SetActive(false);

        muzzle_cutter01.SetActive(false);
        muzzle_cutter02.SetActive(false);
        muzzle_cutter03.SetActive(false);

        switch (GameGlobalVariables.Instance.currentBulletType)
        {
            case GameGlobalVariables.PlayerBulletType.BULLET_FORK:
                muzzle_fork.SetActive(true);
                bullets.Add(bulletPool.FastInstantiate(PlayerManager.Instance.bulletForkMP));
                SoundManager.instance.PlaySfx(GameGlobalVariables.SFX_PLAYER_BLAST_FORK);
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_KNIFE:
                muzzle_knife01.SetActive(true);
                muzzle_knife02.SetActive(true);
                bullets.Add(bulletPool.FastInstantiate(PlayerManager.Instance.bulletKnifeMP01));
                bullets.Add(bulletPool.FastInstantiate(PlayerManager.Instance.bulletKnifeMP02));
                SoundManager.instance.PlaySfx(GameGlobalVariables.SFX_PLAYER_BLAST_KNIFE);
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_CUTTER:
                muzzle_cutter01.SetActive(true);
                muzzle_cutter02.SetActive(true);
                muzzle_cutter03.SetActive(true);
                bullets.Add(bulletPool.FastInstantiate(PlayerManager.Instance.bulletCutterMP01));
                bullets.Add(bulletPool.FastInstantiate(PlayerManager.Instance.bulletCutterMP02));
                bullets.Add(bulletPool.FastInstantiate(PlayerManager.Instance.bulletCutterMP03));
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_MIXER:
                break;
        }
        //print("play sfx");
        
    }

    public void OnPowerup()
    {
        if (GameGlobalVariables.Instance.currentBulletType == GameGlobalVariables.PlayerBulletType.BULLET_CUTTER)
            return;

        playerFrLvl++;
        //print("Player gun level: " + playerFrLvl);

        if (playerFrLvl > 2)
        {
            //print("Changing arm");
            changeBulletTypes(GameGlobalVariables.PlayerBulletType.BULLET_KNIFE);
            fireRate = 0.75f;
            playerFrLvl = 0;
        }
        else
        {
            //print("Upgrading fire rate");
            fireRate = fireRate - 0.20f;
        }
    }

    private void changeBulletTypes(GameGlobalVariables.PlayerBulletType _bulletType)
    {
        switch (GameGlobalVariables.Instance.currentBulletType)
        {
            case GameGlobalVariables.PlayerBulletType.BULLET_FORK:
                GameGlobalVariables.Instance.currentBulletType = GameGlobalVariables.PlayerBulletType.BULLET_KNIFE;
                fireRate = 0.75f;
                PlayerManager.Instance.onChangeTexture(Color.yellow);
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_KNIFE:
                GameGlobalVariables.Instance.currentBulletType = GameGlobalVariables.PlayerBulletType.BULLET_CUTTER;
                fireRate = 0.4f;
                PlayerManager.Instance.onChangeTexture(Color.green);
                break;
            case GameGlobalVariables.PlayerBulletType.BULLET_CUTTER:
                break;
        }

        setBulletPool();
    }
    #endregion
}
