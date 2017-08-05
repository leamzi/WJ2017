using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGlobalVariables : SingletonMonoBehaviour<GameGlobalVariables> {

    #region Sound Vars

    #region BGMs
    public static string BGM_GAMEPLAY = "BGM_Gameplay";
    #endregion

    #region SFXs

    #endregion

    #endregion

    // Use this for initialization
    protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
