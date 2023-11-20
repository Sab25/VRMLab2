using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCabinet : MonoBehaviour
{
    public GameObject cabinetOpen;
    public GameObject cabinetClose;
    public GameObject proximityText;

    private bool isOpen = false;
    private bool isPlayerNear = false;

    void Start()
    {
        ToggleCabinetState(isOpen);
        proximityText.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.V))
        {
            ToggleCabinetState(!isOpen);
        }
    }

    void ToggleCabinetState(bool newState)
    {
        isOpen = newState;
        cabinetOpen.SetActive(isOpen);
        cabinetClose.SetActive(!isOpen);
        proximityText.SetActive(!isOpen);
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
}
