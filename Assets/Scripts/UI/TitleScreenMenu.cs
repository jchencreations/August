using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] Canvas titleCanvas;
    [SerializeField] Canvas statsCanvas;
    [SerializeField] Canvas settingsCanvas;

    [SerializeField] TextMeshProUGUI statToInstantiate;
    [SerializeField] GameObject statsContainer;

    // Start is called before the first frame update
    void Start()
    {
        titleCanvas.enabled = true;
        statsCanvas.enabled = false;
        settingsCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton()
    {
        SceneManager.LoadScene("Temporal");
    }

    public void statsButton()
    {
        //If there are missions, then:
        if(SceneManagerTemporal.missionsList.Count > 0)
        {
            //Cycles through all missions, creates a new text object, makes it a child of the container
            for(int i = 0; i<SceneManagerTemporal.missionsList.Count; i++)
            {
                TextMeshProUGUI stat;
                if (statToInstantiate != null)
                {
                    stat = Instantiate(statToInstantiate);
                    stat.transform.SetParent(statsContainer.transform);
                    stat.text = "#" + (i+1) + ": " + SceneManagerTemporal.missionsList[i].toStringMission();
                }
            }
        }
        //No missions, display on mission data
        else
        {
            TextMeshProUGUI stat;
            stat = Instantiate(statToInstantiate);
            stat.transform.SetParent(statsContainer.transform);
            stat.text = "No Mission Data";
        }
       

        titleCanvas.enabled = false;
        statsCanvas.enabled = true;
        settingsCanvas.enabled = false;
    }

    public void settingsButton()
    {
        titleCanvas.enabled = false;
        statsCanvas.enabled = false;
        settingsCanvas.enabled = true;
    }

    public void introButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void homeButton()
    {
        //If we are returning home from the Stats screen, destroy all data created by creating a list of the children and destroying them
        if(statsCanvas.enabled)
        {
            GameObject[] missions = new GameObject[statsContainer.transform.childCount];
            for(int i = 0; i < missions.Length; i++)
            {
                missions[i] = statsContainer.transform.GetChild(i).gameObject;
            }
            foreach(GameObject mission in missions)
            {
                Destroy(mission);
            }
        }

        //Return to title screen
        titleCanvas.enabled = true;
        statsCanvas.enabled = false;
        settingsCanvas.enabled = false;
    }


    public void quitButton()
    {
        Application.Quit();
    }

}
