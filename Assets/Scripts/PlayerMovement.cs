using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 direction;

    [SerializeField] private float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));



        if (rb.velocity.magnitude > 0)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);
    }
    private void FixedUpdate()
    {
        rb.velocity = (direction * speed);
    }
}
