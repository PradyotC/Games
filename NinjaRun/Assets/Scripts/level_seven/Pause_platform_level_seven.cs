using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Pause_platform_level_seven : MonoBehaviour
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
        MetricsVariables.distance = 500;
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

        if ((int)player.transform.position.x == 500 || (int)player.transform.position.y < -2)
        {
            //startButton.gameObject.SetActive(false);
            startButton.interactable = false;
            //endText.text = objectText.text;

            // Sending Metrics
            if (analytics_flag == true)
            {
                // Debug.Log("-------------------Sent Metrics----------------");
                // SendMetrics();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseGame();
        //pauseMenu.SetActive(true);
        //Time.timeScale = 0f;
        //isGamePaused = true;
    }

    public void QuitGame()
    {
        //Application.Quit();
        //Debug.Log("Quit");
        SceneManager.LoadScene(0);
    }

    public void SendMetrics()
    {
        string hits = MetricsVariables.hits1 + " " + MetricsVariables.hits2 + " " + MetricsVariables.hits3;
        Debug.Log("Inside pause hits=" + hits);
        string misses = MetricsVariables.misses1 + " " + MetricsVariables.misses2 + " " + MetricsVariables.misses3;
        Debug.Log("Inside pause misses=" + misses);
        string current_player_distance = GameObject.Find("Ch24_nonPBR@Running").transform.position.x.ToString("0000.00");
        string current_player_score = int.Parse(objectText.text).ToString();
        Debug.Log("Score=" + current_player_score);
        string scoreLoss = MetricsVariables.healthLoss+"";
        Debug.Log("Score loss=" + scoreLoss);
        string scoreGain = (int.Parse(objectText.text) + MetricsVariables.healthLoss)+"";
        Debug.Log("Score loss=" + scoreGain);
        string scoreLossPowerups = MetricsVariables.healthLossSlow + " " + MetricsVariables.healthLossFast + " " + MetricsVariables.healthLossSwitchControl + " " + MetricsVariables.healthLossDash + " " + MetricsVariables.healthLossGravity + " " + MetricsVariables.healthLossNormal;
        Debug.Log("Score loss Powerups=" + scoreLossPowerups);
        string level = SceneManager.GetActiveScene().name;
        Debug.Log("Level Scene:" + level);
        string laneSwitches = MetricsVariables.laneSwitches + "";
        Debug.Log("Lane Switches=" + laneSwitches);
        // string result_url = string.Format("https://docs.google.com/forms/u/1/d/e/1FAIpQLSfaN_sh9mNnzY6Js8Tg4NNCiCk8jmVlfqK9ewgpcFAnsvjzMw/formResponse?usp=pp_url&entry.934111971={0}", result_string);103804370
        string result_url = string.Format("https://docs.google.com/forms/d/e/1FAIpQLSfaN_sh9mNnzY6Js8Tg4NNCiCk8jmVlfqK9ewgpcFAnsvjzMw/formResponse?usp=pp_url&entry.934111971={0}&entry.94859411={1}&entry.1163890516={2}&entry.1182508116={3}&entry.2106931590={4}&entry.617587984={5}&entry.663745722={6}&entry.799235335={7}&entry.608307081={8}", current_player_distance, hits, misses, level, current_player_score, scoreLossPowerups, scoreLoss, scoreGain, laneSwitches);
        // https://docs.google.com/forms/d/e/1FAIpQLSfaN_sh9mNnzY6Js8Tg4NNCiCk8jmVlfqK9ewgpcFAnsvjzMw/formResponse?usp=pp_url&entry.934111971=0&entry.94859411=1&entry.1163890516=2&entry.1182508116=3&entry.2106931590=4&entry.617587984=5
        // https://docs.google.com/forms/d/e/1FAIpQLSfaN_sh9mNnzY6Js8Tg4NNCiCk8jmVlfqK9ewgpcFAnsvjzMw/viewform?usp=pp_url&entry.934111971=1&entry.94859411=1&entry.1163890516=1&entry.1182508116=11&entry.2106931590=1&entry.617587984=1&entry.663745722=1&entry.799235335=1&entry.608307081=1
        StartCoroutine(GetRequest(result_url));
        analytics_flag = false;
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