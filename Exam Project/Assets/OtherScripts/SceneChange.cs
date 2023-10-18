using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private bool isPaused = false;

    public void SceneChanger(int sceneID)
    {
        if (!isPaused)
        {

            SceneManager.LoadScene(sceneID);
        }
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
}

