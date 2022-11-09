using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Pause_platform_level : MonoBehaviour
{
    public static bool isGamePaused = false;
    public static bool analytics_flag = true;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshPro endText;
    GameObject Health;
    TextMeshPro objectText;
    GameObject HealthEnemy;
    TextMeshPro objectTextEnemy;
    public TextMeshProUGUI buttonText;
    GameObject player;

    void Start()
    {
        analytics_flag = true; // redeclaring to send metrics again after restart
        startButton = GameObject.Find("Canvas/PauseMenu/ResumeGame").GetComponent<Button>();
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro>();
        player = GameObject.Find("Ch24_nonPBR@Running");
        //endText = GameObject.Find("Canvas/PauseMenu/ResumeGame/EndText");
        //HealthEnemy = GameObject.Find("Ch24_nonPBR@RunningEnemy/HealthEnemy");
        //objectTextEnemy = HealthEnemy.GetComponent<TextMeshPro>();
    }
    void Update()
    {
        // To add: endingCondition so that we can send metrics after that

        if ((int)player.transform.position.x == 400 || (int)player.transform.position.y < 0)
        {
            //startButton.gameObject.SetActive(false);
            startButton.interactable = false;
            //endText.text = objectText.text;

            // Sending Metrics
            if (analytics_flag == true)
            {
              //  SendMetrics();
            }

        }
        if (pauseMenu.activeInHierarchy == true)
        {
            Time.timeScale = 0f;
            isGamePaused = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        // Restart game metrics
        SendMetricsRQ("Restart");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseGame();
        //pauseMenu.SetActive(true);
        //Time.timeScale = 0f;
        //isGamePaused = true;
    }

    public void QuitGame()
    {
        // Quit game metrics
        SendMetricsRQ("Quit");

        //Application.Quit();
        //Debug.Log("Quit");
        SceneManager.LoadScene(0);
    }

    public void SendMetricsRQ(string restart_quit)
    {
        string level = SceneManager.GetActiveScene().name;
        string result_url = string.Format("https://docs.google.com/forms/d/e/1FAIpQLSd51OpEg73ypfQQeJ14WADO18zT_FLVZ_TKQJT2vzYEHmUDww/formResponse?usp=pp_url&entry.2147430278={0}&entry.1364687145={1}",level,restart_quit);
        StartCoroutine(GetRequest(result_url));
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}