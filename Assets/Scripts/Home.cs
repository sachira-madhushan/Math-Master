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

        _audioClip = GetComponent<AudioSource>();
        _image = soundButton.GetComponent<Image>();
        soundType = PlayerPrefs.GetInt("Sound", 1);
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
        }
        else if(_image.sprite== soundOff && soundType ==0)
        {
            _audioClip.mute = false;
            soundType = 1;
            _image.sprite = soundOn;
        }
    }
}
