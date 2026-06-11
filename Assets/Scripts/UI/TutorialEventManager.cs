using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEventManager : MonoBehaviour
{
    public Canvas interact;
    public GameObject instructions;
    public GameObject dialogue;
    private int dialogueCount = 0;

    //Animation boolean for activating talk, and animator
    private bool talking;
    public Animator animator;

    //AudioPlay
    [SerializeField] GameObject beepboop;


    // Start is called before the first frame update
    void Start()
    {
        interact.enabled = true;
        instructions.SetActive(false);

        talking = false;
        animator.SetBool("talking", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Activated when talk button is clicked
    public void talk()
    {
        interact.enabled = false;
        instructions.SetActive(true);

        //Set first dialogue to be active
        dialogue.transform.GetChild(0).gameObject.SetActive(true);

        //Animation
        talking = true;
        animator.SetBool("talking", true);

        //Begin Audio
        beepboop.GetComponent<AudioSource>().Play();
    }

    //Next and back button cycles through dialogue
    public void next()
    {
        //Cycle through dialogue without out of bounds error
        if (dialogueCount<dialogue.transform.childCount-1)
        {
            dialogue.transform.GetChild(dialogueCount).gameObject.SetActive(false);
            dialogue.transform.GetChild(dialogueCount+1).gameObject.SetActive(true);
            dialogueCount++;
        }
        else
        {
            //Once we reach end of dialogue, exit to title screen
            SceneManager.LoadScene("Title");
        }
    }
    public void back()
    {
        //Cycle through dialogue without out of bounds error
        if (dialogueCount > 0)
        {
            dialogue.transform.GetChild(dialogueCount).gameObject.SetActive(false);
            dialogue.transform.GetChild(dialogueCount-1).gameObject.SetActive(true);
            dialogueCount--;
        }
    }
}
