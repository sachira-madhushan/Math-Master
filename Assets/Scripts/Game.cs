using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class Game : MonoBehaviour
{
    #region PrivateVariables
    public AudioSource _clip;
    [SerializeField]
    private TextMeshProUGUI _numberOne, _numberTwo, _oparator,_questionNumber,_finalScore;

    [SerializeField]
    private TMP_InputField _answer;
    
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private GameObject _gameOverMenu,star01,star02,star03;
    private int _mode,correctAnswers,wrongAnswers;
    int answer,Qnumber, highScoreEasy, highScoreMedium, highScoreHard;
    string oparatorChar,userAnswer;
    int num01;
    int num02;
    int oparator;
    int time=100;
    private bool isGameOver;

    #endregion
    public GameObject confirmDialog;
    public GameObject AddUnitObject;
    private InteratialAdd adScript;
    public Image _timeBar;
    void Start()
    {
        confirmDialog.SetActive(false);
        adScript =AddUnitObject.GetComponent<InteratialAdd>();
        isGameOver = false;
        Time.timeScale = 1;
        _mode = PlayerPrefs.GetInt("GameMode", 0);
        highScoreEasy   = PlayerPrefs.GetInt("EasyScore", 0);
        highScoreMedium = PlayerPrefs.GetInt("MediumScore", 1);
        highScoreHard = PlayerPrefs.GetInt("HardScore", 2);
        LoadQuestion();
        InvokeRepeating("Timer", 1f, 1f);
        _gameOverMenu.SetActive(false);
        star01.SetActive(false);
        star02.SetActive(false);
        star03.SetActive(false);

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            _clip.mute = false;
        }
        else
        {
            _clip.mute = true;
        }
    }

    void FixedUpdate()
    {


        if (Input.GetKeyUp(KeyCode.Escape))
        {
            confirmDialog.SetActive(true);
        }

        if (time < 50)
        {
            _timeBar.color = Color.red;
        }
        if (!isGameOver)
        {
            if (time == 0)
            {
                _finalScore.text = correctAnswers.ToString() + "/" + Qnumber.ToString();
                switch (_mode)
                {
                    case 0:
                        if (highScoreEasy < correctAnswers)
                        {
                            PlayerPrefs.SetInt("EasyScore", correctAnswers);
                            star01.SetActive(true);
                            star02.SetActive(true);
                            star03.SetActive(true);

                        }
                        else if ((highScoreEasy / 2) < correctAnswers)
                        {
                            star01.SetActive(true);
                            star02.SetActive(true);
                        }
                        else
                        {
                            star01.SetActive(true);
                        }
                        break;
                    case 1:
                        if (highScoreMedium < correctAnswers)
                        {
                            PlayerPrefs.SetInt("EasyMedium", correctAnswers);
                            star01.SetActive(true);
                            star02.SetActive(true);
                            star03.SetActive(true);

                        }
                        else if ((highScoreMedium / 2) < correctAnswers)
                        {
                            star01.SetActive(true);
                            star02.SetActive(true);
                        }
                        else
                        {
                            star01.SetActive(true);
                        }
                        break;
                    case 2:
                        if (highScoreHard < correctAnswers)
                        {
                            PlayerPrefs.SetInt("EasyHard", correctAnswers);
                            star01.SetActive(true);
                            star02.SetActive(true);
                            star03.SetActive(true);

                        }
                        else if ((highScoreHard / 2) < correctAnswers)
                        {
                            star01.SetActive(true);
                            star02.SetActive(true);
                        }
                        else
                        {
                            star01.SetActive(true);
                        }
                        break;
                }
                //print("sacheera");
                isGameOver = true;
                Invoke("StopTime", 0.1f);
            }
        }




    }
    void StopTime()
    {
        print("ssssssssssss");
        adScript.ShowInterstitial();
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
    void EasyLevel()
    {
        
        oparator=Random.Range(0, 3);

        switch (oparator)
        {
            case 0:
                num01 = Random.Range(1, 20);
                num02 = Random.Range(1, 20);
                oparatorChar = "+";
                answer = num01 + num02;
                break;
            case 1:
                num01 = Random.Range(15, 20);
                num02 = Random.Range(1, 15);
                oparatorChar = "-";
                answer = num01 - num02;
                break;
            case 2:
                num01 = Random.Range(1, 10);
                num02 = Random.Range(1, 10);
                oparatorChar = "*";
                answer = num01 * num02;
                break;
        }

        _numberOne.text = num01.ToString();
        _numberTwo.text = num02.ToString();
        _oparator.text = oparatorChar;

    }

    void MediumLevel()
    {
        
        oparator = Random.Range(0, 3);

        switch (oparator)
        {
            case 0:
                num01 = Random.Range(10, 100);
                num02 = Random.Range(10, 100);
                oparatorChar = "+";
                answer = num01 + num02;
                break;
            case 1:
                num01 = Random.Range(50, 100);
                num02 = Random.Range(10, 50);
                oparatorChar = "-";
                answer = num01 - num02;
                break;
            case 2:
                num01 = Random.Range(10, 100);
                num02 = Random.Range(1, 10);
                oparatorChar = "*";
                answer = num01 * num02;
                break;
        }

        _numberOne.text = num01.ToString();
        _numberTwo.text = num02.ToString();
        _oparator.text = oparatorChar;
    }

    void HardLevel()
    {
        
        oparator = Random.Range(0, 3);

        switch (oparator)
        {
            case 0:
                num01 = Random.Range(100, 1000);
                num02 = Random.Range(100, 1000);
                oparatorChar = "+";
                answer = num01 + num02;
                break;
            case 1:
                num01 = Random.Range(500, 1000);
                num02 = Random.Range(100, 500);
                oparatorChar = "-";
                answer = num01 - num02;
                break;
            case 2:
                num01 = Random.Range(100, 1000);
                num02 = Random.Range(1, 10);
                oparatorChar = "*";
                answer = num01 * num02;
                break;
        }

        _numberOne.text = num01.ToString();
        _numberTwo.text = num02.ToString();
        _oparator.text = oparatorChar;
    }

    public void NextButton()
    {

        
        if (answer.ToString() == userAnswer)
        {
            _animator.SetBool("Right", true);
            Invoke("UnsetAnimations", 0.1f);
            correctAnswers++;

        }
        else
        {
            _animator.SetBool("Wrong", true);
            Invoke("UnsetAnimations", 0.1f);
            wrongAnswers++;
        }
        LoadQuestion();
        _answer.text = "";
    } 

    void LoadQuestion()
    {
        Qnumber++;
        _questionNumber.text=Qnumber.ToString();
        switch (_mode)
        {
            case 0:
                EasyLevel();
                break;
            case 1:
                MediumLevel();
                break;
            case 2:
                HardLevel();
                break;
        }
    }

    public void GetInput()
    {
        userAnswer = _answer.text;
    }

    void UnsetAnimations()
    {
        _animator.SetBool("Right", false);
        _animator.SetBool("Wrong", false);
    }

    void Timer()
    {
        if (time != 0)
        {
            _timeBar.fillAmount -= 0.02f;
            time -= 2;
        }
        
    }



    //gameOver menu
    public void Restart()
    {
        SceneManager.LoadScene("Game");
        
    }


    public void ConfirmCanceled()
    {
        confirmDialog.SetActive(false);
    }
    public void Confirmed()
    {
        SceneManager.LoadScene("Home");
        confirmDialog.SetActive(false);

    }
}
