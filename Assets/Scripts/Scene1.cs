using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour {

    #region Singleton Pattern
        private static Scene1 instance;
        public static Scene1 Instance { 
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

    [SerializeField] private List<GameObject> walkableRows = new List<GameObject>();
    [SerializeField] private GameObject guyPrefab;
    [SerializeField] private List<GameObject> charactersOnScreen = new List<GameObject>();
    float spawnTimer = 0;

    private void Update() {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 1) {
            if(charactersOnScreen.Count < 10) {
                SpawnGuy(); 
                spawnTimer = 0;
            }

        }

    }

    private void SpawnGuy() {
        int rand = Random.Range(0, walkableRows.Count);
        GameObject guy;
        guy = Instantiate(guyPrefab, 
                    walkableRows[rand].transform.GetChild(0).gameObject.transform.position, 
                    walkableRows[rand].transform.GetChild(0).gameObject.transform.rotation); 
        guy.GetComponent<Character>().SetDestination(walkableRows[rand].transform.GetChild(1).gameObject.transform);
        charactersOnScreen.Add(guy);
    }

    public List<GameObject> GetCharacterOnScreen() {
        return charactersOnScreen;
    }
}
