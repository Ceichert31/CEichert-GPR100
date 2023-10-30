using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public delegate void LoadScene(int scene);
    public static LoadScene loadScene;

    void Load(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void OnEnable()
    {
        loadScene += Load;
    }
    private void OnDisable()
    {
        loadScene -= Load;
    }
}
