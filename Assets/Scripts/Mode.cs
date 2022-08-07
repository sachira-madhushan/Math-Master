using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mode : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Home");
        }
    }
    public void Easy()
    {
        PlayerPrefs.SetInt("GameMode", 0);
        SceneManager.LoadScene("Game");
    }
    public void Medium()
    {
        PlayerPrefs.SetInt("GameMode", 1);
        SceneManager.LoadScene("Game");

    }

    public void Hard()
    {
        PlayerPrefs.SetInt("GameMode", 2);
        SceneManager.LoadScene("Game");
    }

    public void Back()
    {
        SceneManager.LoadScene("Home");
    }
}
