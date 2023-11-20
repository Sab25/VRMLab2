using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCola : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject proximityText;
    private bool isVisible = false;
    private bool isPlayerNearby = false;

    void Start()
    {
        targetObject.SetActive(false);
        proximityText.SetActive(false);
    }

    void Update()
    {
        // Verifica se il giocatore è nelle vicinanze prima di eseguire l'azione
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.B))
        {
            isVisible = !isVisible;
            targetObject.SetActive(isVisible);

            if (isVisible)
            {
                proximityText.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isVisible && other.gameObject.tag == "Player")
        {
            proximityText.SetActive(true);
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!isVisible && other.gameObject.tag == "Player")
        {
            proximityText.SetActive(false);
            isPlayerNearby = false;
        }
    }
}
