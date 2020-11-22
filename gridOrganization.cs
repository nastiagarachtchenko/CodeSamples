using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Rewired;


public class gridOrganization : MonoBehaviour {
    public bool a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4 = false;
    public bool Done = false;
    public sense sA1, sA2, sA3, sA4, sB1, sB2, sB3, sB4, sC1, sC2, sC3, sC4, sD1, sD2, sD3, sD4;
    string[] tagArray;
    public GameObject baby;
    public GameObject newBoy;
    public GameObject GameOverScreen;
    public Text Countdown;
    public selectionMovement selection;
    public puzzleSpawner puzzle;
    public Player player;
    public Help PauseScript;
    public FarmSM SM;
    public int PlayerID;
    public int PlayAgainTime;
    public string[] goalArray = { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " }; //= { "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral", "redCoral" };
    public string Lobby;


    void Start(){
        puzzle = GameObject.Find("PuzzleSpawner").GetComponent<puzzleSpawner>();
        selection = GameObject.Find("selection").GetComponent<selectionMovement>();
        a1 = false;
        tagArray = new string[] {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
        sA1 = GameObject.Find("SensorA1").GetComponent<sense>();
        sA2 = GameObject.Find("SensorA2").GetComponent<sense>();
        sA3 = GameObject.Find("SensorA3").GetComponent<sense>();
        sA4 = GameObject.Find("SensorA4").GetComponent<sense>();
        sB1 = GameObject.Find("SensorB1").GetComponent<sense>();
        sB2 = GameObject.Find("SensorB2").GetComponent<sense>();
        sB3 = GameObject.Find("SensorB3").GetComponent<sense>();
        sB4 = GameObject.Find("SensorB4").GetComponent<sense>();
        sC1 = GameObject.Find("SensorC1").GetComponent<sense>();
        sC2 = GameObject.Find("SensorC2").GetComponent<sense>();
        sC3 = GameObject.Find("SensorC3").GetComponent<sense>();
        sC4 = GameObject.Find("SensorC4").GetComponent<sense>();
        sD1 = GameObject.Find("SensorD1").GetComponent<sense>();
        sD2 = GameObject.Find("SensorD2").GetComponent<sense>();
        sD3 = GameObject.Find("SensorD3").GetComponent<sense>();
        sD4 = GameObject.Find("SensorD4").GetComponent<sense>();
        Instantiate(baby, new Vector3(-2f, 0.3499833f, -2f), Quaternion.identity);
        Instantiate(newBoy, new Vector3(-1f, 0.3499833f, -1f), Quaternion.identity);
        c3 = true;
        b2 = true;
        goalArray = puzzle.getGoalArray();
        player = ReInput.players.GetPlayer(PlayerID);
    }


    void Update() {
        tagArray = new string[] {sA1.returnTag(), sA2.returnTag(), sA3.returnTag(), sA4.returnTag(), sB1.returnTag(), sB2.returnTag(), sB3.returnTag(), sB4.returnTag(), sC1.returnTag(), sC2.returnTag(), sC3.returnTag(), sC4.returnTag(), sD1.returnTag(), sD2.returnTag(), sD3.returnTag(), sD4.returnTag() };

        for (int i = 0; i < 16; i++) {
            if (tagArray[i] != goalArray[i]){
                break;
            } else if (i == 15) {
                print("WIN STATE");
                PauseScript.CanPause = false;
                Done = true;
                GameOverScreen.SetActive(true);
                StartCoroutine("GameOver");
                goalArray = puzzle.getGoalArray();
            }
        }
        if (Done == false)
        {
            if (player.GetButtonDown("MiddlePuff") || Input.GetKeyUp(KeyCode.E))
            {
                destroyPlant(selection.getPosX(), selection.getPosZ());
                SM.DigSound();
            }
        }
        Countdown.text = ("" + PlayAgainTime);
        /*if (PlayAgainTime <= 0)
        {
            Application.LoadLevel(Lobby);
        }*/
    }

    public void destroyPlant( float x, float z) {
        if (x == 0) {
            if (z == 0) {
                sA1.destroy();
                a1 = false;
            } else if (z == -1) {
                sA2.destroy();
                a2 = false;
            } else if (z == -2) {
                sA3.destroy();
                a3 = false;
            } else if (z == -3) {
                sA4.destroy();
                a4 = false;
            }
        } else if (x == -1) {
            if (z == 0) {
                sB1.destroy();
                b1 = false;
            } else if (z == -1) {
                sB2.destroy();
                b2 = false;
            } else if (z == -2) {
                sB3.destroy();
                b3 = false;
            } else if (z == -3) {
                sB4.destroy();
                b4 = false;
            }
        } else if (x == -2) {
            if (z == 0) {
                sC1.destroy();
                c1 = false;
            } else if (z == -1) {
                sC2.destroy();
                c2 = false;
            } else if (z == -2) {
                sC3.destroy();
                c3 = false;
            } else if (z == -3) {
                sC4.destroy();
                c4 = false;
            }
        } else if (x == -3) {
            if (z == 0) {
                sD1.destroy();
                d1 = false;
            } else if (z == -1) {
                sD2.destroy();
                d2 = false;
            } else if (z == -2) {
                sD3.destroy();
                d3 = false;
            } else if (z == -3) {
                sD4.destroy();
                d4 = false;
            }
        }
    }


    public void setA1(bool option) {
        a1 = option;
    }
    public void setA2(bool option) {
        a2 = option;
    }
    public void setA3(bool option) {
        a3 = option;
    }
    public void setA4(bool option) {
        a4 = option;
    }
    public void setB1(bool option) {
        b1 = option;
    }
    public void setB2(bool option) {
        b2 = option;
    }
    public void setB3(bool option) {
        b3 = option;
    }
    public void setB4(bool option) {
        b4 = option;
    }
    public void setC1(bool option) {
        c1 = option;
    }
    public void setC2(bool option) {
        c2 = option;
    }
    public void setC3(bool option) {
        c3= option;
    }
    public void setC4(bool option) {
        c4 = option;
    }
    public void setD1(bool option) {
        d1 = option;
    }
    public void setD2(bool option) {
        d2 = option;
    }
    public void setD3(bool option) {
        d3 = option;
    }
    public void setD4(bool option) {
        d4 = option;
    }

    public bool getA1() {
        return a1;
    }
    public bool getA2() {
        return a2;
    }
    public bool getA3() {
        return a3;
    }
    public bool getA4() {
        return a4;
    }
    public bool getB1() {
        return b1;
    }
    public bool getB2() {
        return b2;
    }
    public bool getB3() {
        return b3;
    }
    public bool getB4() {
        return b4;
    }
    public bool getC1() {
        return c1;
    }
    public bool getC2() {
        return c2;
    }
    public bool getC3() {
        return c3;
    }
    public bool getC4() {
        return c4;
    }
    public bool getD1() {
        return d1;
    }
    public bool getD2() {
        return d2;
    }
    public bool getD3() {
        return d3;
    }
    public bool getD4() {
        return d4;
    }
    IEnumerator GameOver()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            PlayAgainTime--;
        }
    }
}
