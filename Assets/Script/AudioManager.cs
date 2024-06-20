using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public PatternManager patternM;
    public AudioClip[] laughSound = new AudioClip[2];
    public AudioClip[] contractSound = new AudioClip[4];
    public AudioClip[] whereSound = new AudioClip[3];
    public AudioClip[] hentaiSound = new AudioClip[2];
    public AudioClip[] donateSound = new AudioClip[5];
    public AudioClip[] jufoxSound = new AudioClip[6];
    public string Pattern;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeAudio(string _pattern)
    {
        //패턴별 브금(효과음)
        switch(_pattern)
        {
            case "Donate":
                patternM.PatternOn(0);
                audioSource.clip = donateSound[0];
                Invoke("SoundPlay", 2.2f);
                break;

            case "Laugh":
                patternM.PatternOn(1);
                audioSource.clip = laughSound[0];
                SoundPlay();
                break;

            case "Where":
                patternM.PatternOn(2);
                audioSource.clip = whereSound[0];
                Invoke("SoundPlay",2f);
                break;

            case "Contract":
                patternM.PatternOn(3);
                audioSource.volume = 0.5f;
                audioSource.clip = contractSound[0];
                SoundPlay();
                break;

            case "Hentai":
                patternM.PatternOn(4);
                audioSource.clip = hentaiSound[0];
                Invoke("SoundPlay", 2f);
                break;

            case "Jufox":
                patternM.PatternOn(5);
                audioSource.clip = jufoxSound[0];
                Invoke("SoundPlay", 1f);
                break;
        }
    }

    private void SoundPlay()
    {
        audioSource.Play();
    }
}
