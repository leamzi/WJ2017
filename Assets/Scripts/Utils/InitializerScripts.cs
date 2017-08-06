using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Method to initialize singletons in game
/// </summary>
public class InitializerScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.SetResolution(600, 900, false);

        print("Initializing Singleton Scripts");
        GameGlobalVariables.Instantiate();
	}
	
}
