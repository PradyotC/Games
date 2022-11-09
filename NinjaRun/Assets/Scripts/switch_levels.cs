using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switch_levels : MonoBehaviour
{
    public void PlayTutorial(){
        SceneManager.LoadScene(1);//SceneManager.GetActiveScene().buildIndex-1);
        //Put Tutorial build number
    }
    public void PlayTutorialFast(){
        SceneManager.LoadScene(2);//SceneManager.GetActiveScene().buildIndex-1);
        //Put Tutorial build number
    }
    public void PlayTutorialSlow(){
        SceneManager.LoadScene(3);//SceneManager.GetActiveScene().buildIndex-1);
        //Put Tutorial build number
    }
    public void PlayTutorialSwitch(){
        SceneManager.LoadScene(4);//SceneManager.GetActiveScene().buildIndex-1);
        //Put Tutorial build number
    }
    public void PlayTutorialGravity(){
        SceneManager.LoadScene(5);//SceneManager.GetActiveScene().buildIndex-1);
        //Put Tutorial build number
    }
    public void PlayTutorialDash(){
        SceneManager.LoadScene(6);//SceneManager.GetActiveScene().buildIndex-1);
        //Put Tutorial build number
    }
    public void PlayTutorialRewind(){
        SceneManager.LoadScene(7);//SceneManager.GetActiveScene().buildIndex-1);
        //Put Tutorial build number
    }
    public void PlayLevel_1(){
        SceneManager.LoadScene(8);//SceneManager.GetActiveScene().buildIndex-1);

    }
    public void PlayLevel_2(){
        SceneManager.LoadScene(9);//SceneManager.GetActiveScene().buildIndex-1); Dash Level

    }
    public void PlayLevel_3(){
        SceneManager.LoadScene(10);//SceneManager.GetActiveScene().buildIndex-1);

    }
    public void PlayLevel_4(){
        SceneManager.LoadScene(11);//SceneManager.GetActiveScene().buildIndex-1); Dash Level

    }
    public void PlayLevel_5(){
        SceneManager.LoadScene(12);//SceneManager.GetActiveScene().buildIndex-1);

    }
    public void PlayLevel_6(){
        SceneManager.LoadScene(13);//SceneManager.GetActiveScene().buildIndex-1); Dash Level

    }
    public void PlayLevel_7(){
        SceneManager.LoadScene(14);//SceneManager.GetActiveScene().buildIndex-1);

    }
    public void PlayLevel_8(){
        //SceneManager.LoadScene(9);//SceneManager.GetActiveScene().buildIndex-1); Dash Level

    }
}
