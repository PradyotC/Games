using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playermovement_level_gravity : MonoBehaviour
{


    public static int collectible_id=0;


    private GameObject loseMenu;
    private GameObject menu;
    private bool turnLeft, turnRight, jumpUp;
    public float speed = 7.0f;
    private CharacterController myCharacterController;
    public float jumpSpeed = 10.0f;
    private float ySpeed;
    Vector3 moveVector = Vector3.zero;
    Vector3 lastPosition;
    public float gravity = 20.00f;
    public Transform LaunchOffset;
    [SerializeField] private float _spd = 5.0f;
    [SerializeField] private float _fireRate = 1.0f;
    [SerializeField] private float _cycleTime = 0.0f;
    [SerializeField] public GameObject Bullet;
    GameObject HealthEnemy;
    TextMeshPro objectTextEnemy;
    public int ducktime = 0;
    public int count;
    GameObject Health;
    TextMeshPro objectText;
    public GameObject newBulletPrefab;
    public Transform newBulletSpawn;
    public float newBulletSpeed = 15.0f;
    AudioSource audioData;
    private Vector3 previousVector;
    [SerializeField] private TrailRenderer tr;  // make sure to add trailrenderer component on the player in all levels

    ////////////////////////////// Set of Variables to be changed for each level ////////////////////////////////////

    ////// variables to select active time of each pill
    private float reducedSpeedTime = 5f;
    private float increasedSpeedTime = 3f;
    private float highJumpTime = 5f;
    private float dashingTime = 2f;
    private float reverseSpeedTime = 4f;
    private float reverseFunctionTime = 4f;
    private float reverseGravityTime = 5f;


    //// Do not change these variables <please>
    private float original_speed_of_player = 10f;  // make sure this is equal to above speed varibale
    private float reduced_speed_of_player = 5f;
    private float original_gravity_of_game = 20f;  // make sure this is equal to above gravity variable
    private float reduced_gravity_of_game = -20f;
    private float dashed_speed_of_player = 30f;
    private float reverse_speed_of_player = -10f;
    private float increased_speed_of_player = 20f;
    private float double_jump_active = 0;


    //////////////////////////////////// Varibales to be changed for each level ^^  /////////////////////////


    public static bool isSlow = false;
    public static bool isFast = false;
    public static bool isReverse = false;
    public static bool isDashing = false;
    public static bool canDash = true;
    public static bool isHighJump = false;
    public static bool isShield = false;
    public static bool isSwitchGravity = false;
    public static bool isSwitchControls = false;



///////////////////////////////////////////////////////////

public static bool dash_tutorial=true;
GameObject dash_cube;
public static bool dash_tutorial_launch=true;
GameObject dash_cube_launch;

//////////////////////////////////////////////////////////

    void Start()
    {
        audioData = GameObject.Find("Song").GetComponent<AudioSource>();
        audioData.Play(0);
        menu = GameObject.Find("Canvas/PauseMenu");
        myCharacterController = GetComponent<CharacterController>();
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro> ();
        count = 30;
        tr = GameObject.Find("Ch24_nonPBR@Running").GetComponent<TrailRenderer>();

    }

    // Update is called once per frame
    void Update()
    {


      if ((int)transform.position.x == 25 && dash_tutorial)
      {
        audioData.Pause();
        dash_cube=GameObject.CreatePrimitive(PrimitiveType.Cube);
          Time.timeScale = 0f;
          dash_tutorial=false;
          dash_cube.AddComponent<TextMeshPro>();
          TextMeshPro TextDisplay = dash_cube.GetComponent<TextMeshPro>();
          TextDisplay.text = "Changes gravity, Press Enter to continue";
          TextDisplay.fontSize = 10;
          TextDisplay.color = new Color32(255, 128, 0, 255);
          RectTransform placement = dash_cube.GetComponent<RectTransform>();
          dash_cube.transform.position = new Vector3(transform.position.x+7, transform.position.y+6, transform.position.z);
          //placement.sizeDelta = new Vector2(1f, 1f);

      }

        if ((int)transform.position.x == 25 && Input.GetKeyDown(KeyCode.Return))
        {
        audioData.UnPause();
            Time.timeScale = 1f;
            Destroy(dash_cube);
        }


      if ((int)transform.position.x == 40 && dash_tutorial_launch)
      {
        audioData.Pause();
        dash_cube_launch=GameObject.CreatePrimitive(PrimitiveType.Cube);
          Time.timeScale = 0f;
          dash_tutorial_launch=false;
          dash_cube_launch.AddComponent<TextMeshPro>();
          TextMeshPro TextDisplay = dash_cube_launch.GetComponent<TextMeshPro>();
          TextDisplay.text = "Press N to use Gravity";
          TextDisplay.fontSize = 10;
          TextDisplay.color = new Color32(255, 128, 0, 255);
          RectTransform placement = dash_cube_launch.GetComponent<RectTransform>();
          dash_cube_launch.transform.position = new Vector3(transform.position.x+7, transform.position.y+3, transform.position.z);

      }

        if ((int)transform.position.x == 40 && Input.GetKeyDown(KeyCode.N))
        {
        audioData.UnPause();
            Time.timeScale = 1f;
            Destroy(dash_cube_launch);
          if (Input.GetKeyDown(KeyCode.J) && collectible_id==1 && Dash_level_dash.dash){
          StartCoroutine(IncreaseSpeed(dashed_speed_of_player,original_speed_of_player,dashingTime));
          Dash_level_dash.dash=false;
          collectible_id=0;
        }
        }



  


      if (Input.GetKey(KeyCode.M) && moveVector.z == 0 && myCharacterController.isGrounded){
        Debug.Log("Change Lane");
        StartCoroutine(ChangeLane(0.2f));
      }
      if(Gravity_level_dash.reverseGravity && transform.position.x > 40){
        StartCoroutine(ReverseGravity(reverseGravityTime));
      }
      else{
        transform.eulerAngles = new Vector3(0,90,0);
        transform.position = new Vector3(transform.position.x,2,transform.position.z);
      }

      if (Reverse_level_dash.reverse) {
       
        StartCoroutine(ReverseSpeed(reverse_speed_of_player,original_speed_of_player,reverseSpeedTime));
        //Slow_level_dash.slow = false;
      }

      /// Reduces the Speed
      // if (Slow_level_dash.slow) {
       
      //   StartCoroutine(ReduceSpeed(reduced_speed_of_player,original_speed_of_player,reducedSpeedTime));
      //   // Slow_level_dash.slow = false;
      // }

      // if (Fast_level_dash.fast) {
       
      //   StartCoroutine(IncreaseSpeed(increased_speed_of_player,original_speed_of_player,reducedSpeedTime));
      //   // Slow_level_dash.slow = false;
      // }

      /// Dashing -> increases the speed
      
       if (Input.GetKeyDown(KeyCode.N) && Slow_level_dash.slow){
          StartCoroutine(ReduceSpeed(reduced_speed_of_player,original_speed_of_player,reducedSpeedTime));
          Fast_level_dash.fast=false;
          collectible_id=0;
        }


      // if (Dash_level_dash.dash) {
      //   StartCoroutine(Dash(dashed_speed_of_player,original_speed_of_player,dashingTime));
      // }

      ////////////////////////////////////////////////////////

      if (Reverse_Functionality_level_dash.reverseFunctionality) {
        StartCoroutine(ReverseFunctions(original_speed_of_player, reverseFunctionTime));
      }

      if ((int)transform.position.x == 90){
        menu.SetActive(true);
      }


        if (ducktime!=0) {
          ducktime-=1;
        }
        if (ducktime == 0) {
          transform.localScale = new Vector3(1f, 1f, 1f);
        }

        moveVector.x = speed;
        jumpUp = Input.GetKeyDown(KeyCode.Space);
        // ySpeed += Physics.gravity.y * Time.deltaTime;
        if (myCharacterController.isGrounded && jumpUp && Reverse_Functionality_level_dash.reverseFunctionality == false && moveVector.z == 0) {
          double_jump_active = 0;
          Debug.Log("Inside");
          moveVector.y = jumpSpeed;
          double_jump_active = 1;
        }
        // Double Jump condition
        else if (jumpUp && transform.position.y<4 && (moveVector.y > 0f || moveVector.y < 0f) && Reverse_Functionality_level_dash.reverseFunctionality == false && double_jump_active==1) {
          Debug.Log("Double Jump");
          moveVector.y = jumpSpeed+1.25f;
          double_jump_active = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift ) && Reverse_Functionality_level_dash.reverseFunctionality == false) {
          ducktime = 180;
          transform.localScale = new Vector3(1f, 0.5f, 1f);
          ducktime-=1;
        }

       if (isSwitchGravity == false){
          moveVector.y -= gravity * Time.deltaTime;
        }

        myCharacterController.Move(moveVector * Time.deltaTime);
        if (ducktime == 0) {
          transform.localScale = new Vector3(1f, 1f, 1f);
        }

      //   if (Input.GetKeyDown(KeyCode.B)){
      //   Debug.Log("Change Lane");
      //   //transform.position = new Vector3(transform.position.x, transform.position.y, 0-transform.position.z);
      // }
        
    }
    void PlayerShoot(){
        if (Input.GetKeyDown(KeyCode.P)){
                Instantiate(Bullet,LaunchOffset.position,transform.rotation);

        }
    }
    void changeLvl2(){
        if (int.Parse(objectTextEnemy.text) <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        if (int.Parse(objectText.text) <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }
    }

    private void Fire(){
      GameObject newbullet = Instantiate(newBulletPrefab);
      Physics.IgnoreCollision(newbullet.GetComponent<Collider>(), newBulletSpawn.parent.GetComponent<Collider>());

      newbullet.transform.position = newBulletSpawn.position;
      Vector3 rotation = newbullet.transform.rotation.eulerAngles;

      newbullet.transform.rotation = Quaternion.Euler(rotation.x,rotation.y ,transform.eulerAngles.z);

      newbullet.GetComponent<Rigidbody>().AddForce(newBulletSpawn.up*newBulletSpeed, ForceMode.Impulse);

      StartCoroutine(DestryBulletAfterTime(newbullet, 3.0f));
    }

    private IEnumerator DestryBulletAfterTime(GameObject newbullet, float delay){
      yield return new WaitForSeconds(delay);
      Destroy(newbullet);
    }

    /// NOTE : -->  Start Copying These Templates for all levels

    //////////////////////////////// Dashing Routine ////////////////////////////
    private IEnumerator Dash(float new_speed, float original_speed, float time) {
      canDash = false;
      isDashing = true;
      speed = new_speed;
      tr.emitting = true;
      audioData.pitch = new_speed/original_speed;
      yield return new WaitForSeconds(time);
      tr.emitting = false;
      Dash_level_dash.dash = false;
      speed = original_speed;
      audioData.pitch = 1f;
      isDashing = false;
      canDash = true;
    } 
    
    /////////////////////////////////////////////////////////////////////////////

    /////////////////////////// Player Speed Reducer //////////////////////////
    private IEnumerator ReduceSpeed(float new_speed, float original_speed, float time) {
      isSlow = true;
      speed = new_speed;
      audioData.pitch = 0.5f;
      yield return new WaitForSeconds(time);
      Debug.Log("Normal Speed Again");
      Slow_level_dash.slow = false;
      speed = original_speed;
      audioData.pitch = 1;
      isSlow = false;
    }
    
    //////////////////////////////////////////////////////////////////////////

    /////////////////////// Player Speed Increase //////////////////////////
    private IEnumerator IncreaseSpeed(float new_speed, float original_speed, float time) {
        // Debug.Log()
      isFast = true;
      speed = new_speed;
      audioData.pitch = new_speed/original_speed;
      tr.emitting = true;
      yield return new WaitForSeconds(time);
      isFast = false;
      Debug.Log("Normal Speed Again");
      tr.emitting = false;
      Fast_level_dash.fast = false;
      speed = original_speed;
      audioData.pitch = 1;
      
    }
    ///////////////////////////////////////////////////////////////////////

      /////////////////////// Player Reverse Functionality //////////////////////////
    private IEnumerator ReverseFunctions(float original_speed, float time) {
      // Debug.Log()
      // tr.emitting = true;
      isSwitchControls = true;
      Reverse_Functionality_level_dash.reverseFunctionality = true;
      speed = original_speed;
       
       if (ducktime!=0) {
          ducktime-=1;
      }
      if (ducktime == 0) {
          transform.localScale = new Vector3(1f, 1f, 1f);
      }
       
      jumpUp = Input.GetKeyDown(KeyCode.Space);
      var LeftShift = Input.GetKeyDown(KeyCode.LeftShift);
      if (myCharacterController.isGrounded && LeftShift) {
        Debug.Log("Inside");
        transform.localScale = new Vector3(1f, 1f, 1f);

        moveVector.y = jumpSpeed + 5f;
      }
      if (jumpUp) {
        ducktime = 180;
        transform.localScale = new Vector3(1f, 0.5f, 1f);
        ducktime-=1;
      }
      moveVector.y -= gravity * Time.deltaTime;
      // myCharacterController.Move(moveVector * Time.deltaTime);
      if (ducktime == 0) {
        transform.localScale = new Vector3(1f, 1f, 1f);
      }


      Debug.Log("Reverse Functionality activated");
      speed = original_speed;

      yield return new WaitForSeconds(time);
      TextMeshPro reverseText =  GameObject.Find("ReverseText").GetComponent<TextMeshPro> ();
      GameObject player = GameObject.Find("Ch24_nonPBR@Running");
      reverseText.transform.position = new Vector3(153.5f + time*speed + 8f, -19f, -3.81f);
      reverseText.text = "Back Normal";
      // reverseText.fontSize = 0.50f;
      isSwitchControls = false;  

      yield return new WaitForSeconds(0.5f);
      reverseText.text = "";

      speed = original_speed;

      Debug.Log("Reverse Functionality Over");
      // tr.emitting = false;
      Reverse_Functionality_level_dash.reverseFunctionality = false;
      speed = original_speed;
      // speed = original_speed;
      // audioData.pitch = 1;
    }
    ///////////////////////////////////////////////////////////////////////

    ///////////////////////////// Player High Jump////////////////////////
    private IEnumerator HighJump() {
      gravity = -20f;
      yield return new WaitForSeconds(highJumpTime);
      gravity = 20f;
    }
    //////////////////////////////////////////////////////////////////////

public IEnumerator ReverseSpeed(float new_speed, float original_speed, float time) {
      speed = new_speed;
      audioData.pitch = new_speed/original_speed;
      yield return new WaitForSeconds(time);
      Reverse_level_dash.reverse = false;
      speed = original_speed;
      audioData.pitch = 1f;
    }

public IEnumerator ReverseGravity(float time) {
      transform.eulerAngles = new Vector3(180,-90,0);
      //transform.position = new Vector3(transform.position.x,11,transform.position.z);
      //Physics.gravity = new Vector3(0,9.8f,0);
      //Debug.Log(Physics.gravity);
      moveVector.y = 11;
      transform.position = new Vector3(transform.position.x,11,transform.position.z);
      isSwitchGravity = true;
      yield return new WaitForSeconds(time);
      isSwitchGravity = false;
      Gravity_level_dash.reverseGravity = false;
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