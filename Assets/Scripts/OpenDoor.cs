using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public float openTime = 10f;
    public float rotationTimeScale = 5f;
    public float delayBeforeReset = 2f; 
    public Transform doorTransform;  
    public GameObject openableObject;
    public GameObject proximityText;
    private bool isOpen = false;
    private bool isPlayerNear = false;

    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.C) && !isOpen && isPlayerNear)
        {
            proximityText.SetActive(false);
            StartCoroutine(OpenAnimation());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isOpen && other.CompareTag("Player"))
        {
            isPlayerNear = true;
            proximityText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!isOpen && other.CompareTag("Player"))
        {
            isPlayerNear = false;
            proximityText.SetActive(false);
        }
    }

    IEnumerator OpenAnimation()
    {
        isPlayerNear = false; 
        isOpen = true;
        Vector3 initialPosition = openableObject.transform.position;
        Quaternion initialRotation = doorTransform.rotation;  
        float elapsedTime = 0f;

        while (elapsedTime < openTime)
        {
            float percentageComplete = elapsedTime / openTime;

            openableObject.transform.position = Vector3.Lerp(initialPosition, doorTransform.position, percentageComplete);
            openableObject.transform.rotation = Quaternion.Slerp(initialRotation, doorTransform.rotation, percentageComplete * rotationTimeScale);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(delayBeforeReset);
        

        openableObject.transform.position = initialPosition;
        openableObject.transform.rotation = initialRotation;
        isOpen = false;
        

        
    }

}


