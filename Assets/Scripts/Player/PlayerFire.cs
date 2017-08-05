using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage Player Fire
/// </summary>
public class PlayerFire : MonoBehaviour {

    [SerializeField] private float fireRate;

    [HideInInspector] public FastPool bulletPool;
    private List<GameObject> bullets;
    private float nextFire;

    // Use this for initialization
    void Start () {
        setBulletPool();
    }

    // Update is called once per frame
    void Update () {
        fireBullet();
    }

    #region PlayerFire
    private void setBulletPool()
    {
        bullets = new List<GameObject>();
        bulletPool = FastPoolManager.GetPool(1, null, false);
    }

    private void fireBullet()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //print("Bullet Pos: " + PlayerManager.Instance.fireMp);
            bullets.Add(bulletPool.FastInstantiate(PlayerManager.Instance.fireMp));
        }
    }

    public void destroyBullet()
    {
        PlayerManager.controllerFire.bulletPool.FastDestroy(bullets[0]);
    }

    #endregion
}
