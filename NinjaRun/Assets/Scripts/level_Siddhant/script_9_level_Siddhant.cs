using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_9_level_Siddhant : MonoBehaviour
{
    private GameObject loseMenu;
    private GameObject menu;
    private bool turnLeft, turnRight, jumpUp;
    public bool canBePressed;
    public float speed = 7.0f;
    private CharacterController myCharacterController;
    public float jumpSpeed = 10.0f;
    private float ySpeed;
    Vector3 moveVector = Vector3.zero;
    Vector3 lastPosition;
    public float gravity = 20.00f;
    public Transform LaunchOffset;
    // Start is called before the first frame update
    [SerializeField] private float _spd = 5.0f;
    [SerializeField] private float _fireRate = 1.0f;
    [SerializeField] private float _cycleTime = 0.0f;
    [SerializeField] public GameObject Bullet;
    GameObject HealthEnemy;
    public TextMeshPro objectTextEnemy;
    public int ducktime = 0;
    public int count;
    GameObject Health;
    GameObject visible;
    public TextMeshPro objectText;
      public GameObject newBulletPrefab;
    public Transform newBulletSpawn;
    public float newBulletSpeed = 15.0f;
    private float activationTime;
    private Color col;
    public KeyCode keyToPress = KeyCode.Alpha9;
    private float temp;
    private float rem;
    public string store_health;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Canvas/PauseMenu");
        myCharacterController = GetComponent<CharacterController>();
        visible=GameObject.Find("Ch24_nonPBR@Running");
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro> ();
        count = 30;
        activationTime=0;
        temp=0;
        rem=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        activationTime+=Time.deltaTime;
        if(canBePressed)
        {
            if(Input.GetKeyDown(keyToPress)){
                temp=activationTime;
                objectText.color=Color.blue;
                //gameObject.SetActive(false);
                rem=0;
            }
        }
        if(temp>0 && activationTime<=temp+3)
        {
            rem+=1;
            
            if(rem%100==0){
                Debug.Log("Yellow");
                objectText.text = (int.Parse(objectText.text)+3).ToString();

            }
            
        }
        else if(temp>0 && activationTime>temp+3)
        {
            temp=0;
            rem=0;
            objectText.color=Color.red;
            //col.a=.0f;
            //visibility.color=col;
            //store_health="";
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "segment4")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "segment4")
        {
            canBePressed = false;
        }
    }
}
