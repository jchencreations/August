using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGAudio : MonoBehaviour
{
    private static AudioSource audioSource;

    //Keep bg audio playing seamlessly through scenes
    private void Awake()
    {   
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }
}
