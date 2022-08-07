using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class HighScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Easy, Medium, Hard;

    public GameObject AddUnitObject,ConfirmBox;
    private AdScript adScript;

    void Start()
    {
        ConfirmBox.SetActive(false);
        adScript =AddUnitObject.GetComponent<AdScript>();
        Easy.text = PlayerPrefs.GetInt("EasyScore", 5).ToString();
        Medium.text = PlayerPrefs.GetInt("MediumScore", 0).ToString();
        Hard.text = PlayerPrefs.GetInt("HardScore", 0).ToString();
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Exit();
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene("Home");
    }

    public void ResetButton()
    {
        ConfirmBox?.SetActive(true);
             
    }

    public void ResetConfirm()
    {
        adScript.ShowRewardedVideo();
        ConfirmBox?.SetActive(false);

    }

    public void CancelButton()
    {
        ConfirmBox?.SetActive(false);

    }

}
