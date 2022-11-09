using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playermovement_level2 : MonoBehaviour
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
    // Start is called before the first frame update
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

    void Start()
    {
        menu = GameObject.Find("Canvas/PauseMenu");
        myCharacterController = GetComponent<CharacterController>();
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro> ();
        count = 30;
        HealthEnemy = GameObject.Find("Ch24_nonPBR@RunningEnemy/HealthEnemy");
        objectTextEnemy = HealthEnemy.GetComponent<TextMeshPro> ();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.M)){
        Fire();
      }
        if (ducktime!=0) {
          ducktime-=1;
        }
        if (ducktime == 0) {
          transform.localScale = new Vector3(1f, 1f, 1f);
        }
      if (int.Parse(objectText.text) <= 0 || int.Parse(objectTextEnemy.text) <= 0 )
      {
        menu.SetActive(true);
        Time.timeScale = 0f;

        // *******************
        //  changeLvl2();
      }
        var currentPosition = transform.position;
        if(currentPosition == lastPosition && menu.activeInHierarchy == false){
          count++;
          // score-=1 after 60 frames if block is touched
          if (count>30 && currentPosition.x > 5){
            objectText.text = (int.Parse(objectText.text)-10).ToString();
            
            count = 0;
          }
          if(count == 30) {
            objectText.text = (int.Parse(objectText.text)-1).ToString();
            
            count = 0;
          }
        }
        else{
          count = 30;
        }
        //PlayerShoot();
        moveVector.x = speed;
        jumpUp = Input.GetKeyDown(KeyCode.Space);
        // ySpeed += Physics.gravity.y * Time.deltaTime;
        if (myCharacterController.isGrounded && jumpUp) {
          Debug.Log("Inside");
          moveVector.y = jumpSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
          ducktime = 60;
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
}
