using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextPuzzleScript : MonoBehaviour {

    public Canvas canvas;
    public Text winText;


    void Start() {
        canvas = gameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void enableTheButton() {
        canvas.enabled = true;
    }

    public void ReloadTheScnene() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void showText(string textString) {
        winText.text = textString;
    }
}
