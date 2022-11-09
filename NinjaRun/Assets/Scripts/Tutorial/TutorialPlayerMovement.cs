using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TutorialPlayerMovement : MonoBehaviour
{
    private GameObject loseMenu;
    private GameObject menu;
    private bool turnLeft, turnRight, jumpUp;
    public float speed = 7.0f;
    private CharacterController myCharacterController;
    public float jumpSpeed = 10.0f;
    private float ySpeed;
    Vector3 moveVector = Vector3.zero;
    Vector3 lastPosition;
    public float gravity = 10.00f;
    public Transform LaunchOffset;
    // Start is called before the first frame update
    [SerializeField] private float _spd = 5.0f;
    [SerializeField] private float _fireRate = 1.0f;
    [SerializeField] private float _cycleTime = 0.0f;
    [SerializeField] public GameObject Bullet;

    public int ducktime = 0;
    public int count;
    GameObject Health;
    TextMeshPro objectText;
    
    bool insideIfBlock1 = false;
    bool insideIfBlock2 = false;
    bool insideIfBlock3 = false;
    bool insideIfBlock4 = false;
    void Start()
    {
        menu = GameObject.Find("Canvas/PauseMenu");
        myCharacterController = GetComponent<CharacterController>();
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro> ();
        count = 0;

    }

    // Update is called once per frame
    void Update()
    {
        jumpUp = Input.GetKeyDown(KeyCode.Space);
        var currentPosition = transform.position;
        int playerPositionx = (int)transform.position.x;
        //Debug.Log(transform.position.x);
        if (playerPositionx == 18 && !insideIfBlock1)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(transform.position.x+10, transform.position.y+3, transform.position.z);
            Time.timeScale = 0f;
            cube.AddComponent<TextMeshPro>();
            TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
            TextDisplay.text = "Press spacebar to jump! Double jump also available in the game";
            TextDisplay.fontSize = 10;
            RectTransform placement = cube.GetComponent<RectTransform>();
            //placement.sizeDelta = new Vector2(1f, 1f);
            insideIfBlock1 = true;
        }

        if (playerPositionx == 18 && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            moveVector.y = jumpSpeed;
            //insideIfBlock1 = true;
        }
        
        if ((int)transform.position.x == 38 && !insideIfBlock2)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(transform.position.x+10, transform.position.y+3, transform.position.z);
            Time.timeScale = 0f;
            cube.AddComponent<TextMeshPro>();
            TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
            TextDisplay.text = "Press left shift to duck!";
            TextDisplay.fontSize = 10;
            RectTransform placement = cube.GetComponent<RectTransform>();
            //placement.sizeDelta = new Vector2(1f, 1f);
            insideIfBlock2 = true;
            Time.timeScale = 0f;
        }
        
        if (playerPositionx == 38 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.timeScale = 1f;
            ducktime = 150;
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            //ducktime-=1;
            //insideIfBlock2 = false;
        }
        
        if ((int)transform.position.x == 59 && !insideIfBlock3)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(transform.position.x+7, transform.position.y+6.5f, transform.position.z);
            Time.timeScale = 0f;
            cube.AddComponent<TextMeshPro>();
            TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
            TextDisplay.text = "Press the key to collect points";
            

            TextDisplay.fontSize = 10;
            RectTransform placement = cube.GetComponent<RectTransform>();
            //placement.sizeDelta = new Vector2(1f, 1f);
            insideIfBlock3 = true;
        }
        
        if (playerPositionx == 59 && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1f;
            //insideIfBlock3 = false;
        }

        if ((int)transform.position.x == 70 && !insideIfBlock4)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(transform.position.x+10, transform.position.y+3, transform.position.z);
            Time.timeScale = 0f;
            cube.AddComponent<TextMeshPro>();
            TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
            TextDisplay.text = "Press M to shift Lanes! M can only be used a limited number of times!";
            TextDisplay.fontSize = 10;
            RectTransform placement = cube.GetComponent<RectTransform>();
            //placement.sizeDelta = new Vector2(1f, 1f);
            insideIfBlock4 = true;
        }
        
        if (playerPositionx == 70 && Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 1f;
            StartCoroutine(ChangeLane(0.2f));
            //ducktime-=1;
            //insideIfBlock2 = false;
        }


        if (playerPositionx == 90)
        {
            //menu.SetActive(true);
            //Time.timeScale = 0f;
            SceneManager.LoadScene(0);
        }
        
        //PlayerShoot();
        if (ducktime!=0) {
          ducktime-=1;
        }
        moveVector.x = speed;
        
        // ySpeed += Physics.gravity.y * Time.deltaTime;
        if (myCharacterController.isGrounded && jumpUp) {
          Debug.Log("Inside");
          moveVector.y = jumpSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
          ducktime = 150;
          transform.localScale = new Vector3(1f, 0.5f, 1f);
          ducktime-=1;
        }
        moveVector.y -= gravity * Time.deltaTime;
        myCharacterController.Move(moveVector * Time.deltaTime);
        if (ducktime == 0) {
          transform.localScale = new Vector3(1f, 1f, 1f);
        }
        lastPosition = currentPosition;
    }
    void PlayerShoot(){
        if (Input.GetKeyDown(KeyCode.Q)){
                Instantiate(Bullet,LaunchOffset.position,transform.rotation);

        }
    }

    public IEnumerator ChangeLane(float time) {
      //transform.eulerAngles = new Vector3(180,-90,0);
      //transform.position = new Vector3(transform.position.x,11,transform.position.z);
      //Physics.gravity = new Vector3(0,9.8f,0);
      //Debug.Log(Physics.gravity);
      if (transform.position.z>0){
        moveVector.z = -10f;
      }
      else{
        moveVector.z = 10f;
      }
      yield return new WaitForSeconds(time);
      moveVector.z = 0;
    }
}
