using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Script that moves object
/// </summary>
public class Bullet : MonoBehaviour {

    [SerializeField] private float speed = 0f;

    private Rigidbody objectRigidBody;
    
    private void Start()
    {
        objectRigidBody = this.GetComponent<Rigidbody>();
        moveForward();
    }

    private void moveForward()
    {
        objectRigidBody.velocity = transform.forward * speed;
    }

    public void dispose()
    {
        PlayerManager.controllerFire.bulletPool.FastDestroy(this);
    }
}
