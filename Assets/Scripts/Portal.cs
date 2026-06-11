using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Portal : MonoBehaviour
{
    private Collider portalCol;
    public Canvas endCanvas;
    public TextMeshProUGUI endData;

    //Timer
    public float timer;
    public bool timeBool = true;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        portalCol = GetComponent<Collider>();

        endCanvas.enabled = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Platformer") && timeBool)
        {
            timer += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If player activates portal with projectile, go back to temporal room and end mission
        if (collision.gameObject.name.Equals("FlashingLight(Clone)")) {
            audioSource.Play();

            //End Timer and add to mission
            timeBool = false;
            SceneManagerTemporal.currMission.time = Math.Round((decimal)timer, 2);

            //Show Mission Results
            endData.text = SceneManagerTemporal.currMission.toStringMission();
            endCanvas.enabled = true;
        }
    }
}
