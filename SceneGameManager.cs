using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToNextSene(int scene_)
    {
        SceneManager.LoadScene(scene_);
    }
}
