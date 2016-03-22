using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {
    RaycastHit hit = new RaycastHit();
    public GameObject leftButtonGreen;
    public GameObject rightButtonYellow;
    public GameObject topButtonBlue;
    public GameObject BottomButtonRed;
    	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                hit.collider.SendMessage("animate");
            }
        }
    }


}
