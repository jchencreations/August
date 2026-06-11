using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerTemporal : MonoBehaviour
{
    private Camera cam;
    public static Mission currMission;

    //List of missions endeavored
    public static List<Mission> missionsList = new List<Mission>();

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        //Checking If in Temporal Room for Object Detection
        if (SceneManager.GetActiveScene().name.Equals("Temporal"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Detect where player is clicking
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                //Detect whats the name of the gameObject, and then move to cipital room
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    //If the object is a mission object, then continue (piano is not tagged mission for now)
                    if (hitInfo.collider.gameObject.CompareTag("Mission"))
                    {
                        //Set currMision reference to a new object with specific mission
                        currMission = new Mission(hitInfo.collider.gameObject.name);
                        Debug.Log(currMission.name);

                        //Move to Cipital Room
                        SceneManager.LoadScene("Cipital");
                    }
                }
            }
        }
    }


    //Button method in Platformer Room to save data and go back to title screen
    public void endMission()
    {
        missionsList.Add(currMission);
        SceneManager.LoadScene("Title");
    }
}



//Mission class to store data: answer with name, number of deaths, number of times wrong
public class Mission
{
    public string name;
    public int timesWrong;
    public int deaths;
    public decimal time;

    public Mission(string n)
    {
        name = n;
        timesWrong = 0;
        deaths = 0;
    }

    //Change answer based on the name, which can be changed
    public int getAnswer()
    {
        //Switch case, name represents mission and has a corresponding answer.
        switch (name)
        {
            case "piano":
                return 2;
            case "camera":
                return 3;
            default: //temp
                return -1;
        }
    }

    //ToString to print all data for mission stats and display
    public string toStringMission()
    {
        return "Memory Mission: " + name + "\nYou got the flashback wrong " + timesWrong.ToString() + " times \nYou restarted the mission " + deaths.ToString() + " times \nTime: " + time + " seconds";
    }
}
