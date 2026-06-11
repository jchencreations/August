using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChairButton : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    public Canvas chairCanvas;
    public Canvas projection;

    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;

        projection.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterChair()
    {
        //Switch Cameras
        cam1.enabled = false;
        cam2.enabled = true;

        //Show UI
        chairCanvas.enabled = false;
        projection.enabled = true;
    }
}
