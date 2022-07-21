using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Game : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _numberOne, _numberTwo, _oparator,_questionNumber;

    [SerializeField]
    private TMP_InputField _answer;
    
    [SerializeField]
    private Animator _animator;

    private int _mode,correctAnswers,wrongAnswers;
    int answer,Qnumber;
    string oparatorChar,userAnswer;
    int num01;
    int num02;
    int oparator;
    float time=1;


    public Image _timeBar;
    void Start()
    {
        _mode = PlayerPrefs.GetInt("GameMode", 0);
        LoadQuestion();
        InvokeRepeating("Timer", 1f, 1f);
    }

    void FixedUpdate()
    {
        if (time < 0.5)
        {
            _timeBar.color = Color.red;
        }

        if (time == 0)
        {
            Time.timeScale = 0;
        }
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
        _timeBar.fillAmount = time;
        time -= 0.02f;
    }
}
