using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LihgtOnOff : MonoBehaviour
{
    Light myLight;
    public GameObject proximityText;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        proximityText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            myLight.enabled = !myLight.enabled;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Attiva il testo di prossimità
            proximityText.SetActive(true);
        }
    }

    // Quando il giocatore esce dalla zona di trigger
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Disabilita il testo di prossimità
            proximityText.SetActive(false);
        }
    }
}
