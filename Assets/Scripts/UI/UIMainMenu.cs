using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Autor: Leamzi
/// Scene that manage Main Menu Methods.
/// </summary>
public class UIMainMenu : MonoBehaviour {

    private void Start()
    {
        SoundManager.instance.PlayBgm(GameGlobalVariables.BGM_MAINMENU);
    }

    /// <summary>
    /// Change scene to gameplay screen
    /// </summary>
    public void OnPlay()
    {
        SceneManager.LoadScene("Scene_Intro");
    }
}
