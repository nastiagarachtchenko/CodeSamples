using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class DeathZoneBehaviour : MonoBehaviour {
    public Player player;
    public int playerId = 0;
    public GameObject canvas;
    public string currentScene;
    public bool dead = false;


    // Use this for initialization
    void Start () {
        player = ReInput.players.GetPlayer(playerId);
        canvas.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (canvas.activeSelf && player.GetButton("resetSwitch")) {
            SceneManager.LoadScene(currentScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            dead = true;
            StartCoroutine(countdowntoReset(col));
        }
    }

    public bool isDead() {
        return dead;
    }

    IEnumerator countdowntoReset(Collider2D col) {
        yield return new WaitForSeconds(.8f);
        //col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
        yield return new WaitForSeconds(2f);
        canvas.SetActive(true);
    }

}
