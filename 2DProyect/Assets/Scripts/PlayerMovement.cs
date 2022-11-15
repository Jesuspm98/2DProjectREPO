using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xDirection;

    public float jumpForce = 15;

    public float movementSpeed = 5;

    private Rigidbody2D rb;

    public Transform[] groundCheck;

    public LayerMask groundMask;

    public float checkGroundDistance = 1f;

    public FixedJoystick myJoystick;

    public Animator playerSpriteAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        xDirection = myJoystick.Horizontal;

        playerSpriteAnimator.SetFloat("Speed", Mathf.Abs(xDirection));

        if (myJoystick.Vertical > 0.7f && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.x > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (rb.velocity.x < 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (rb.velocity.y != 0)
        {
            playerSpriteAnimator.SetBool("IsJumping", true);
        }
        else
        {
            playerSpriteAnimator.SetBool("IsJumping", false);
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        for (int i = 0; i < groundCheck.Length; i++)
        {
            if (Physics2D.Raycast(groundCheck[i].position, -groundCheck[i].up, checkGroundDistance, groundMask))
            {
                return true;
            }
        }
        return false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xDirection * movementSpeed, rb.velocity.y);
    }
}