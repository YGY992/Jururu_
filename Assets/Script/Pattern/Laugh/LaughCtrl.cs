using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughCtrl : MonoBehaviour
{
    public AudioSource audioM;
    public PatternManager patternM;

    public bool isReady;
    public bool isAttack;
    public bool isFinished;
    public bool isWindmill;
    public int count;

    public AudioClip laugh1;
    public AudioClip laugh2;


    //private void Awake()
    //{
    //    count = 1;
    //    isReady = false;
    //    isAttack = false;
    //    isFinished = false;
    //    isWindmill = false;
    //    audioM = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
    //    StartCoroutine(Laugh());
    //}

    private void OnEnable()
    {
        count = 1;
        isReady = false;
        isAttack = false;
        isFinished = false;
        isWindmill = false;
        audioM = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        StartCoroutine(Laugh());
    }

    private IEnumerator Laugh()
    {
        while (true)
        {
            CheckAttack();
            if (isReady == true && 28 > count) // 공격 준비
            {
                transform.GetChild(count).GetComponent<Transform>().position = new Vector2(Random.Range(-7.9f, 7.8f), Random.Range(-3.6f, 3.6f));
                transform.GetChild(count).gameObject.SetActive(true);
                count += 1;
                yield return new WaitForSecondsRealtime(0.05f);

                if (count >= 28)
                {
                    isReady = false;
                }
            }

            if (isAttack == true && transform.childCount > count) // 공격
            {
                isFinished = true;
                transform.GetChild(count).GetComponent<LaughAttack>().Attack();
                count += 1;
                yield return new WaitForSecondsRealtime(0.055f);

                if(count >= transform.childCount)
                {
                    isAttack = false;
                    count = 1;
                    Invoke("GatherTriggerOn", 1.5f);
                }
            }

            if(isFinished == false && count >= 28 && isReady == false && isAttack == false)
            {
                yield return new WaitForSecondsRealtime(1.5f);
                count = 1;
                audioM.clip = laugh2;
                audioM.Play();
            }

            if(isWindmill == true)
            {
                transform.GetChild(0).gameObject.SetActive(true);

                yield return new WaitForSeconds(19f);
                patternM.count += 1;
                patternM.isPlaying = false;
                gameObject.SetActive(false);
            }
            yield return null;
        }
    }
    private void CheckAttack() //트리거 체크
    {
        if (audioM.clip == laugh1 && audioM.isPlaying == true)
        {
            isReady = true;
        }
        else if (audioM.clip == laugh2 && audioM.isPlaying == true)
        {
            isAttack = true;
        }
    }

    private void GatherTriggerOn()
    {
        for(int i = 1; i < 28; i++)
        {
            transform.GetChild(i).GetComponent<LaughAttack>().isGather = true;
        }
    }
}