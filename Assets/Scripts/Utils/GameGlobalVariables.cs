using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Class that manage global variables in the game
/// </summary>
public class GameGlobalVariables : SingletonMonoBehaviour<GameGlobalVariables> {

    #region Sound Vars

    #region BGMs
    public static string BGM_GAMEPLAY = "BGM_Gameplay";
    #endregion

    #region SFXs
    public static string SFX_PLAYER_BLAST_FORK = "SFX_Player_Blast";
    public static string SFX_PLAYER_BLAST_KNIFE = "SFX_Player_Blast_Knife";
    public static string SFX_PLAYER_BLAST_CUTTER = "SFX_Player_Blast_Cutter";
    public static string SFX_PLAYER_DEATH = "SFX_Player_Explosion";
    public static string SFX_PLAYER_EXTRA_LIFE_POWERUP = "SFX_Player_Extra_Life";
    public static string SFX_ENEMY_BLAST_01 = "SFX_Enemy_Blast";
    public static string SFX_ENEMY_DEATH = "SFX_Enemy_Explosion";
    public static string SFX_GAMEPLAY_POWERUP = "SFX_Gameplay_Powerup";
    #endregion

    #endregion

    #region Player Vars
    public static PlayerBullet bulletType = new PlayerBullet();
    public class PlayerBullet
    {
        public int bulletForkID = 100;
        public int bulletKnifeID = 101;
        public int bulletCutterID = 102;
        public int bulletMixerID = 103;
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
