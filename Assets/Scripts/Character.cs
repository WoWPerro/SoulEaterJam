using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum CharacterType
{
    red=0,
    blue=1,
    green=2,
    yellow=3
}

public class Character : MonoBehaviour
{
    private CharacterType characterType;
    private float happyness;
    private float timeToWait;
    public float maxHappyness;
    public UnityEngine.UI.Slider slider;
    private Transform destination;
    float timeSinceStarted = 0f;

    private void Start() {
        happyness = Random.Range(0, maxHappyness);
        characterType = (CharacterType)Random.Range(0, 4);
        timeToWait = happyness / 10;
    }

    private void OnMouseDown() {
        StartCoroutine(Timer());
    }

    private void Update() {
        if (destination != null) {
            float step =  0.5f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step); 
        }
        if(transform.position == destination.position) {
            Scene1.Instance.GetCharacterOnScreen().Remove(gameObject);
            Destroy(gameObject);
        }
    }

    private IEnumerator Timer() {
        float elapsedTime = 0;
        slider.value = 1;

        while(elapsedTime <= timeToWait)
        {
            elapsedTime += Time.deltaTime;
            slider.value = 1 - (elapsedTime / timeToWait);

            yield return new WaitForFixedUpdate();
        }
    }

    public Transform GetDestination() {
        return destination;
    }

    public void SetDestination(Transform d) {
        destination = d;
    }
}

