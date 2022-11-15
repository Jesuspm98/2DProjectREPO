using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementUpDown : MonoBehaviour
{
    private float verticalInput;

    public float movementSpeed = 5;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, verticalInput * movementSpeed);
    }
}