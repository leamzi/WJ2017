using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Class that manage the player instance in gameplay
/// </summary>
public class PlayerManager : SingletonMonoBehaviour<PlayerManager> {

    public static PlayerMovement controllerMovement;
    public static PlayerFire controllerFire;
    public static PlayerHealth healthManager;

    public Transform bulletForkMP;
    public Transform bulletKnifeMP01;
    public Transform bulletKnifeMP02;
    public Transform bulletCutterMP01;
    public Transform bulletCutterMP02;
    public Transform bulletCutterMP03;
    public Transform playerInitialPos;

    public delegate void OnPlayerScore(int newScore);
    public event OnPlayerScore notifyPlayerScoreObservers;

    public delegate void OnGameOver();
    public event OnGameOver notifyGameOver;

    private int playerScore;

    public List<MeshRenderer> shipTextures;
    public List<Texture> shipMaterial;

    protected override void Start() {
        playerInitialPos = this.transform;
        base.Start();

        controllerMovement = GetComponent<PlayerMovement>();
        controllerFire = GetComponent<PlayerFire>();
        healthManager = GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void gameOver()
    {
        if (notifyGameOver != null)
            notifyGameOver();
    }

    public void onChangeTexture(Color _color)
    {
        print("On changing ship texture");
        for (int i = 0; i < shipTextures.Count; i++)
        {
            shipTextures[i].material.SetColor("_EmissionColor", _color);
        }
    }
    
    public void playerAddScore(int score)
    {
        playerScore += score;
        if(notifyPlayerScoreObservers != null)
            notifyPlayerScoreObservers(playerScore);
    }
}
