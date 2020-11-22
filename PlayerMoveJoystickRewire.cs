using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerMoveJoystickRewire : MonoBehaviour {
    private Rigidbody2D rb2d;
    public Vector2 velocity;
    public bool useForce = false;
    public bool rotate;
    public float rotationSpeed;
    public float turnDirection;
    private Quaternion lastRotation;
    public bool canHit = true;
    public gameManagerBehavior gm;
    public string[][] playerInventory = new string[3][];
    public bool letterOpen = false;
    public int reputation = 3;

    //Rewired Code
    private Player player; // The Rewired Player
    public int playerId = 0;


    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        player = ReInput.players.GetPlayer(playerId);
        gm = GameObject.Find("GameManager").GetComponent<gameManagerBehavior>();

        playerInventory[0] = new string[] { " ", " ", " ", " " };
        playerInventory[1] = new string[] { " ", " ", " ", " " };
        playerInventory[2] = new string[] { " ", " ", " ", " " };
    }

    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        Vector2 direction = new Vector2();
        direction.x = player.GetAxis("MoveH");
        direction.y = player.GetAxis("MoveV");

        if (player.GetButton("Left") && canHit) {
            gm.decreaseSlot();
            StartCoroutine(CoolDown());
        }

        if (player.GetButton("Right") && canHit) {
            gm.increaseSlot();
            StartCoroutine(CoolDown());
        }



        if (player.GetButton("Read") && canHit && !letterOpen) {
            print("readletter");
            gm.readSlot();
            letterOpen = true;
            StartCoroutine(CoolDown());

        }

        if (letterOpen && canHit && player.GetButton("Read")) {
            gm.closeLetter();
            letterOpen = false;
            StartCoroutine(CoolDown());
        }

        if(reputation == 0) {
            gm.loseScreen();
        }



        Vector2 adjustedVelocity = new Vector2(velocity.x * direction.x, velocity.y * direction.y);

        //check to see if we should use force or a static speed
        if (useForce) {
            rb2d.AddForce(adjustedVelocity);
        } else {
            rb2d.velocity = adjustedVelocity;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        string[][] temp = gm.getLetterStock();
        for (int i = 0; i < 3; i++) {
            string temp1 = temp[i][0];
            if (collision.tag == temp1) {
                if(playerInventory[0][0] == " ") {
                    playerInventory[0] = gm.putLetterInPocket(i);
                } else if (playerInventory[1][0] == " ") {
                    playerInventory[1] = gm.putLetterInPocket(i);
                } else if (playerInventory[2][0] == " ") {
                    playerInventory[2] = gm.putLetterInPocket(i);
                } else {
                    print("sorry inventory full");
                }
            } 
        }
       
    }


    public void OnTriggerStay2D(Collider2D collision) {
        if (player.GetButton("Deliver") && canHit) {

            string temp1 = playerInventory[gm.getSlotSelection()][1];
            if (collision.tag == temp1) {
                if (reputation < 6) {
                    reputation++;
                }
                playerInventory[gm.getSlotSelection()] = new string[] { " ", " ", " ", " " };
                gm.generateNewLetter();
            }

            temp1 = playerInventory[gm.getSlotSelection()][2];
            if (collision.tag == temp1) {
                reputation--;
                playerInventory[gm.getSlotSelection()] = new string[] { " ", " ", " ", " " };
                gm.getUpset(temp1);
                gm.generateNewLetter();
            }
            StartCoroutine(CoolDown());
        }
        
    }

    public int getReputation() {
        return reputation;
    }

    
    public string[] getLetterInInventory(int i) {
        return playerInventory[i];
    }

    public string[][] getInventory() {
        return playerInventory;
    }


    private IEnumerator CoolDown() {
            canHit = false;
            yield return new WaitForSeconds(.3f);
            canHit = true;
    }


}
