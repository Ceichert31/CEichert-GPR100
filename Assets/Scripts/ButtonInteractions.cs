using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractions : MonoBehaviour
{
    public void StartGame()
    {
        SceneLoader.loadScene?.Invoke(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
