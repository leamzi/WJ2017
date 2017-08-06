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

    public Transform bulletForkMP;
    public Transform bulletKnifeMP01;
    public Transform bulletKnifeMP02;
    public Transform bulletCutterMP01;
    public Transform bulletCutterMP02;
    public Transform bulletCutterMP03;

    public delegate void OnPlayerScore(int newScore);
    public event OnPlayerScore notifyPlayerScoreObservers;

    private int playerScore;

    public List<MeshRenderer> shipTextures;
    public List<Texture> shipMaterial;

    protected override void Start() {
        base.Start();

        controllerMovement = GetComponent<PlayerMovement>();
        controllerFire = GetComponent<PlayerFire>();
    }
	
	// Update is called once per frame
	void Update () {
		
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
        notifyPlayerScoreObservers(playerScore);
    }
}
