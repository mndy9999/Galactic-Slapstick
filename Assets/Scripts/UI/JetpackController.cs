using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetpackController : MonoBehaviour
{
    private PlayerMovementController playerController;
    private Slider slider;

    private void Start()
    {
        PlayerMovementController.OnJetpackPowerChanged += () => { UpdateJetpackPower(); };
        playerController = transform.root.GetComponent<PlayerMovementController>();
        slider = transform.GetComponent<Slider>();
        slider.maxValue = playerController.jumpPower;
        slider.value = playerController.jumpPower;
    }

   
    void UpdateJetpackPower()
    {       
        slider.value = playerController.CurrentJumpPower;
    }
}
