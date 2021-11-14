using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{
    [Header("Projectile spawners")]
    public GameObject leftSpawner;
    public GameObject topSpawner;
    public GameObject rightSpawner;

    [Header("Projectile Values")]
    public float newSpawnDelay;
    public float newMinProjectileSpeed;
    public float newMaxProjectileSpeed;

    // Keeping track of which spawns are active.
    bool leftOn, topOn, rightOn;
    
    // Script private variables.
    Proyectile_Spawner myLeftScript;
    Proyectile_Spawner myTopScript;
    Proyectile_Spawner myRightScript;

    private void Start()
    {
        // Fill the script Variables.
        myLeftScript = leftSpawner.GetComponent<Proyectile_Spawner>();
        myTopScript = topSpawner.GetComponent<Proyectile_Spawner>();
        myRightScript = rightSpawner.GetComponent<Proyectile_Spawner>();

        ChangeOrientation();
    }

    void ChangeOrientation()
    {
        // Turning off previous Spawns.
        TurnOffSpawns();

        // Change numeric values of proyectiles.
        ChangeProyectileValues();

        myLeftScript.StartSpawn();
        myRightScript.StartSpawn();
        myTopScript.StartSpawn();
        leftOn = true;
        topOn = true;
        rightOn = true;
    }

    void ChangeProyectileValues()
    {
        // Change the Spawn Delay.
        myLeftScript.spawnDelay = newSpawnDelay;
        myRightScript.spawnDelay = newSpawnDelay;
        myTopScript.spawnDelay = newSpawnDelay;

        // Change the minProjectileSpeed;
        myLeftScript.xMinSpeed = newMinProjectileSpeed;
        myRightScript.xMinSpeed = -newMaxProjectileSpeed;       // Due to the orentation of each spawner, some speeds need to be negative.
        myTopScript.yMinSpeed = -newMaxProjectileSpeed;         // Because the small number must always go first, the negative max goes on the Minimum slot.

        // Change the maxProjecileSpeed;
        myLeftScript.xMaxSpeed = newMaxProjectileSpeed;
        myRightScript.xMaxSpeed = -newMinProjectileSpeed;
        myTopScript.yMaxSpeed = -newMinProjectileSpeed;
    }

    void TurnOffSpawns()
    {
        if (leftOn)
        {
            myLeftScript.StopInvoke();
        }
        if (topOn)
        {
            myTopScript.StopInvoke();
        }
        if (rightOn)
        {
            myRightScript.StopInvoke();
        }
    }
}
