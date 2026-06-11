using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnSpot;
    public Canvas respawnScreen;

    //Unity Event to tell the spawn corruption to respawn everything
    public UnityEvent respawn;

    private void Start()
    {
        player = GameObject.Find("Robot");
        respawnSpot = GameObject.Find("RespawnSpot");
        respawnScreen = GameObject.Find("Respawn").GetComponent<Canvas>();

        respawnScreen.enabled = false;
    }

    //Respawn player once they touch the bottom
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals(player.name))
        {
            //StartCoroutine used to activate wait 
            StartCoroutine(RespawnMethod());
            
        }
    }

    //Put as separate Method of type IEnumerator to use the Coroutine which lets you wait 
    public IEnumerator RespawnMethod()
    {
        respawnScreen.enabled = true;
        player.SetActive(false);

        yield return new WaitForSeconds(2);
        respawnScreen.enabled = false;

        //Reset shots #
        SpawnProjectile.shots = 5;

        player.SetActive(true);
        player.transform.position = respawnSpot.transform.position;

        //Update number of deaths for the mission object
        SceneManagerTemporal.currMission.deaths++;
        Debug.Log("Deaths: " + SceneManagerTemporal.currMission.deaths);

        //Trigger UnityEvent
        respawn.Invoke();
    }
}
