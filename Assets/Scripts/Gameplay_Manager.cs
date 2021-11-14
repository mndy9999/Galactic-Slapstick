using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_Manager : MonoBehaviour
{
    public RandomizeControlls randomizeControlls;
    public CameraAnimator_Controller cameraScript;
    public Spawner_Controller spawnScript;

    float maximumProjectileSpeed;
    float currentAverage;

    int tutorialCounter = 0;

    void Rotate()
    {
        IncreaseDifficulty();
        int nextRotate = Random.Range(1, 4);  // Random int to choose a level of rotation.

        if (nextRotate == 1)
        {
            cameraScript.Turn_90();
        }
        else if(nextRotate == 2)
        {
            cameraScript.Turn_180();
        }
        else if (nextRotate == 3)
        {
            cameraScript.Turn_270();
        }
        else
        {
            Debug.Log("Random Int not between 1 and 3?!");
        }
    }

    void RandomizeKeys()
    {
        randomizeControlls.Randomize();
    }

    public void Timer()
    {
        tutorialCounter++;

        // Tutorial or first "easy rounds".
        if (tutorialCounter <= 2)
            RandomizeKeys();
        else if(tutorialCounter == 3)
            Rotate(); 

        // Real normal game behavior.
        else if(tutorialCounter >= 4)
        {
            int randomInt = Random.Range(1, 3);
            if (randomInt == 1)       
                Rotate();
            else if(randomInt == 2)
                RandomizeKeys();
        }
    }

    void IncreaseDifficulty()
    {
        int difficultySelection = Random.Range(1, 3);
        if(difficultySelection == 1)
        {
            IncreasePojectileDiff();
        }
        else if(difficultySelection == 2)
        {
            DecreaseProjectileDelay();
        }
    }

    void IncreasePojectileDiff()
    {
        currentAverage = (spawnScript.newMinProjectileSpeed + spawnScript.newMaxProjectileSpeed) / 2;
        if (!(currentAverage >= maximumProjectileSpeed))
        {
            currentAverage += 0.5f;
            spawnScript.newMinProjectileSpeed += 0.5f;
            spawnScript.newMaxProjectileSpeed += 0.5f;
        }
    }

    void DecreaseProjectileDelay()
    {
        if (spawnScript.newSpawnDelay < 0.5f)
        {
            spawnScript.newSpawnDelay -= 0.1f;
        }
    }
}
