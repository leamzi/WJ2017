using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Method to initialize singletons in game
/// </summary>
public class InitializerScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("Initializing Singleton Scripts");
        GameGlobalVariables.Instantiate();
	}
	
}
