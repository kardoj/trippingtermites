using UnityEngine;
using System.Collections;

public class ButtonAnimate : MonoBehaviour {

    public Balls ballObject;

    public string color;

    public float endX;
    public float endY;

    public float movingSpeed;
    private float newPosX;
    private float newPosY;

    public bool horizontalMovement;
    public bool verticalMovement;

    private bool animationRunning = false;

    public NextPuzzleScript puzzleScript;

	void Start () {
        Debug.Log(Time.deltaTime * movingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(animationRunning) {

            if (horizontalMovement)
            {
                newPosX = Mathf.Lerp(transform.position.x, endX, Time.deltaTime * movingSpeed);
            }
            else if (verticalMovement)
            {
                newPosY = Mathf.Lerp(transform.position.y, endY, Time.deltaTime * movingSpeed);
            }
            else {
                Debug.Log("f'd up");
            }

            Debug.Log("fRUNNING position-x = " + transform.position.x + " endX = " + endX + " position-y " + transform.position.y + " endY =" + endY);

            transform.position = new Vector3(newPosX, newPosY, -2);
        }
        /*if (Mathf.Round(transform.position.y, 2) <= endY-0.001 && transform.position.x <= endX-0.001 && animationRunning) {
            Debug.Log("fSTOPPING position-x = " + transform.position.x + " endX = " +endX+ " position-y " + transform.position.y + " endY ="+endY);
            animationRunning = false;
            puzzleScript.enableTheButton();
        }*/

        if (Mathf.Round(transform.position.y * 100) == Mathf.Round(endY * 100) && Mathf.Round(transform.position.x * 100) == Mathf.Round(endX * 100) && animationRunning)
        {
            Debug.Log("fSTOPPING position-x = " + transform.position.x + " endX = " + endX + " position-y " + transform.position.y + " endY =" + endY);
            animationRunning = false;
            puzzleScript.enableTheButton();
        }

    }

    void animate() {
        animationRunning = true;
        if (ballObject.correctColor == color) {
            puzzleScript.showText("Correct!");
        }
        else {
            puzzleScript.showText("Wrong...");
        }
        //puzzleScript.showText("IDK yet");
    }
}
