using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongController : MonoBehaviour
{
    AudioSource audioData;
    GameObject menu;
    GameObject target;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        menu = GameObject.Find("Canvas/PauseMenu");
        target = GameObject.Find("Ch24_nonPBR@Running");
    }

    // Update is called once per frame
    void Update()
    {
        if(menu.activeInHierarchy == true){
            audioData.Pause();
        }
        else{
            audioData.UnPause();
        }
        /*
        if (Slow_level1.slow){
            audioData.pitch = 0.5f;
        }
        else{
            audioData.pitch = 1;
        } */
    }
}
