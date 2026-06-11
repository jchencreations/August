using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorruption : MonoBehaviour
{
    [SerializeField] GameObject corruptionLocs;
    private List<GameObject> locs = new List<GameObject>();
    private List<GameObject> corruptions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //Add the locations and corruption gameobjects to corresponding lists
        for(int i = 0; i<corruptionLocs.transform.childCount;i++)
        {
            locs.Add(corruptionLocs.transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < transform.childCount; i++)
        {
            corruptions.Add(transform.GetChild(i).gameObject);
        }

        randomizeLocs();
    }

    private void Update()
    {

    }
    
    //Cycles through locs list and based on the randomized value set the location, either to the loc or the loc in it's child
    //Called when Respawn method's respawn event is invoked in inspector
    public void randomizeLocs()
    {
        for (int i = 0; i < locs.Count; i++)
        {
            int rand = Random.Range(1, 3); //returns 1 or 2
            Debug.Log(rand);

            if (rand == 1)
            {
                corruptions[i].transform.position = locs[i].transform.position;
            }
            else
            {
                corruptions[i].transform.position = locs[i].transform.GetChild(0).gameObject.transform.position;
            }
        }
    }
}
