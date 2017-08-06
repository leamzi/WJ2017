using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameGlobalVariables : SingletonMonoBehaviour<GameGlobalVariables> {

    #region Sound Vars

    #region BGMs
    public static string BGM_GAMEPLAY = "BGM_Gameplay";
    #endregion

    #region SFXs
    public static string SFX_PLAYER_BLAST_01 = "SFX_Player_Blast";

    #endregion

    #endregion

    #region Player Vars
    public static PlayerBullet bulletType = new PlayerBullet();
    public class PlayerBullet
    {
        public int bulletForkID = 100;
        public int bulletKnifeID = 101;
        public int bulletMixerID = 102;
        public int bulletCutterID = 103;
    }
    #endregion

    #region Game Vars
    public PlayerBulletType currentBulletType = PlayerBulletType.BULLET_FORK;
    public enum PlayerBulletType
    {
        BULLET_FORK,
        BULLET_KNIFE,
        BULLET_MIXER,
        BULLET_CUTTER
    }

    public enum PowerupType
    {
        POWERUP_WEAPON,
        POWERUP_SHIELD,
        POWERUP_SPECIAL_ATTACK
    }

    public static GamePowerups gamePowerupType = new GamePowerups();
    public class GamePowerups
    {
        public int powerupWeaponID = 200;
    }
    #endregion

}
