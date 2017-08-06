using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Autor: Leamzi
/// Class that manage gameplay UI events
/// </summary>
public class UIGameplay : MonoBehaviour {

    public Text textScore;

	// Use this for initialization
	void Start () {

        PlayerManager.Instance.notifyPlayerScoreObservers += addScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void addScore(int newScore)
    {
        textScore.text = "" + newScore;
    }
}
