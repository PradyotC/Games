using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongController_platform_level : MonoBehaviour
{
    AudioSource audioData;
    GameObject menu;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        menu = GameObject.Find("Canvas/PauseMenu");
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
    }
}
