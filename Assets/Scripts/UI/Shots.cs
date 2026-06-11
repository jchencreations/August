using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shots : MonoBehaviour
{
    public TextMeshProUGUI shotsNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotsNum.text = SpawnProjectile.shots.ToString();

    }
}
