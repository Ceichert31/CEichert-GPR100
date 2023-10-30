using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AddPoint : MonoBehaviour
{
    public delegate void AddScore(int point);
    public static AddScore addScore;

    [SerializeField] private int points = 10;

    private ParticleSystem particle;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        particle.Play();
        PlayerMovement.playSound?.Invoke();
        addScore?.Invoke(points);
        float newX = Random.Range(-5, 5);
        float newY = Random.Range(-3, 3);
        Vector2 newPos = new(newX, newY);
        transform.position = newPos;
    }
}
