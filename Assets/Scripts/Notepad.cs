using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notepad : MonoBehaviour
{
    public GameObject NotepadON;
    public GameObject NotepadOff;
    public GameObject proximityText;

    private bool isOn = false;

    void Start()
    {
        TogglePCState(isOn);
        proximityText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TogglePCState(!isOn);
        }
    }

    void TogglePCState(bool newState)
    {
        isOn = newState;
        NotepadON.SetActive(isOn);
        NotepadOff.SetActive(!isOn);
        proximityText.SetActive(!isOn);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isOn && other.CompareTag("Player"))
        {
            proximityText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!isOn && other.CompareTag("Player"))
        {
            proximityText.SetActive(false);
       }
    }
}