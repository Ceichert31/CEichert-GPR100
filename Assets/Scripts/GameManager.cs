using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static int globalScore;

    public delegate void GetScore(int score);
    public static GetScore getScore;

    private void Start()
    {
        Instance = this;

        if (FindObjectOfType<GameManager>() != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void SetScore(int score)
    {
        globalScore = score;
    }
    private void OnEnable()
    {
        getScore += SetScore;
    }
    private void OnDisable()
    {
        getScore -= SetScore;
    }

}
