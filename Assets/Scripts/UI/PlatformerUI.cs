using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerUI : MonoBehaviour
{
    [SerializeField] Canvas instructionsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        instructionsCanvas.enabled = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Hide Instructions after clicking the next button
    public void next()
    {
        instructionsCanvas.enabled = false;
        SpawnProjectile.shots = 5;
    }
}
