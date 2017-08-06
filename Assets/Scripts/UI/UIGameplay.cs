using UnityEngine;
using UnityEngine.UI;

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
}
