using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;

public class playermovement_platform_level_one : MonoBehaviour
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
    public int collectible_id = 0;
    [SerializeField] private TrailRenderer tr;  // make sure to add trailrenderer component on the player in all levels

    ////////////////////////////// Set of Variables to be changed for each level ////////////////////////////////////

    ////// variables to select active time of each pill
    private float reducedSpeedTime = 5f;
    private float increasedSpeedTime = 3f;
    private float highJumpTime = 5f;
    private float dashingTime = 0.5f;
    private float reverseSpeedTime = 4f;
    private float reverseFunctionTime = 4f;
    private float reverseGravityTime = 5f;
    private int numberOfM = 3;
    private int originalnumberOfM;


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
    public static bool isGameEnded = false;

    void Start()
    {
        originalnumberOfM = numberOfM; // for metrics
        isGameEnded = false;
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
      // Change Lane
      if (Input.GetKey(KeyCode.M) && moveVector.z == 0 && myCharacterController.isGrounded){
      // if (Input.GetKey(KeyCode.M) && moveVector.z == 0 && myCharacterController.isGrounded && numberOfM > 0){
        Debug.Log("Change Lane");
        StartCoroutine(ChangeLane(0.2f));
        numberOfM--;
      }

      if(Gravity_level1.reverseGravity){
        //StartCoroutine(ReverseGravity(reverseGravityTime));
        collectible_id = 5;
        Gravity_level1.reverseGravity = false;
      }
      // else{
      //   transform.eulerAngles = new Vector3(0,90,0);
      //   transform.position = new Vector3(transform.position.x,2,transform.position.z);
      // }

      if (Reverse_level1.reverse) {
       
        //StartCoroutine(ReverseSpeed(reverse_speed_of_player,original_speed_of_player,reverseSpeedTime));
        //Slow_level1.slow = false;
        collectible_id = 3;
        Reverse_level1.reverse = false;
      }

      /// Reduces the Speed
      if (Slow_level1.slow) {
       
        //StartCoroutine(ReduceSpeed(reduced_speed_of_player,original_speed_of_player,reducedSpeedTime));
        // Slow_level1.slow = false;
        collectible_id = 2;
        Slow_level1.slow = false;
      }

      if (Fast_level1.fast) {
       
        //StartCoroutine(IncreaseSpeed(increased_speed_of_player,original_speed_of_player,reducedSpeedTime));
        // Slow_level1.slow = false;
        collectible_id = 1;
        Fast_level1.fast = false;
      }

      /// Dashing -> increases the speed
      if (Dash_level1.dash) {
        //StartCoroutine(Dash(dashed_speed_of_player,original_speed_of_player,dashingTime));
        collectible_id = 4;
        Dash_level1.dash = false;
      }

      if (Reverse_Functionality_level1.reverseFunctionality) {
        StartCoroutine(ReverseFunctions(original_speed_of_player, reverseFunctionTime));
      }
      
      // End game condition
      if (((int)transform.position.x == 200 || (int)transform.position.y < -2) && !isGameEnded ){
            // changes
            MetricsVariables.laneSwitches = originalnumberOfM - numberOfM;
            if ((int)transform.position.x >= 200)
            {
                MetricsVariables.finished = "Yes";
            }

            menu.SetActive(true);
         GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
         cube.AddComponent<TextMeshPro>();
         ////////////////////////////For rotated view/////////////////////////////
          cube.transform.rotation= Quaternion.Euler(0f, 90, 0f);
         /////////////////////////////////////////////////////////
         TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
         TextDisplay.text = "Your Score \n"+ " "+objectText.text;
         TextDisplay.color = new Color32(15, 98, 230, 255);
         cube.transform.position = new Vector3(transform.position.x-1, 4, -2);
         TextDisplay.fontSize = 15;
         isGameEnded = true;
            // changes
            Debug.Log("-------------------Sent Metrics----------------");
            SendMetrics();
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
        if (myCharacterController.isGrounded && jumpUp && Reverse_Functionality_level1.reverseFunctionality == false && moveVector.z == 0) {
          double_jump_active = 0;
          Debug.Log("Inside");
          moveVector.y = jumpSpeed;
          double_jump_active = 1;
        }
        // Double Jump condition
        else if (jumpUp && transform.position.y<4 && (moveVector.y > 0f || moveVector.y < 0f) && Reverse_Functionality_level1.reverseFunctionality == false && double_jump_active==1) {
          Debug.Log("Double Jump");
          moveVector.y = jumpSpeed+1.25f;
          double_jump_active = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift ) && Reverse_Functionality_level1.reverseFunctionality == false) {
          ducktime = 180;
          transform.localScale = new Vector3(1f, 0.5f, 1f);
          ducktime-=1;
        }

       if (isSwitchGravity == false){
          moveVector.y -= gravity * Time.deltaTime;
          transform.eulerAngles = new Vector3(0,90,0);
        }
        //Activate Power
        if (Input.GetKey(KeyCode.N) && moveVector.z == 0 && myCharacterController.isGrounded)
        {
            //changes
            if (collectible_id != 0)
            {
                MetricsVariables.used[collectible_id - 1]++;
            }
            switch (collectible_id)
            {
                case 1:
                    StartCoroutine(IncreaseSpeed(increased_speed_of_player, original_speed_of_player, increasedSpeedTime));
                    break;
                case 2:
                    StartCoroutine(ReduceSpeed(reduced_speed_of_player, original_speed_of_player, reducedSpeedTime));
                    break;
                case 3:
                    StartCoroutine(ReverseSpeed(reverse_speed_of_player, original_speed_of_player, reverseSpeedTime));
                    break;
                case 4:
                    StartCoroutine(Dash(dashed_speed_of_player, original_speed_of_player, dashingTime));
                    break;
                case 5:
                    StartCoroutine(ReverseGravity(reverseGravityTime));
                    break;
            }
            //changes
            collectible_id = 0;
        }

        myCharacterController.Move(moveVector * Time.deltaTime);
        if (ducktime == 0) {
          transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
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
      Dash_level1.dash = false;
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
      //Slow_level1.slow = false;
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
      //Fast_level1.fast = false;
      speed = original_speed;
      audioData.pitch = 1;
      
    }
    ///////////////////////////////////////////////////////////////////////

      /////////////////////// Player Reverse Functionality //////////////////////////
    private IEnumerator ReverseFunctions(float original_speed, float time) {
      // Debug.Log()
      // tr.emitting = true;
      isSwitchControls = true;
      Reverse_Functionality_level1.reverseFunctionality = true;
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
      Reverse_Functionality_level1.reverseFunctionality = false;
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
      isReverse = true;
      yield return new WaitForSeconds(time);
      isReverse = false;
      //Reverse_level1.reverse = false;
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
      //Gravity_level1.reverseGravity = false;
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

    public void SendMetrics()
    {
        string hits = MetricsVariables.hits1 + " " + MetricsVariables.hits2 + " " + MetricsVariables.hits3;
        Debug.Log("Inside pause hits=" + hits);
        string misses = MetricsVariables.misses1 + " " + MetricsVariables.misses2 + " " + MetricsVariables.misses3;
        Debug.Log("Inside pause misses=" + misses);
        string current_player_distance = GameObject.Find("Ch24_nonPBR@Running").transform.position.x.ToString("0000.00");
        string current_player_score = int.Parse(objectText.text).ToString();
        Debug.Log("Score=" + current_player_score);
        string scoreLoss = MetricsVariables.healthLoss + "";
        Debug.Log("Score loss=" + scoreLoss);
        string scoreGain = (int.Parse(objectText.text) + MetricsVariables.healthLoss) + "";
        Debug.Log("Score loss=" + scoreGain);
        string scoreLossPowerups = MetricsVariables.healthLossSlow + " " + MetricsVariables.healthLossFast + " " + MetricsVariables.healthLossSwitchControl + " " + MetricsVariables.healthLossDash + " " + MetricsVariables.healthLossGravity + " " + MetricsVariables.healthLossNormal;
        Debug.Log("Score loss Powerups=" + scoreLossPowerups);
        string level = SceneManager.GetActiveScene().name;
        Debug.Log("Level Scene:" + level);
        string laneSwitches = MetricsVariables.laneSwitches + "";
        Debug.Log("Lane Switches=" + laneSwitches);
        string finished = MetricsVariables.finished;
        Debug.Log("Finished=" + finished);
        string pickedup = string.Join(",", MetricsVariables.pickedup);
        Debug.Log("Powerups Pickedup=" + pickedup);
        string used = string.Join(",", MetricsVariables.used);
        Debug.Log("Powerups used=" + used);
        // string result_url = string.Format("https://docs.google.com/forms/u/1/d/e/1FAIpQLSfaN_sh9mNnzY6Js8Tg4NNCiCk8jmVlfqK9ewgpcFAnsvjzMw/formResponse?usp=pp_url&entry.934111971={0}", result_string);103804370
        string result_url = string.Format("https://docs.google.com/forms/d/e/1FAIpQLSfaN_sh9mNnzY6Js8Tg4NNCiCk8jmVlfqK9ewgpcFAnsvjzMw/formResponse?usp=pp_url&entry.934111971={0}&entry.94859411={1}&entry.1163890516={2}&entry.1182508116={3}&entry.2106931590={4}&entry.617587984={5}&entry.663745722={6}&entry.799235335={7}&entry.608307081={8}&entry.2091545919={9}&entry.1419158766={10}&entry.1247731337={11}", current_player_distance, hits, misses, level, current_player_score, scoreLossPowerups, scoreLoss, scoreGain, laneSwitches, finished, pickedup, used);
        // https://docs.google.com/forms/d/e/1FAIpQLSfaN_sh9mNnzY6Js8Tg4NNCiCk8jmVlfqK9ewgpcFAnsvjzMw/viewform?usp=pp_url&entry.934111971=1&entry.94859411=1&entry.1163890516=1&entry.1182508116=1&entry.2106931590=11&entry.617587984=1&entry.663745722=1&entry.799235335=1&entry.608307081=1&entry.2091545919=11&entry.1419158766=1&entry.1247731337=1
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