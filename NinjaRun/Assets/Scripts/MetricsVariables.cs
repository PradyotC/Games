using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetricsVariables : MonoBehaviour
{
    public static int hits; // kept just to clear errors
    public static int misses; // kept just to clear errors

    // hits and misses per 1/3rd meters per level (needs dynamic distance initialization below)
    public static int hits1; // first 1/3rd
    public static int hits2; // second 1/3rd
    public static int hits3; // third 1/3rd
    public static int misses1; // first 1/3rd
    public static int misses2; // second 1/3rd
    public static int misses3; // third 1/3rd

    // health loss per powerup
    public static int healthLoss;
    public static int healthLossSlow;
    public static int healthLossFast;
    public static int healthLossSwitchControl; // when controls are switched
    public static int healthLossDash;
    public static int healthLossGravity;
    public static int healthLossNormal;

    // get song distance
    public static int distance;
    public static float dist1, dist2;

    // lane switches
    public static int laneSwitches;

    // lane switches
    public static string finished;

    // powerups picked up and powerups used order: (Fast, Slow, Rewind, Dash, ReverseGravity)
    public static int[] pickedup; // (Fast, Slow, Rewind, Dash, ReverseGravity, ReverseControls)
    public static int[] used; // (Fast, Slow, Rewind, Dash, ReverseGravity)

    // Start is called before the first frame update
    void Start()
    {
        hits1 = 0;
        hits2 = 0;
        hits3 = 0;
        misses1 = 0;
        misses2 = 0;
        misses3 = 0;
        healthLoss = 0;
        healthLossSlow = 0;
        healthLossFast = 0;
        healthLossSwitchControl = 0;
        healthLossDash = 0;
        healthLossGravity = 0;
        healthLossNormal = 0;
        switch (SceneManager.GetActiveScene().name)
        {
            case "level_one":
                distance = 200;
                break;
            case "level_two":
                distance = 370; ;
                break;
            case "level_three":
                distance = 350;
                break;
            case "level_four":
                distance = 350;
                break;
            case "level_five":
                distance = 335;
                break;
            case "level_six":
                distance = 500;
                break;
            case "level_seven":
                distance = 500;
                break;
            default:
                distance = 335;
                break;
        }
        dist1 = distance / 3;
        dist2 = (2 * distance) / 3;
        Debug.Log(dist1+" " +dist2+" "+distance);
        laneSwitches = 0;
        finished = "No";
        pickedup = new int[6];
        used = new int[5];
}

    // Update is called once per frame
    void Update()
    {

    }

    public static void hitsUpdate(float location)
    {
        if (location < dist1)
        {
            hits1++;
        }
        else if (dist1 <= location && location < dist2)
        {
            hits2++;
        }
        else
        {
            hits3++;
        }
    }

    public static void missesUpdate(float location)
    {
        if(location < dist1)
        {
            misses1++;
        }
        else if(dist1 <= location && location < dist2)
        {
            misses2++;
        }
        else
        {
            misses3++;
        }
    }

    public static void loseHealth()
    {
        healthLoss++;
        if (playermovement_level1.isSlow)
        {
            healthLossSlow++;
        }
        else if (playermovement_level1.isFast)
        {
            healthLossFast++;
        }
        else if (playermovement_level1.isSwitchControls)
        {
            healthLossSwitchControl++;
        }
        else if (playermovement_level1.isDashing)
        {
            healthLossDash++;
        }
        else if (playermovement_level1.isSwitchGravity)
        {
            healthLossGravity++;
        }
        else
        {
            healthLossNormal++;
        }
    }

}
