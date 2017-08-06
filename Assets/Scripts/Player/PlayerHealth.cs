using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int live = 2;
    public Transform respawnMP;
    public GameObject playerShip;
    public GameObject playerDeathAnim;

    public bool invulnerable = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkForGameover();
    }

    void checkForGameover()
    {
        if (live < 0)
        {
            PlayerManager.Instance.gameOver();
        }
    }

    public void playerDamage()
    {
        invulnerable = true;
        SoundManager.instance.PlaySfx(GameGlobalVariables.SFX_PLAYER_DEATH);
        PlayerManager.controllerMovement.canMove = false;
        playerShip.SetActive(false);
        playerDeathAnim.SetActive(true);
        StartCoroutine(repositionShip());
    }

    IEnumerator fadeInShip()
    {
        yield return null;
    }

    IEnumerator repositionShip()
    {
        yield return new WaitForSeconds(2);
        live--;
        playerDeathAnim.SetActive(false);
        PlayerManager.Instance.gameObject.transform.position = respawnMP.position;
        PlayerManager.Instance.gameObject.transform.position = PlayerManager.Instance.playerInitialPos.position;
        playerShip.SetActive(true);
        PlayerManager.controllerMovement.canMove = true;
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Enemy")
    //    {
    //        print("Me pego player");
    //    }
    //}
}
