using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysPanelManager : MonoBehaviour
{
    public List<Image> images;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        RandomizeControlls.OnControlsChanged += RandomizeControlls_OnControlsChanged;
    }

    private void RandomizeControlls_OnControlsChanged(List<CustomKey> key)
    {
        for (int i = 0; i < key.Count; i++)
        {
            images[i].color = key[i].Status.GetColor();
        }
        StartCoroutine("Freeze");
    }

    IEnumerator Freeze()
    {
        Time.timeScale = 0;
        animator.SetBool("flash", true);
        yield return new WaitForSecondsRealtime(1.0f);
        Time.timeScale = 1;
        animator.SetBool("flash", false);
    }

    private void OnDestroy()
    {
        RandomizeControlls.OnControlsChanged -= RandomizeControlls_OnControlsChanged;
    }

}
