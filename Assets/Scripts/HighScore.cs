using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class HighScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Easy, Medium, Hard;
    void Start()
    {
        Easy.text = PlayerPrefs.GetInt("EasyScore", 0).ToString();
        Medium.text = PlayerPrefs.GetInt("MediumScore", 0).ToString();
        Hard.text = PlayerPrefs.GetInt("HardScore", 0).ToString();
    }

    public void Exit()
    {
        SceneManager.LoadScene("Home");
    }


}
