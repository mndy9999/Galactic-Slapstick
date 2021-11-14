using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesManager : MonoBehaviour
{

    private static ProjectilesManager mInstance;
    public static ProjectilesManager Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = FindObjectOfType<ProjectilesManager>();
            return mInstance;
        }
    }

    private List<Rigidbody2D> spawnedProjectiles;

    private void Start()
    {
        spawnedProjectiles = new List<Rigidbody2D>();
    }

    public void StopProjectiles()
    {
        foreach (var p in spawnedProjectiles)
        {
            p.GetComponent<EdgeCollider2D>().enabled = false;
            p.velocity = new Vector2(0, -10);
        }
    }

    public void AddProjectile(Rigidbody2D proj)
    {
        if(proj != null)
            spawnedProjectiles.Add(proj);
    }

    public void RemoveProjectile(Rigidbody2D proj)
    {
        if(proj != null)
            spawnedProjectiles.Remove(proj);
    }

}
