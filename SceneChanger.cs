using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public string newScene;
    public bool sceneswitch = false;


    private void Start() {
        StartCoroutine(Sceneswitch());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.anyKey && sceneswitch) {
            SceneManager.LoadScene(newScene);
        }
    }

    IEnumerator Sceneswitch() {
        yield return new WaitForSeconds(.7f);
        sceneswitch = true;
    }
}


