using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.PlayerActions move;

    private Rigidbody2D rb;
    public float speed = 5;
    private bool is_moving;
    private Vector2 direction;
    void Start()
    {
        playerInput = new PlayerInput();
        move = playerInput.Player;

        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector2 currentVelocity = rb.velocity;
        Vector2 targetVelocity = direction;

        Vector2 velocityChange = currentVelocity - targetVelocity;

        rb.AddForce(velocityChange * speed, ForceMode2D.Force);
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }
}
