using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour {

    [SerializeField] private Transform s1StartingPos;
    [SerializeField] private Transform s2StartingPos;
    [SerializeField] private Transform s3StartingPos;
    [SerializeField] private Transform s4StartingPos;
    [SerializeField] private Transform s5StartingPos;       
    private float speed;       
    private bool canMoveCamPositiveY;       
    private bool canMoveCamNegativeY;       

    private Camera mainCam;

    private void Awake () {
        mainCam = Camera.main;
    }

    private void Start() {
        speed = 0.01f;
        canMoveCamPositiveY = true;
        canMoveCamNegativeY = true;
    }

    private void Update() {
		if(Input.GetKey(KeyCode.DownArrow) && canMoveCamNegativeY == true) {
			mainCam.transform.position = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y - speed, mainCam.transform.position.z);
            canMoveCamPositiveY = true;
        }
		else if(Input.GetKey(KeyCode.UpArrow) && canMoveCamPositiveY == true) {
			mainCam.transform.position = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y + speed, mainCam.transform.position.z);
            canMoveCamNegativeY = true;
        }

        if (mainCam.transform.position.y <= -2.1f) {
            canMoveCamNegativeY = false;
            canMoveCamPositiveY = true;
        }
        if (mainCam.transform.position.y >= 6.27f) {
            canMoveCamNegativeY = true;
            canMoveCamPositiveY = false;
        }
    }

    // Method that recieves a starting position and moves the camera
    public void SwitchScene (Transform startingPos) {
        Vector3 newPos = new Vector3(startingPos.position.x, startingPos.position.y, -10.0f);
        mainCam.transform.position = newPos;
    }
}
