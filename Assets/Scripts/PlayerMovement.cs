using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource;

    private Vector2 direction;

    [SerializeField] private float speed;

    [SerializeField] private AudioClip nomClip;

    public delegate void PlaySound();
    public static PlaySound playSound;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
    void PlayAudio()
    {
        audioSource.PlayOneShot(nomClip, 0.5f);
    }
    private void OnEnable()
    {
        playSound += PlayAudio;
    }
    private void OnDisable()
    {
        playSound -= PlayAudio;
    }
}
