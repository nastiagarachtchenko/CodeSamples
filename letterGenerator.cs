using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterGenerator : MonoBehaviour {
    public string[] Characters;
    public string[] Insults;
    private string realSender;
    private string realReciever;
    private string realShittalked;
    private string realLetterBodyText;

    public string[] writeLetter() {
        // returns an array that is { sender , reciever , shittalked , letterBodyText }

        realSender = numberGenerator(Characters);

        do {
            realReciever = numberGenerator(Characters);
        } while (realReciever == realSender);

        do {
            realShittalked = numberGenerator(Characters);
        } while (realShittalked == realReciever || realShittalked == realSender);

        realLetterBodyText = createLetterBody(realSender, realReciever, realShittalked);

        string[] finalLetter = { realSender, realReciever, realShittalked, realLetterBodyText };

        return finalLetter;
    }


    public string createLetterBody(string sender, string reciever, string shittalked) {
        //creates letter body text based on parameters passed in and generates an insult

        string letterBodytext = "Dear " + reciever + ",\r\n\r\nI have heard that " + shittalked + " " + getInsult() + "   \r\n\r\nSincerely, \r\n" + sender;
        return letterBodytext;
    }

    public string getInsult() {
        return numberGenerator(Insults);
    }

    public string numberGenerator(string[] arrayThing) {
        //generates a random number based on the length of the array passed in b/w 0 and length of array

        int ranNum = Random.Range(0, arrayThing.Length);
        return arrayThing[ranNum];
    }


    /*----------- UTILITY METHODS -----------*/

    public string getSender(string[] letter) {
        return letter[0];
    }

    public string getReciver(string[] letter) {
        return letter[1];
    }

    public string getShittalked(string[] letter) {
        return letter[2];
    }

    public string getLetterBodyText(string[] letter) {
        return letter[3];
    }

}
