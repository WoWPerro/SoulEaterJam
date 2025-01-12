using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Singleton Pattern
        private static GameManager instance;
        public static GameManager Instance { 
            get { 
                return instance; 
            } 
        }
        
        private void Awake() {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(this);
            }
        }
    #endregion

    [SerializeField] private int numOfEmpolyees;
    [SerializeField] private TextMeshPro promptText;
    private int recruitNum;
    private int minVal;
    private int maxVal;

    private void Start() {
        minVal = 0;
        maxVal = 5;
    }

    public void GivePrompt() {
        promptText.text = "";
        recruitNum = Random.Range(minVal, maxVal);
        promptText.text = "Recruit " + recruitNum + " candidates.";
    }
}
