using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonateCtrl : MonoBehaviour
{
    public AudioSource audioM;
    public PatternManager patternM;

    public GameObject donate1;
    public GameObject donate2;
    public GameObject donate3;
    public GameObject money;

    public Animator ruru;
    public Animator kingdonate;
    public Animator rrL;
    public Animator rrR;

    public Vector3 pos;

    public AudioClip hundredThousand;
    public AudioClip fall;
    public AudioClip soBad;
    public AudioClip backseating;
    public AudioClip no;

    private int LR;

    public Vector3 playerPos;

    public bool isReady;

    private void Awake()
    {
        ruru = transform.GetChild(0).GetComponent<Animator>();
        kingdonate = transform.GetChild(1).GetComponent<Animator>();
        rrL = transform.GetChild(3).GetComponent<Animator>();
        rrR = transform.GetChild(2).GetComponent<Animator>();
    }

    private void OnEnable()
    {
        isReady = false;

        ruru.enabled = true;
        kingdonate.enabled = true;
        rrL.enabled = true;
        rrR.enabled = true;

        LR = 0;
        StartCoroutine(Donate());
    }

    private IEnumerator Donate()
    {
        while (true)
        {
            TriggerCheck();
            if (isReady == true)
            {
                isReady = false;
                transform.GetChild(0).gameObject.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                pos = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);
                Instantiate(donate1, pos, donate1.transform.rotation);
                yield return new WaitForSeconds(3.5f);
                audioM.clip = no;
                audioM.Play();
                yield return new WaitForSeconds(2.3f);
                pos = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);
                Instantiate(donate2, pos, donate1.transform.rotation);
                audioM.clip = soBad;
                audioM.Play();
                yield return new WaitForSeconds(3.5f);
                audioM.clip = no;
                audioM.Play();
                yield return new WaitForSeconds(2.3f);
                pos = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);
                Instantiate(donate3, pos, donate1.transform.rotation);
                audioM.clip = fall;
                audioM.Play();
                yield return new WaitForSeconds(3.5f);
                audioM.clip = no;
                audioM.Play();
                yield return new WaitForSeconds(2.5f);
                audioM.clip = hundredThousand;
                transform.GetChild(1).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                audioM.Play();
                yield return new WaitForSeconds(0.7f);
                StartCoroutine(MoneyRain());
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Disappear");
                yield return new WaitForSeconds(1f);
                playerPos = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, -0.25f, GameObject.FindGameObjectWithTag("Player").transform.position.z);
                if(playerPos.x >= 0)
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    LR = 1;
                }
                else if (playerPos.x < 0)
                {
                    transform.GetChild(3).gameObject.SetActive(true);
                    LR = 2;
                }
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }
    private IEnumerator MoneyRain()
    {
        while(true)
        {
            if (audioM.isPlaying == false)
                break;

            Instantiate(money, new Vector3(Random.Range(-8.3f, 8.3f), 6, 0), money.transform.rotation);
            yield return new WaitForSeconds(0.3f);
        }
        transform.GetChild(1).GetComponent<Animator>().SetTrigger("Disappear");
        if (LR == 1)
        {
            transform.GetChild(2).GetComponent<Animator>().SetTrigger("Disappear");
            yield return new WaitForSeconds(1f);
            transform.GetChild(1).gameObject.SetActive(false);
            patternM.count += 1;
            patternM.isPlaying = false;
            gameObject.SetActive(false);
        }
        else if(LR == 2)
        {
            transform.GetChild(3).GetComponent<Animator>().SetTrigger("Disappear");
            yield return new WaitForSeconds(1f);
            transform.GetChild(1).gameObject.SetActive(false);
            patternM.count += 1;
            patternM.isPlaying = false;
            gameObject.SetActive(false);
        }

        yield return null;
    }


    private void TriggerCheck()
    {
        if (audioM.clip == backseating)
        {
            isReady = true;
        }
    }
}
