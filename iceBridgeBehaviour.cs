using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class iceBridgeBehaviour : MonoBehaviour {
    private Rigidbody2D rb2D;
    public Player player;
    public iceBridge ib;
    private GameObject bridge;
    public int playerId = 0;
    public bool letGo = true;
    private bool pressedDown = false;
    private float rotationNum;
    public AudioSource sound;
    int lol = 0;


    // Use this for initialization
    void Start () {
        sound = GameObject.Find("icebridgeaudio").GetComponent<AudioSource>();
        ib = GameObject.Find("AimPoint").GetComponent<iceBridge>();
        bridge = gameObject.transform.Find("IceBridge").gameObject;
        rb2D = bridge.GetComponent<Rigidbody2D>();
        player = ReInput.players.GetPlayer(playerId);
        rotationNum = ib.returnAngle();

        sound.Play();

        transform.Rotate(0, 0, rotationNum*56); 
    }
	
	// Update is called once per frame
	void Update () {
        if (letGo && player.GetButton("growbridge") && gameObject.transform.localScale.x < 1.5f) {
            gameObject.transform.localScale += new Vector3(0.01f, 0, 0);
            pressedDown = true;
        } else if (pressedDown) {
            if (lol == 0) {
                sound.Pause();
                lol++;
            }
            letGo = false;
            rb2D.gravityScale = 1;
            StartCoroutine(cooldown());
            StartCoroutine(PowerUpcooldown());
        }  
    }

    IEnumerator cooldown() {
        yield return new WaitForSeconds(.9f);
        rb2D.bodyType = RigidbodyType2D.Static;
    }

    IEnumerator PowerUpcooldown() {
        ib.setPressable(false);
        yield return new WaitForSeconds(2f);
        ib.setPressable(true);
    }

}
