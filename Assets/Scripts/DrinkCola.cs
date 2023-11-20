using System.Collections;
using UnityEngine;

public class DrinkCola : MonoBehaviour
{
    public float drinkTime = 10f;
    public float rotationTimeScale = 5f;
    public float delayBeforeDisappear = 5f; // Aggiunto il tempo di attesa prima di sparire
    public Transform drinkingTransform;
    public GameObject drinkableObject;
    public GameObject proximityText;

    private bool isDrinking = false;

    void Start(){
        proximityText.SetActive(true);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C) && !isDrinking)
        {
            proximityText.SetActive(false);
            StartCoroutine(DrinkAnimation());
            
        }
    }

    IEnumerator DrinkAnimation()
    {
        isDrinking = true;
        
        Vector3 initialPosition = drinkableObject.transform.position;
        Quaternion initialRotation = drinkableObject.transform.rotation;

        Debug.Log("Start drinking");

        float elapsedTime = 0f;

        while (elapsedTime < drinkTime)
        {
            float percentageComplete = elapsedTime / drinkTime;

            drinkableObject.transform.position = Vector3.Lerp(initialPosition, drinkingTransform.position, percentageComplete);
            drinkableObject.transform.rotation = Quaternion.Slerp(initialRotation, drinkingTransform.rotation, percentageComplete * rotationTimeScale);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Finish drinking");

        
        yield return new WaitForSeconds(delayBeforeDisappear);

        
        drinkableObject.SetActive(false);

        
        drinkableObject.transform.position = initialPosition;
        drinkableObject.transform.rotation = initialRotation;

        isDrinking = false;
    }
}
