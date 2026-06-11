using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChairButtonCollider : MonoBehaviour
{
    public Canvas chairCanvas;

    // Start is called before the first frame update
    void Start()
    {
        chairCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter Player");
            chairCanvas.enabled = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chairCanvas.enabled = false;
        }
    }
}
