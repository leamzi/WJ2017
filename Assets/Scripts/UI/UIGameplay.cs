using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Autor: Leamzi
/// Class that manage gameplay UI events
/// </summary>
public class UIGameplay : MonoBehaviour {

    public Text textScore;
    public GameObject GameoverPanel;

	// Use this for initialization
	void Start () {
        PlayerManager.Instance.notifyPlayerScoreObservers += addScore;
        PlayerManager.Instance.notifyGameOver += OnGameOver;
        PlayerManager.Instance.notifyPlayerRemoveLives += removeLive;
    }

    private void addScore(int newScore)
    {
        textScore.text = "" + newScore;
    }

    public void OnGameOver()
    {
        GameoverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void removeLive()
    {

    }

    public void OnRetry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene_Gameplay");
    }

    public void OnLeave()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene_Main");
    }
}
