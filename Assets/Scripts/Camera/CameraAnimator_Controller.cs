using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraAnimator_Controller : MonoBehaviour
{
    Animator myAnimator;
    bool usedTurn = false;
    public Spawner_Controller spawnScript;

    private void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }

    IEnumerator ResetBools()
    {
        yield return new WaitForSeconds(.8f);
        myAnimator.SetBool("90_Turn", false);
        myAnimator.SetBool("180_Turn", false);
        myAnimator.SetBool("270_Turn", false);
    }

    public void Turn_90()
    {
        myAnimator.SetBool("90_Turn", true);
        StartCoroutine("ResetBools");
    }

    public void Turn_180()
    {
        myAnimator.SetBool("180_Turn", true);
        StartCoroutine("ResetBools");
    }

    public void Turn_270()
    {
        myAnimator.SetBool("270_Turn", true);
        StartCoroutine("ResetBools");
    }
}
