using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Define screen boundaries units
/// </summary>
[System.Serializable]
public class Boundary 
{
    public float xMin, xMax, zMin, zMax;
}

/// <summary>
/// Manage Player movement
/// </summary>
public class PlayerMovement : MonoBehaviour {

    [Header("Player Settings")]

    [SerializeField] private float      playerSpeed = 15f;
    [SerializeField] private float      shipTilt = 0f;
    private float       moveHorizontal = 0f;
    private float       moveVertical = 0f;
    private Rigidbody   playerRigidBody;
    public bool canMove = true;
    [Header("Game Settings")]
    public Boundary         boundary;
    

    #region Monobehaviour Methods
    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Move();
    }

    #endregion

    #region PlayerMovement
    /// <summary>
    /// Move players position
    /// </summary>
    private void Move()
    {
        if (!canMove)
            return;
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        playerRigidBody.velocity = movement * playerSpeed;

        checkWorldBoundaries();
        playerShipTilt();
    }

    /// <summary>
    /// Check if player leaves the game boundaries
    /// </summary>
    private void checkWorldBoundaries()
    {
        playerRigidBody.position = new Vector3(
            Mathf.Clamp(playerRigidBody.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(playerRigidBody.position.z, boundary.zMin, boundary.zMax)
            );
    }

    /// <summary>
    /// Tilt the player ship when is moving left or right
    /// </summary>
    private void playerShipTilt()
    {
        playerRigidBody.rotation = Quaternion.Euler(
            0f,
            0f,
            (playerRigidBody.velocity.x * -shipTilt)
            );
    }
    #endregion

    
}
