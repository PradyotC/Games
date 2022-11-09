using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SScript_level_Siddhant : MonoBehaviour
{
    GameObject Health;
    TextMeshPro objectText;
    GameObject HealthEnemy;
    TextMeshPro objectTextEnemy;
    public bool canBePressed;
    public KeyCode keyToPress = KeyCode.Alpha2;

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
        if(canBePressed)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4)){
                canBePressed = false;
                //objectText.text = (int.Parse(objectText.text)-10).ToString();
            }
            else if(Input.GetKeyDown(keyToPress)){
                gameObject.SetActive(false);
                Debug.Log(Slow_level_Siddhant.slow);
                if (Slow_level_Siddhant.slow) {
                    objectText.text = (int.Parse(objectText.text)+2f).ToString();
                } 
                else if (Fast_level_Siddhant.fast) {
                    objectText.text = (int.Parse(objectText.text)+10f).ToString();
                }
                else {
                    objectText.text = (int.Parse(objectText.text)+5f).ToString();
                }

                MetricsVariables.hitsUpdate(Health.transform.position.x);
            }
            else if (Dash_level_Siddhant.dash){
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
        if(other.name == "segment5")
        {
            //Fire();
            createRandomObstacle();
            //objectText.text = (int.Parse(objectText.text)-10).ToString();
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

        cube.AddComponent<ObstacleCollision_level_Siddhant>();

        // int random = Random.Range(5,20);
        int randomY = Random.Range(0, 2);

        float playerPosition = target.transform.position.x;
        // int obstacleChoice = Random.Range(0, 4);
        int obstacleChoice = Random.Range(0, 100);
        if (obstacleChoice < 90)
        {
            cube.transform.position = new Vector3(playerPosition + 10f, target.transform.position.y + randomY * 2, target.transform.position.z);
        }
        else if (obstacleChoice >= 90)
        {
            int obstacleType = Random.Range(0, 4);
            if (obstacleType == 0)
            {
                cube.transform.position = new Vector3(playerPosition + 10f, target.transform.position.y + 4f, target.transform.position.z);
                cube.AddComponent<ObstacleMovementUp_level_Siddhant>();
            }
            else if (obstacleType == 1)
            {
                cube.transform.position = new Vector3(playerPosition + 10f, target.transform.position.y + randomY * 2, target.transform.position.z);
                cube.AddComponent<ObstacleMovementRight_level_Siddhant>();
            }
            else if (obstacleType == 2)
            {
                cube.transform.position = new Vector3(playerPosition + 10f, target.transform.position.y + 2f, target.transform.position.z);
                cube.AddComponent<ObstacleMovementSinusoidal_level_Siddhant>();
            }
            else
            {
                cube.transform.position = new Vector3(playerPosition + 10f, 3.1f, 0f);
                cube.transform.localScale = new Vector3(0.3f, 2.5f, 4f);
            }
        }
    }
}
