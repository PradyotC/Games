using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AScript_platform_level_two : MonoBehaviour
{
    GameObject Health;
    TextMeshPro objectText;
    GameObject HealthEnemy;
    TextMeshPro objectTextEnemy;
    public bool canBePressed;
    public KeyCode keyToPress = KeyCode.Q;
    public GameObject newBulletPrefab;
    public Transform newBulletSpawn;
    public float newBulletSpeed = 100.0f;
    public GameObject target;
    BoxCollider cubeBox;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Ch24_nonPBR@Running");
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro> ();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= transform.right*5f*Time.deltaTime;
        if(canBePressed)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) ){
                canBePressed = false;
                //objectText.text = (int.Parse(objectText.text)-1).ToString();
            }
            else if(Input.GetKeyDown(keyToPress)){
                gameObject.SetActive(false);
                if (playermovement_platform_level_two.isSlow) {
                    objectText.text = (int.Parse(objectText.text)+2f).ToString();
                } 
                else if (playermovement_platform_level_two.isFast) {
                    objectText.text = (int.Parse(objectText.text)+10f).ToString();
                }
                else {
                    objectText.text = (int.Parse(objectText.text)+5f).ToString();
                }

                MetricsVariables.hitsUpdate(Health.transform.position.x);
            }
            else if (playermovement_platform_level_two.isDashing){
                objectText.text = (int.Parse(objectText.text)+5f).ToString();
                canBePressed = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "segment4")
        {
            canBePressed = true;
        }
        if(other.name == "segment5" && !playermovement_platform_level_two.isDashing && !playermovement_platform_level_two.isSwitchGravity)
        {
            //Fire();
            GenerateNodes_platform_level_two.cnt+=1;
            if (GenerateNodes_platform_level_two.cnt == 5){
                createRandomObstacle();
                GenerateNodes_platform_level_two.cnt=0;
            }
            //objectText.text = (int.Parse(objectText.text)-1).ToString();
            MetricsVariables.missesUpdate(Health.transform.position.x);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "segment4")
        {
            canBePressed = false;
        }
    }

     private void Fire(){
      GameObject newbullet = Instantiate(newBulletPrefab);
      Physics.IgnoreCollision(newbullet.GetComponent<Collider>(), newBulletSpawn.parent.GetComponent<Collider>());

      newbullet.transform.position = newBulletSpawn.position;
      Vector3 rotation = newbullet.transform.rotation.eulerAngles;

      newbullet.transform.rotation = Quaternion.Euler(rotation.x,rotation.y ,transform.eulerAngles.z);

      newbullet.GetComponent<Rigidbody>().AddForce(newBulletSpawn.up*newBulletSpeed, ForceMode.Impulse);

      StartCoroutine(DestryBulletAfterTime(newbullet, 0.6f));
    }

     private IEnumerator DestryBulletAfterTime(GameObject newbullet, float delay){
      yield return new WaitForSeconds(delay);
      Destroy(newbullet);
    }

    private void createRandomObstacle(){
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeBox = cube.GetComponent<BoxCollider>();
        cubeBox.isTrigger = true;

        cube.AddComponent<ObstacleCollision_level1>();

        // int random = Random.Range(5,20);
        int randomY = Random.Range(0, 2);
        int obstacleType = Random.Range(0, 3);

        float playerPosition = target.transform.position.x;
        // int obstacleChoice = Random.Range(0, 4);

        if (obstacleType == 0)
        {
            cube.transform.position = new Vector3(playerPosition + 10f, 2 + randomY * 2, target.transform.position.z);
        }
        else if (obstacleType == 1)
        {
            cube.transform.position = new Vector3(playerPosition + 10f, 2 + 4f, target.transform.position.z);
            cube.AddComponent<ObstacleMovementUp_level1>();
        }
        else if (obstacleType == 2)
        {
            cube.transform.position = new Vector3(playerPosition + 10f, 2 + 0.25f, target.transform.position.z);
            cube.AddComponent<ObstacleMovementRight_level1>();
        }
        else if (obstacleType == 3)
        {
            cube.transform.position = new Vector3(playerPosition + 10f, 2 + 2f, target.transform.position.z);
            cube.AddComponent<ObstacleMovementSinusoidal_level1>();
        }

        else if (obstacleType == 4){
            cube.transform.position = new Vector3(playerPosition + 10f, 3.1f, 0f);
            cube.transform.localScale = new Vector3(0.3f, 2.5f, 4f);
        }
    }
}
