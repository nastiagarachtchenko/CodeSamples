using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitchScript : MonoBehaviour {
    public GameObject arduinoInput;
    public SoundManagerScript sound;
    public AudioSource playSound;

    public GameObject scene1Video;
    private GameObject scene2Video;

    public Arduino_AllInputs ard;
    public float inputCooldownTime = 2f;

    private bool takingInput = true;
    public bool scene1Triggered = false;
    public bool scene2Triggered = false;

    public int scene1Pin;
    public int scene2Pin;

    private bool firstVid = true;

    void Start () {
        ard = arduinoInput.GetComponent<Arduino_AllInputs>();
        playSound = GameObject.Find("Sound Manager").GetComponent<AudioSource>();
        sound = GameObject.Find("Sound Manager").GetComponent<SoundManagerScript>();
        scene1Video = GameObject.Find("Scene1");
        scene2Video = GameObject.Find("Scene2");

        scene1Video.SetActive(false);
        scene2Video.SetActive(false);
        StartCoroutine(InputCooldown());
    }
	
	void Update () {
        if (!ard.digitalInput[scene1Pin] && takingInput && !scene1Triggered) {
            StartCoroutine(InputCooldown());
            scene1Triggered = true;
            scene2Triggered = false;
            enableVideo(scene1Video, scene2Video);
            sound.scene1();
            playSound.Play();
        }

        if (!ard.digitalInput[scene2Pin] && takingInput && !scene2Triggered) {
            StartCoroutine(InputCooldown());
            scene1Triggered = false;
            scene2Triggered = true;
            enableVideo(scene2Video, scene1Video);
            sound.scene2();
            playSound.Play();
        }

    }

    public void enableVideo(GameObject enabledVid, GameObject disabledVid1) {
        enabledVid.SetActive(true);
        disabledVid1.SetActive(false);
        if (firstVid) {
            GameObject.Find("Canvas").SetActive(false);
            firstVid = false;
        }
        
    }

    IEnumerator InputCooldown() {
        takingInput = false;
        yield return new WaitForSeconds(inputCooldownTime);
        takingInput = true;
    }
}
