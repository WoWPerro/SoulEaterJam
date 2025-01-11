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
public class CharacterGO : MonoBehaviour
{
    private CharacterType characterType;
    private float happyness;
    private float timeToWait;

    public float maxHappyness;
    public UnityEngine.UI.Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        happyness = Random.Range(0, maxHappyness);
        characterType = (CharacterType)Random.Range(0, 4);
        timeToWait = happyness / 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        float elapsedTime = 0;
        slider.value = 1;

        while(elapsedTime <= timeToWait)
        {
            elapsedTime += Time.deltaTime;
            slider.value = 1 - (elapsedTime / timeToWait);

            yield return new WaitForFixedUpdate();
        }

        
        
        
    }
}
