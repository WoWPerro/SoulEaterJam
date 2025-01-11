using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour {

    [SerializeField] private Transform s1StartingPos;
    [SerializeField] private Transform s2StartingPos;
    [SerializeField] private Transform s3StartingPos;
    [SerializeField] private Transform s4StartingPos;
    [SerializeField] private Transform s5StartingPos;

    private Camera mainCam;

    private void Awake () {
        mainCam = Camera.main;
    }

    // Method that recieves a starting position and moves the camera
    public void SwitchScene (Transform startingPos) {
        Vector3 newPos = new Vector3(startingPos.position.x, startingPos.position.y, -10.0f);
        mainCam.transform.position = newPos;
    }
}
