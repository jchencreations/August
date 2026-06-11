using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCorruption : Respawn //Subclass of Respawn Class in order to utilize the respawn method in the superclass (Respawn)
{
    private GameObject floor; //To access respawn script

    private MeshRenderer mesh;
    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        floor = GameObject.FindWithTag("FloorRespawn"); 

        //Hide corruption
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;

        particle = GetComponentInChildren<ParticleSystem>();
        particle.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Bullet")) //If the bullet collides, show corruption 
        {
            mesh.enabled = true;
            particle.Play();
        }
        else //If the player collides, show corruption, then respawn
        {
            mesh.enabled = true;
            particle.Play();

            //Access script from Respawn Class
            StartCoroutine(floor.GetComponent<Respawn>().RespawnMethod());

            mesh.enabled = false;
        }
    }

    //Hide corruption once bullet exits
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            mesh.enabled = false;
        }
    }
}
