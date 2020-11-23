using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnTouch : MonoBehaviour {
    public AudioClip otherClip; //Music that will play as long as you are touching something
    private AudioSource audioS;

    public AudioClip ambientMusic;//background music - no collider effects added just plays forever
    private AudioSource audioS02;

    public AudioClip lowNote;//Interaction to play 1 note Low
    private AudioSource audioSLow;

    public AudioClip lowMidNote;//Interaction to play 1 note Low Mid
    private AudioSource audioSLowMid;

    public AudioClip midNote;//Interaction to play 1 note Mid
    private AudioSource audioSMid;

    public AudioClip midHighNote;//Interaction to play 1 note Mid High
    private AudioSource audioSMidHigh;

    public AudioClip highNote;//Interaction to play 1 note High
    private AudioSource audioSHigh;

    public AudioClip reallyHighNote;//Interaction to play 1 note Really High
    private AudioSource audioSReallyHigh;


    public string tagForTrigger; // tag for Music That will play as you are touching something
    public string tagForLow; //Low
    public string tagForLowMid; //LowMid
    public string tagForMid; //Mid
    public string tagForMidHigh; //HighMid
    public string tagForHigh; //High
    public string tagForReallyHigh; //ReallyHigh



    void Start(){
        audioS02 = GetComponent<AudioSource>();
        audioS02.clip = ambientMusic;
        //audioS02.Play();
    }

    private void OnTriggerEnter(Collider collider){
        /*if (collider.tag == tagForTrigger)
        {
            audioS = GetComponent<AudioSource>();
            audioS.clip = otherClip;
            audioS.Play();
        }*/

        if (collider.tag == tagForLow)
        {
            audioSLow = GetComponent<AudioSource>();
            audioSLow.clip = lowNote;
            audioSLow.Play();
        }

        if (collider.tag == tagForLowMid)
        {
            audioSLowMid = GetComponent<AudioSource>();
            audioSLowMid.clip = lowMidNote;
            audioSLowMid.Play();
        }

        if (collider.tag == tagForMid)
        {
            audioSMid = GetComponent<AudioSource>();
            audioSMid.clip = midNote;
            audioSMid.Play();
        }

        if (collider.tag == tagForMidHigh)
        {
            audioSMidHigh = GetComponent<AudioSource>();
            audioSMidHigh.clip = midHighNote;
            audioSMidHigh.Play();
        }

        if (collider.tag == tagForHigh)
        {
            audioSHigh = GetComponent<AudioSource>();
            audioSHigh.clip = highNote;
            audioSHigh.Play();
        }


        if (collider.tag == tagForReallyHigh)
        {
            audioSReallyHigh = GetComponent<AudioSource>();
            audioSReallyHigh.clip = reallyHighNote;
            audioSReallyHigh.Play();
        }




    }

    void OnTriggerExit(Collider goodbye){
       /* if (goodbye.tag == tagForTrigger)
        {
            audioS.Stop();
        }

        if (goodbye.tag == tagForLow)
        {
            audioSLow.Stop();
        }

        if (goodbye.tag == tagForLowMid)
        {
            audioSLowMid.Stop();
        }

        if (goodbye.tag == tagForMid)
        {
            audioSMid.Stop();
        }

        if (goodbye.tag == tagForMidHigh)
        {
            audioSMidHigh.Stop();
        }

        if (goodbye.tag == tagForHigh)
        {
            audioSHigh.Stop();
        }

        if (goodbye.tag == tagForReallyHigh)
        {
            audioSReallyHigh.Stop();
        }*/

    }
}

  