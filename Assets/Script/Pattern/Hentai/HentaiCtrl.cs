using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HentaiCtrl : MonoBehaviour
{
    public AudioSource audioM;
    public PatternManager patternM;

    public AudioClip hentai;
    public AudioClip cantCham;

    public Animator ruru;
    public Animator laser;

    public bool isReady;

    private void Awake()
    {
        ruru = transform.GetChild(0).GetComponent<Animator>();
        laser = transform.GetChild(1).GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ruru.enabled = true;
        laser.enabled = true;
        isReady = false;
        StartCoroutine(Hentai());
    }

    private IEnumerator Hentai()
    {
        while(true)
        {
            TriggerCheck();
            if (isReady == true)
            {
                isReady = false;

                transform.GetChild(0).gameObject.SetActive(true);
                yield return new WaitForSeconds(2f);
                transform.GetChild(1).gameObject.SetActive(true);
                yield return new WaitForSeconds(2.7f);

                
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Attack");
                audioM.clip = cantCham;
                audioM.Play();

                yield return new WaitForSeconds(1.5f);
                transform.GetChild(1).GetComponent<Animator>().SetTrigger("Down");

                yield return new WaitForSeconds(2f);
                transform.GetChild(1).GetComponent<Animator>().SetTrigger("Up");

                yield return new WaitForSeconds(1.5f);
                transform.GetChild(1).GetComponent<Animator>().SetTrigger("Mid");

                yield return new WaitForSeconds(1.5f);
                transform.GetChild(1).GetComponent<Animator>().SetTrigger("Disappear");
                yield return new WaitForSeconds(0.5f);
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Disappear");

                yield return new WaitForSeconds(1f);
                patternM.count += 1;
                patternM.isPlaying = false;
                gameObject.SetActive(false);
            }

            yield return null;
        }
    }

    private void TriggerCheck()
    {
        if (audioM.clip == hentai)
        {
            isReady = true;
        }
    }
}
