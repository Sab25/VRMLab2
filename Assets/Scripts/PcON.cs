using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcSwitch : MonoBehaviour
{
    public GameObject pcOn;
    public GameObject pcOff;
    public GameObject proximityText;

    private bool isOn = false;
    private bool isPlayerNear = false;

    void Start()
    {
        TogglePCState(isOn);
        proximityText.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            TogglePCState(!isOn);
        }
    }

    void TogglePCState(bool newState)
    {
        isOn = newState;
        pcOn.SetActive(isOn);
        pcOff.SetActive(!isOn);
        proximityText.SetActive(!isOn);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isOn && other.CompareTag("Player"))
        {
            isPlayerNear = true;
            proximityText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!isOn && other.CompareTag("Player"))
        {
            isPlayerNear = false;
            proximityText.SetActive(false);
        }
    }
}
