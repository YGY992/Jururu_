using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereCtrl : MonoBehaviour
{
    public AudioSource audioM;
    public PatternManager patternM;

    public Animator wai;
    public Animator ftf;
    public Animator hidden;

    public AudioClip whereAmI;
    public AudioClip findMe;
    public AudioClip found;

    public bool isReady;

    private void Awake()
    {
        wai = transform.GetChild(1).GetComponent<Animator>();
        ftf = transform.GetChild(2).GetComponent<Animator>();
        hidden = transform.GetChild(0).GetChild(3).GetComponent<Animator>();
    }

    private void OnEnable()
    {
        hidden.enabled = true;
        wai.enabled = true;
        ftf.enabled = true;
        isReady = false;
        StartCoroutine(Where());
    }

    private IEnumerator Where()
    {
        while(true)
        {
            TriggerCheck();

            if (isReady == true)
            {
                isReady = false;
                transform.GetChild(1).gameObject.SetActive(true);
                yield return new WaitForSeconds(1f);
                transform.GetChild(0).gameObject.SetActive(true);

                yield return new WaitForSeconds(2f);
                transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                audioM.clip = findMe;
                audioM.Play();
                wai.SetTrigger("Disappear");

                yield return new WaitForSeconds(7f);
                hidden.SetTrigger("BarrierOn");

                yield return new WaitForSeconds(0.7f);
                transform.GetChild(2).gameObject.SetActive(true);
                audioM.clip = found;
                audioM.Play();

                yield return new WaitForSeconds(4f);
                ftf.SetTrigger("Disappear");

                yield return new WaitForSeconds(1f);
                transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                hidden.enabled = false;
                yield return new WaitForSeconds(0.5f);
                transform.GetChild(0).gameObject.SetActive(false);
                patternM.count += 1;
                patternM.isPlaying = false;
                gameObject.SetActive(false);
            }

            yield return null;
        }    
    }

    private void TriggerCheck()
    {
        if(audioM.clip == whereAmI && audioM.isPlaying == true)
        {
            isReady = true;
        }
    }
}
