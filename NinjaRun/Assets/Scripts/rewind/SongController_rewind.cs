using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongController_rewind : MonoBehaviour
{
    AudioSource audioData;
    GameObject menu;
    GameObject target;
    static public bool test = false; ////////test variable

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
        if(menu.activeInHierarchy == true || test){
            audioData.Pause();
        }
        else{
            audioData.UnPause();
        }
        /*
        if (Slow_rewind.slow){
            audioData.pitch = 0.5f;
        }
        else{
            audioData.pitch = 1;
        } */
    }
}
