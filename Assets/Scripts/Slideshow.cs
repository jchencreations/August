using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Slideshow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI wrongText;
    private GameObject currCanvas;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        wrongText.enabled = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { 

    }

    //Method to play it's slideshow
    public void playSlideshowTime()
    {
        StartCoroutine(playSlideshow());
    }

    //Method for slideshow Coroutine for waiting few seconds
    public IEnumerator playSlideshow()
    {
        audioSource.Play();

        //Disable the wrong text if it was activated
        yield return new WaitForSeconds(2);
        wrongText.enabled=false;

        //Set types of scenes for each mission, finds the object that holds three projections for that mission
        currCanvas = GameObject.Find(SceneManagerTemporal.currMission.name);
        currCanvas.SetActive(true);

        //Grab three projections from the current Canvas
        GameObject[] projections = new GameObject[3];
        for(int i = 0; i < projections.Length; i++)
        {
            projections[i] = currCanvas.transform.GetChild(i).gameObject;
        }

        //Play projections
        foreach (GameObject projection in projections) { 
            projection.SetActive(true);
            yield return new WaitForSeconds(2);
            projection.SetActive(false);
        }
        
    }


    //Method for when player is wrong
    public void wrong()
    {
        wrongText.enabled=true;
        SceneManagerTemporal.currMission.timesWrong++;
        Debug.Log("You are wrong this many times: " + SceneManagerTemporal.currMission.timesWrong);
        playSlideshowTime();
    }

    //Button methods for Cipital Room, use name from before to detect which memory is being loaded
    public void one()
    {
        if (SceneManagerTemporal.currMission.getAnswer() == 1)
        {
            audioSource.Stop();

            SceneManager.LoadScene("Platformer");
            SpawnProjectile.shots = 5;
        }
        else
        {
            wrong();
        }
    }
    public void two()
    {
        if (SceneManagerTemporal.currMission.getAnswer() == 2)
        {
            audioSource.Stop();

            SceneManager.LoadScene("Platformer");
            SpawnProjectile.shots = 5;
        }
        else
        {
            wrong();
        }
    }
    public void three()
    {
        if (SceneManagerTemporal.currMission.getAnswer() == 3)
        {
            audioSource.Stop();

            SceneManager.LoadScene("Platformer");
            SpawnProjectile.shots = 5;
        }
        else
        {
            wrong();
        }
    }
}
