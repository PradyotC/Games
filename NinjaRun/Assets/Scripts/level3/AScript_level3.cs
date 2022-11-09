using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AScript_level3 : MonoBehaviour
{
    GameObject Health;
    TextMeshPro objectText;
    GameObject HealthEnemy;
    TextMeshPro objectTextEnemy;
    public bool canBePressed;
    public KeyCode keyToPress = KeyCode.Alpha3;
    public GameObject newBulletPrefab;
    public Transform newBulletSpawn;
    public float newBulletSpeed = 100.0f;
    public Transform newPlayerBulletSpawn;

    

    // Start is called before the first frame update
    void Start()
    {
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro> ();
        HealthEnemy = GameObject.Find("Ch24_nonPBR@RunningEnemy/HealthEnemy");
        objectTextEnemy = HealthEnemy.GetComponent<TextMeshPro> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(canBePressed)
        {
            if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha1)){
                canBePressed = false;
                objectText.text = (int.Parse(objectText.text)-10).ToString();
                Fire();
            }
            else if(Input.GetKeyDown(keyToPress)){
                 gameObject.SetActive(false);
                 objectTextEnemy.text = (int.Parse(objectTextEnemy.text)-10).ToString();
                PlayerFire();
                MetricsVariables.hits++;

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
            Fire();
            objectText.text = (int.Parse(objectText.text)-10).ToString();
            MetricsVariables.misses++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "segment3")
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

    
    private void PlayerFire(){
      GameObject newbullet = Instantiate(newBulletPrefab);
      Physics.IgnoreCollision(newbullet.GetComponent<Collider>(), newPlayerBulletSpawn.parent.GetComponent<Collider>());

      newbullet.transform.position = newPlayerBulletSpawn.position;
      Vector3 rotation = newbullet.transform.rotation.eulerAngles;

      newbullet.transform.rotation = Quaternion.Euler(rotation.x,rotation.y ,transform.eulerAngles.z);

      newbullet.GetComponent<Rigidbody>().AddForce(newPlayerBulletSpawn.up*newBulletSpeed, ForceMode.Impulse);

      StartCoroutine(DestryBulletAfterTime(newbullet, 0.6f));
    }
     private IEnumerator DestryBulletAfterTime(GameObject newbullet, float delay){
      yield return new WaitForSeconds(delay);
      Destroy(newbullet);
    }
}
