using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckController : MonoBehaviour
{
    private PlayerMovementController playerController;

    private void Start()
    {
        playerController = transform.root.GetComponent<PlayerMovementController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            playerController.IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            playerController.IsGrounded = false;
    }

}
