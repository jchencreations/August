using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGClickPlayer : MonoBehaviour
{
    private AudioSource clickSound;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        clickSound = GetComponent<AudioSource>();
    }

    public void click()
    {
        clickSound.Play();
    }

}
