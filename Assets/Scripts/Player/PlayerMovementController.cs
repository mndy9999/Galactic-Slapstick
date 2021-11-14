using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public delegate void JetpackPowerChanged();
    public static event JetpackPowerChanged OnJetpackPowerChanged;

    public ParticleSystem jetpackParticles;

    private Rigidbody2D playerRb;
    private Animator playerAnim;

    private bool mIsRecharging;
    private bool mIsGrounded;
    public bool IsGrounded
    {
        get
        {
            return mIsGrounded;
        }
        set
        {
            if(value != mIsGrounded)
            {
                mIsGrounded = value;
                mIsRecharging = value;
                if (mIsGrounded)
                {
                    mIsRecharging = true;
                    playerAnim.SetBool("jumping", false);
                }
            }
        }
    }

    public float runSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float jumpPower = 100;

    private float mCurrentPower;
    public float CurrentJumpPower
    {
        get
        {
            return mCurrentPower;
        }
        set
        {
            if(mCurrentPower != value)
            {
                mCurrentPower = value;
                if(OnJetpackPowerChanged != null)
                    OnJetpackPowerChanged.Invoke();
            }
        }
    }

    private bool facingRight;

    private float horizontalInput;

    KeyCode leftKey = KeyCode.A;
    KeyCode rightKey = KeyCode.D;
    KeyCode upKey = KeyCode.W;

    private bool hit;
    public bool IsHit
    {
        set
        {
            hit = value;
            playerAnim.SetBool("hit", true);
            GameManager.Instance.EndGame();
        }
    }

    public void UpdateControlls(KeyCode left, KeyCode right, KeyCode up)
    {
        leftKey = left;
        rightKey = right;
        upKey = up;
    }

    // Start is called before the first frame update
    void Awake()
    {        
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponentInChildren<Animator>();
        CurrentJumpPower = jumpPower;
    }

    private void HandleWalking()
    {
        //set speed to start/stop walk animation
        playerAnim.SetFloat("speed", Mathf.Abs(horizontalInput));

        //add velocity to move
        playerRb.velocity = new Vector2(horizontalInput * runSpeed, playerRb.velocity.y);

        //invert sprite rendere to flip in walking direction
        if (!facingRight && horizontalInput < 0 || facingRight && horizontalInput > 0)
            Flip();
    }

    private void HandleFloating()
    {
        if (CurrentJumpPower > 0)
        {
            jetpackParticles.Play();
            playerRb.velocity = Vector2.up * jumpForce * .5f;
            CurrentJumpPower -= Time.deltaTime * 10f;
        }

    }

    private void Flip()
    {
        //switch facing direction
        facingRight = !facingRight;

        //rescale on x axis to flip the sprite renderer
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


    private void Update()
    {
        if (hit)
            return;

        if (mIsRecharging)
        {
            CurrentJumpPower += Time.deltaTime * 5.0f;
            if (CurrentJumpPower >= jumpPower)
            {
                CurrentJumpPower = jumpPower;
                mIsRecharging = false;
            }

        }

        horizontalInput = Input.GetKey(leftKey) ? -1 : Input.GetKey(rightKey) ? 1 : 0;


        //update animator
        playerAnim.SetBool("jumping", !IsGrounded);
        playerAnim.SetFloat("jump_direction", playerRb.velocity.y);

        if (Input.GetKeyDown(upKey) && IsGrounded)
            playerRb.velocity = Vector2.up * jumpForce;

        if (Input.GetKey(KeyCode.Space) && !IsGrounded)
        {
            AudioManager.Instance.PlayJetpack();
            HandleFloating();
        }

        if (Input.GetKeyUp(KeyCode.Space) || mCurrentPower <= 1)
        {
            AudioManager.Instance.StopPlay("Jetpack");
            jetpackParticles.Stop();
        }
    }

    private void FixedUpdate()
    {
        if (hit)
            return;
        HandleWalking();
    }

    public void ResetPlayerValues()
    {
        playerAnim.SetBool("jumping", false);
        playerAnim.SetBool("spinning", false);
    }

}


