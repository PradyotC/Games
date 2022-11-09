using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BulletBehaviour : MonoBehaviour
{
    GameObject HealthEnemy;
    TextMeshPro objectTextEnemy;
    

    void Start(){
    HealthEnemy = GameObject.Find("Ch24_nonPBR@RunningEnemy/HealthEnemy");
    objectTextEnemy = HealthEnemy.GetComponent<TextMeshPro> ();


    }
    private void OnTriggerEnter(Collider other){
        print("hit " + other.name + "!");
        print(objectTextEnemy.text);
        //objectTextEnemy.text = (int.Parse(objectTextEnemy.text)-10).ToString();
        Destroy(gameObject);
      StartCoroutine(DestryBulletAfterTime(gameObject, 1.0f));

    }

     private IEnumerator DestryBulletAfterTime(GameObject newbullet, float delay){
      yield return new WaitForSeconds(delay);
      Destroy(newbullet);
    }
}
