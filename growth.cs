using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growth : MonoBehaviour{
    public int growthState;
    private bool timer1 = true;
    private int ranNum;
    public GameObject carrot1;
    public GameObject carrot2;
    public GameObject carrot3;
    public GameObject carrot4;

    void Start(){
        growthState = 0;
        //gameObject.transform.localScale = new Vector3(0.2f, 0.45f, 0.2f);
        carrot1.SetActive(true);
        carrot2.SetActive(false);
        carrot3.SetActive(false);
        carrot4.SetActive(false);
    }

    void FixedUpdate(){
        if (timer1 == true) { StartCoroutine("growtimer"); timer1 = false; }


        if (growthState == 0|| growthState == 1) {
            carrot1.SetActive(true);
            carrot2.SetActive(false);
            carrot3.SetActive(false);
            carrot4.SetActive(false);
        } else if (growthState == 2) {
            carrot1.SetActive(false);
            carrot2.SetActive(true);
        }else if(growthState == 3) {
            carrot2.SetActive(false);
            carrot3.SetActive(true);
        } else if (growthState == 4) {
            carrot3.SetActive(false);
            carrot4.SetActive(true);
        }



    }

    void growing() {
        ranNum = Random.Range(0, 4);

        if (ranNum == 2 && growthState < 4) {
            growthState++;
            //transform.localScale += new Vector3(0.05F, 0.05f, 0.05f);

        }
    }

    IEnumerator growtimer() {
        yield return new WaitForSeconds(.3f);
        growing();
        timer1 = true;
    }

}
