using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource bgm;

    private void Awake()
    {
        volumeSlider = transform.GetChild(3).GetChild(2).GetComponent<Slider>();
        bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
        volumeSlider.value = bgm.volume;
    }
    public void MoveScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenSetting()
    {
        transform.GetChild(3).gameObject.SetActive(true);
    }
        public void CloseSetting()
    {
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void VolumeControl()
    {
        bgm.volume = volumeSlider.value;
    }

    public void AudioMute()
    {
        if(bgm.mute == true)
        {
            transform.GetChild(3).GetChild(3).GetChild(0).gameObject.SetActive(true);
            transform.GetChild(3).GetChild(3).GetChild(1).gameObject.SetActive(false);
            bgm.mute = false;
        }
        else if(bgm.mute == false)
        {
            transform.GetChild(3).GetChild(3).GetChild(1).gameObject.SetActive(true);
            transform.GetChild(3).GetChild(3).GetChild(0).gameObject.SetActive(false);
            bgm.mute = true;
        }
    }

    private void FixedUpdate()
    {
        VolumeControl();
    }


}
