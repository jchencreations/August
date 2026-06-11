using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Renderer rend;
    private AudioSource click;
    
    // Start is called before the first frame update
    void Start()
    {
        rend.enabled = false;

        click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        click.Play();
        rend.enabled = true;
    }
    private void OnMouseExit()
    {
        rend.enabled = false;
    }
}
