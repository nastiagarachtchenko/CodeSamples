using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerBehavior : MonoBehaviour {
    public letterGenerator letter;
    private string[][] letterStock = new string[3][];
    public string[] iSlot1;
    public string[] iSlot2;
    public string[] iSlot3;
    public int slotSelection = 0;
    public GameObject slot0selection;
    public GameObject slot1selection;
    public GameObject slot2selection;
    public GameObject openLetter;
    public Text letterText;
    public GameObject purpleAngry;
    public GameObject blueAngry;
    public GameObject orangeAngry;
    public GameObject tealAngry;
    public GameObject yellowAngry;
    public GameObject pinkAngry;
    public PlayerMoveJoystickRewire ps;
    public GameObject purpleBub;
    public GameObject blueBub;
    public GameObject orangeBub;
    public GameObject tealBub;
    public GameObject yellowBub;
    public GameObject pinkBub;
    public GameObject letter1;
    public GameObject letter2;
    public GameObject letter3;
    public bool sadpurple = false;
    public bool sadorange = false;
    public bool sadyellow = false;
    public bool sadteal = false;
    public bool sadblue = false;
    public bool sadpink = false;
    public string winScene;
    public string loseScene;
    public GameObject rep1;
    public GameObject rep2;
    public GameObject rep3;
    public GameObject rep4;
    public GameObject rep5;
    public GameObject rep6;


    void Start() {
        letter = GameObject.Find("GameManager").GetComponent<letterGenerator>();
        ps = GameObject.Find("Player").GetComponent<PlayerMoveJoystickRewire>();
        letterText.text = "";

        letterStock[0] = new string[] { " ", " ", " ", " " };
        letterStock[1] = new string[] { " ", " ", " ", " " };
        letterStock[2] = new string[] { " ", " ", " ", " " };

        slot1selection.SetActive(false);
        slot2selection.SetActive(false);
        openLetter.SetActive(false);
        purpleAngry.SetActive(false);
        blueAngry.SetActive(false);
        orangeAngry.SetActive(false);
        tealAngry.SetActive(false);
        yellowAngry.SetActive(false);
        pinkAngry.SetActive(false);
        purpleBub.SetActive(false);
        blueBub.SetActive(false);
        orangeBub.SetActive(false);
        tealBub.SetActive(false);
        yellowBub.SetActive(false);
        pinkBub.SetActive(false);
        letter1.SetActive(false);
        letter2.SetActive(false);
        letter3.SetActive(false);
        letterText.enabled = false;


        StartCoroutine(FirstLetter());
        StartCoroutine(SecondLetter());
        StartCoroutine(ThirdLetter());
    }

    public void FixedUpdate() {
        if (slotSelection == 0) {
            slot0selection.SetActive(true);
            slot1selection.SetActive(false);
            slot2selection.SetActive(false);
        }
        if (slotSelection == 1) {
            slot0selection.SetActive(false);
            slot1selection.SetActive(true);
            slot2selection.SetActive(false);
        }
        if (slotSelection == 2) {
            slot0selection.SetActive(false);
            slot1selection.SetActive(false);
            slot2selection.SetActive(true);
        }

        for (int i = 0; i < 3; i++) {
            string temp = letterStock[i][0];
            if (temp == "purple") {
                purpleBub.SetActive(true);
            }

            if (temp == "blue") {
                blueBub.SetActive(true);
            }

            if (temp == "orange") {
                orangeBub.SetActive(true);
            }

            if (temp == "teal") {
                tealBub.SetActive(true);
            }

            if (temp == "yellow") {
                yellowBub.SetActive(true);
            }

            if (temp == "pink") {
                pinkBub.SetActive(true);
            }

        }

        string[] currentLetterSelected = ps.getLetterInInventory(slotSelection);
        letterText.text = currentLetterSelected[3];

        updateReputation();
        updateLetters();
        checkEnd();
    }

    public void updateReputation() {
        int rep = ps.getReputation();

        if (rep < 2) {
            rep2.SetActive(false);
        } else { rep2.SetActive(true); }

        if (rep < 3) {
            rep3.SetActive(false);
        } else { rep3.SetActive(true); }

        if (rep < 4) {
            rep4.SetActive(false);
        } else { rep4.SetActive(true); }

        if (rep < 5) {
            rep5.SetActive(false);
        } else { rep5.SetActive(true); }

        if (rep < 6) {
            rep6.SetActive(false);
        } else { rep6.SetActive(true); }

    }


    public void updateLetters(){
        string[][] tempInventory = ps.getInventory();
        for (int i = 0; i < 3; i++) {
            if (tempInventory[i][0] == " ") {
                showLetter(i, false);
            } else { showLetter(i, true); }
        }
    }


    public string[] putLetterInPocket(int i) {
        string[] temp = letterStock[i];
        deactivateBub(temp[0]);
        letterStock[i] = new string[] { " ", " ", " ", " " };
        return temp;
    }

    public void deactivateBub(string sentBy) {
        if (sentBy == "purple") {
            purpleBub.SetActive(false);
        }

        if (sentBy == "blue") {
            blueBub.SetActive(false);
        }

        if (sentBy == "orange") {
            orangeBub.SetActive(false);
        }

        if (sentBy == "teal") {
            tealBub.SetActive(false);
        }

        if (sentBy == "yellow") {
            yellowBub.SetActive(false);
        }

        if (sentBy == "pink") {
            pinkBub.SetActive(false);
        }
    }

    
    public void getUpset(string name) {

        if (name == "purple") {
            purpleAngry.SetActive(true);
            sadpurple = true;
        }

        if (name == "blue") {
            blueAngry.SetActive(true);
            sadblue = true;
        }

        if (name == "orange") {
            orangeAngry.SetActive(true);
            sadorange = true;
        }

        if (name == "teal") {
            tealAngry.SetActive(true);
            sadteal = true;
        }

        if (name == "yellow") {
            yellowAngry.SetActive(true);
            sadyellow = true;
        }

        if (name == "pink") {
            pinkAngry.SetActive(true);
            sadpink = true;
        }

    }



    public string[][] getLetterStock() {
        return letterStock;
    }

    public void generateNewLetter() {
        int counter = -1;
        string temp = "";
        do {
            counter++;
            temp = letterStock[counter][0];
        }while(temp != " ");

        StartCoroutine(NewLetter(counter));
    }

    public void increaseSlot() {
        if (slotSelection == 2) {
            slotSelection = 0;
        } else {
            slotSelection++;
        }
    }

    public void decreaseSlot() {
        if (slotSelection == 0) {
            slotSelection = 2;
        } else {
            slotSelection--;
        }
    }

    public void readSlot() {
        openLetter.SetActive(true);
        letterText.enabled = true;
        string[] temp = ps.getLetterInInventory(slotSelection);
    }

    public void closeLetter() {
        openLetter.SetActive(false);
        letterText.enabled = false;
    }

    public void checkEnd() {
        if(sadblue && sadorange && sadpink && sadpurple && sadteal && sadyellow) {
            SceneManager.LoadScene(winScene);
        }
    }

    public void loseScreen() {
        SceneManager.LoadScene(loseScene);
    }


    public void showLetter(int i, bool tf) {
        if(i == 0) {
            letter1.SetActive(tf);
        }
        if (i == 1) {
            letter2.SetActive(tf);
        }
        if (i == 2) {
            letter3.SetActive(tf);
        }
    }

    public int getSlotSelection() {
        return slotSelection;
    }

    private IEnumerator FirstLetter() {
        yield return new WaitForSeconds(2f);
        letterStock[0] = letter.writeLetter();
    }

    private IEnumerator SecondLetter() {
        yield return new WaitForSeconds(7f);
        letterStock[1] = letter.writeLetter();
    }

    private IEnumerator ThirdLetter() {
        yield return new WaitForSeconds(16f);
        letterStock[2] = letter.writeLetter();
    }

    private IEnumerator NewLetter(int i) {
        yield return new WaitForSeconds(4f);
        letterStock[i] = letter.writeLetter();
    }


}
