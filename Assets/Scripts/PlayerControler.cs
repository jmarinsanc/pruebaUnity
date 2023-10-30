using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedMove;
    public float speedUp;
    public float jumpingPower;
    public SpriteRenderer sprtRnd;
    public Animator animPlayer;


    private float horizontal;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkMovement(); 
    }

    public void Move(InputAction.CallbackContext context)
    {
      
        horizontal = context.ReadValue<Vector2>().x;
        Debug.Log(horizontal);

    }

    private void checkMovement()
    {
        if (checkGround.isGrounded)
        {
            animPlayer.SetBool("isGrounded", true);
        }
        else
        {
            animPlayer.SetBool("isGrounded", false);
        }

        if (Mathf.Abs(horizontal) != 0f)
        {
            animPlayer.SetBool("isRunning", true);
        }
        else
        {
            animPlayer.SetBool("isRunning", false);
        }
        rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            //girar derecha
            isFacingRight = true;
            sprtRnd.flipX = false;
        }
        else if (isFacingRight && horizontal < 0f)
        {
            //hacia la izquierda
            isFacingRight = false;
            sprtRnd.flipX = true;
        }

    }

    public void Jump()
    {

        if (checkGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        
    }
    public void Shoot()
    {
        Debug.Log("disparo");
    }
}
