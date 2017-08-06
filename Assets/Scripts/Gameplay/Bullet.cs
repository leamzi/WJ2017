using UnityEngine;
using System.Collections;
/// <summary>
/// Autor: Leamzi
/// Script that moves object
/// </summary>
public class Bullet : MonoBehaviour {

    [SerializeField] private float speed = 0f;

    private Rigidbody objectRigidBody;

    public int damage = 1;
    
    private void Start()
    {
        objectRigidBody = this.GetComponent<Rigidbody>();
        moveForward();
    }

    private void moveForward()
    {
        objectRigidBody.velocity = transform.forward * speed;
        StartCoroutine(disposeInSeconds());
    }

    public void dispose()
    {
        this.transform.rotation = Quaternion.identity;
        PlayerManager.controllerFire.bulletPool.FastDestroy(this);
    }

    IEnumerator disposeInSeconds()
    {
        yield return new WaitForSeconds(5);
        print("Disposing");
        dispose();
    }
}
