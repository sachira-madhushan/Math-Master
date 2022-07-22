using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Home : MonoBehaviour
{

    public Button soundButton;
    private Image _image;
    private AudioSource _audioClip;
    public Sprite soundOn,soundOff;
    public int soundType;

    private void Start()
    {
        
        Time.timeScale = 1;
        _audioClip = GetComponent<AudioSource>();
        _image = soundButton.GetComponent<Image>();
        soundType = PlayerPrefs.GetInt("Sound", 1);
        if (soundType == 1)
        {
            _audioClip.mute = false;
            _image.sprite = soundOn;
        }
        else if (soundType == 0)
        {
            _audioClip.mute = true;
            _image.sprite = soundOff;
        }

    }
    public void Play()
    {
        
        SceneManager.LoadScene("Mode");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Rank()
    {
        SceneManager.LoadScene("Rank");
    }

    public void Sound()
    {
        if(_image.sprite== soundOn && soundType==1)
        {
            soundType = 0;
            _audioClip.mute = true;
            _image.sprite= soundOff;
            PlayerPrefs.SetInt("Sound", 0);
        }
        else if(_image.sprite== soundOff && soundType ==0)
        {
            PlayerPrefs.SetInt("Sound", 1);
            _audioClip.mute = false;
            soundType = 1;
            _image.sprite = soundOn;
        }
    }
}
