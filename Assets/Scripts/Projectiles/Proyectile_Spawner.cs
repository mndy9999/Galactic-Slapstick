using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile_Spawner : MonoBehaviour
{
    [Header("Spawning Variables")]
    public GameObject spawnee;
    public float spawnTime;
    public float spawnDelay;
    public float xSpawnerExtension, ySpawnerExtension;  // This variable will influence the range in which GameObjects Instantiate;
                                                        // x and y Spawner must be positive.

    [Header("Spawned Object Variables")]
    public float xMinSpeed;
    public float xMaxSpeed;
    public float yMinSpeed;
    public float yMaxSpeed;
    public float minObjectScale;
    public float maxObjectScale;

    GameManager gameManager;
    ProjectilesManager projectilesManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        projectilesManager = ProjectilesManager.Instance;
    }

    public void SpawnObject()
    {
        if (gameManager.GameOver)
        {
            CancelInvoke();
            return;
        }

        GameObject instantiatedProyectile = Instantiate(spawnee, gameObject.transform.position + new Vector3(Random.Range(0, xSpawnerExtension),Random.Range(0, ySpawnerExtension),0), transform.rotation);
        instantiatedProyectile.transform.localScale = instantiatedProyectile.transform.localScale * Random.Range(minObjectScale, maxObjectScale); //Setting up proyectile scale.
        Rigidbody2D myRigidBody = instantiatedProyectile.GetComponent<Rigidbody2D>(); //Storing the Instantiated Object RiidBody.
        myRigidBody.velocity = new Vector2(Random.Range(xMinSpeed, xMaxSpeed), Random.Range(yMinSpeed, yMaxSpeed)); //Sets its Velocity.
        projectilesManager.AddProjectile(myRigidBody);
    }

    public void StartSpawn()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void StopInvoke()
    {
        CancelInvoke("SpawnObject");
    }
}
