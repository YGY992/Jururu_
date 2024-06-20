using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public AudioManager audioM;
    public string Pattern = "Rest"; //현재패턴
    public string[] Patterns = new string[6];
    public string temp;
    public int ran;
    public int count;
    public bool isPlaying = false;
    private void Awake()
    {
        count = 0;
        Patterns[0] = "Donate"; //도네패턴 //완료 
        Patterns[1] = "Laugh"; //익익익 억억억 //완료
        Patterns[2] = "Where"; //어딨게? 찾아봐~ //완료
        Patterns[3] = "Contract"; //르르땅과 종신계약~ //완료
        Patterns[4] = "Hentai"; //헨타이.. 참을 수 없어요! // 완료
        Patterns[5] = "Jufox"; //르르땅은 또다시 여우소리를 듣는구나 // 완료


        PatternShuffle();
    }
    private void FixedUpdate()
    {
        //오디오 매니저에 패턴 전달
        if(isPlaying == false)
        {
            if(count < 6)
            {
                audioM.GetComponent<AudioManager>().ChangeAudio(Patterns[count]);
                isPlaying = true;
                Debug.Log("현재 패턴" + Patterns[count]);
            }
            else
            {
                PatternShuffle();
                count = 0;
                audioM.GetComponent<AudioManager>().ChangeAudio(Patterns[count]);

            }
        }
    }
    private void PatternShuffle()
    {
        for (int i = 0; i < Patterns.Length; i++)
        {
            ran = Random.Range(0, Patterns.Length);
            temp = Patterns[i];
            Patterns[i] = Patterns[ran];
            Patterns[ran] = temp;
        }

        for (int i = 0; i < Patterns.Length; i++)
        {
            Debug.Log(Patterns[i]);
        }
    }

    private void ChangeAudio()
    {
        audioM.GetComponent<AudioManager>().ChangeAudio(Patterns[count]);
        isPlaying = true;
    }

    public void PatternOn(int num)
    {
        transform.GetChild(num).gameObject.SetActive(true);
    }
}
