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

    #endregion

    #endregion

    public static PlayerBullet bulletType = new PlayerBullet();
    public class PlayerBullet
    {
        public int bulletForkId = 100;
        public int bulletKnifeId = 101;
        public int bulletMixer = 102;
        public int bulletCutter = 103;
    }

    public PlayerBulletType currentBulletType = PlayerBulletType.BULLET_FORK;
    public enum PlayerBulletType
    {
        BULLET_FORK,
        BULLET_KNIFE,
        BULLET_MIXER,
        BULLET_CUTTER
    }

}
