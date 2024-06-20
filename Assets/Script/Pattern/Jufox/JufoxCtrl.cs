using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JufoxCtrl : MonoBehaviour
{
    public AudioSource audioM;
    public PatternManager patternM;

    public AudioClip juFox;
    public AudioClip notLure;
    public AudioClip notThat;
    public AudioClip youFox;
    public AudioClip crazy;
    public AudioClip hit;

    public Animator ruru;
    public Animator fox;
    public Animator sd1;
    public Animator sd2;
    public Animator sd3;
    public Animator ladle;

    public float time;
    public float delay;

    public bool isReady;

    public Vector3 playerPos;
    public Vector3 SD1;
    public Vector3 SD2;
    public Vector3 SD3;

    public Vector3 sd1Pos;
    public Vector3 sd2Pos;
    public Vector3 sd3Pos;

    private void Awake()
    {
        ruru = transform.GetChild(0).GetComponent<Animator>();
        fox = transform.GetChild(1).GetComponent<Animator>();
        sd1 = transform.GetChild(3).GetChild(0).GetComponent<Animator>();
        sd2 = transform.GetChild(3).GetChild(1).GetComponent<Animator>();
        sd3 = transform.GetChild(3).GetChild(2).GetComponent<Animator>();
        ladle = transform.GetChild(4).GetComponent<Animator>();

        sd1Pos = new Vector3(-10.8f, -2f, 0f);
        sd2Pos = new Vector3(0f, 5.5f, 0f);
        sd3Pos = new Vector3(10.8f, -2f, 0f);
    }

    private void OnEnable()
    {
        time = 0f;
        delay = 2f;
        isReady = false;
        ruru.enabled = true;
        fox.enabled = true;
        sd1.enabled = true;
        sd2.enabled = true;
        sd3.enabled = true;
        ladle.enabled = true;
        transform.GetChild(3).GetChild(0).GetChild(0).gameObject.tag = "Attack";
        transform.GetChild(3).GetChild(1).GetChild(0).gameObject.tag = "Attack";
        transform.GetChild(3).GetChild(2).GetChild(0).gameObject.tag = "Attack";


        transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Transform>().position = sd1Pos;
        transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<Transform>().position = sd2Pos;
        transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<Transform>().position = sd3Pos;
        StartCoroutine(Jufox());
    }

    private IEnumerator Jufox()
    {
        while (true)
        {
            TriggerCheck();
            if (isReady == true)
            {
                isReady = false;

                transform.GetChild(0).gameObject.SetActive(true);
                yield return new WaitForSeconds(4.5f);
                transform.GetChild(1).gameObject.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Return");
                transform.GetChild(0).gameObject.SetActive(false);
                yield return new WaitForSeconds(1.9f);
                audioM.clip = notLure;
                transform.GetChild(2).gameObject.SetActive(true);
                audioM.Play();
                yield return new WaitForSeconds(8f);
                audioM.clip = crazy;
                audioM.Play();
                transform.GetChild(1).gameObject.GetComponent<Animator>().SetTrigger("Disappear");
                transform.GetChild(2).gameObject.SetActive(false);
                yield return new WaitForSeconds(2f);

                time = 0f;
                transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
                while (time <= delay)
                {
                    time += Time.deltaTime;
                    SD1 = new Vector3(0f, GameObject.FindGameObjectWithTag("Player").transform.position.y, 0f);
                    SD1.y = Mathf.Clamp(SD1.y, -2.8f, 2.8f);
                    transform.GetChild(3).GetChild(0).GetComponent<Transform>().position = SD1;
                    yield return null;
                }
                audioM.clip = youFox;
                transform.GetChild(3).GetChild(0).GetComponent<Animator>().SetTrigger("Attack");
                yield return new WaitForSeconds(1.4f);
                audioM.Play();
                yield return new WaitForSeconds(1.2f);
                transform.GetChild(3).GetChild(0).GetChild(0).gameObject.tag = "SD";

                time = 0f;
                transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                while (time <= delay)
                {
                    time += Time.deltaTime;
                    SD2 = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, 0f, 0f);
                    SD2.x = Mathf.Clamp(SD2.x, -7.4f, 7.4f);
                    transform.GetChild(3).GetChild(1).GetComponent<Transform>().position = SD2;
                    yield return null;
                }
                transform.GetChild(3).GetChild(1).GetComponent<Animator>().SetTrigger("Attack");
                yield return new WaitForSeconds(1.4f);
                audioM.Play();
                yield return new WaitForSeconds(1.2f);
                transform.GetChild(3).GetChild(1).GetChild(0).gameObject.tag = "SD";

                time = 0f;
                transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
                while (time <= delay)
                {
                    time += Time.deltaTime;
                    SD3 = new Vector3(0f, GameObject.FindGameObjectWithTag("Player").transform.position.y, 0f);
                    SD3.y = Mathf.Clamp(SD3.y, -2.8f, 3f);
                    transform.GetChild(3).GetChild(2).GetComponent<Transform>().position = SD3;
                    yield return null;
                }
                audioM.clip = youFox;
                transform.GetChild(3).GetChild(2).GetComponent<Animator>().SetTrigger("Attack");
                yield return new WaitForSeconds(1.4f);
                audioM.Play();
                yield return new WaitForSeconds(1.2f);
                transform.GetChild(3).GetChild(2).GetChild(0).gameObject.tag = "SD";

                transform.GetChild(4).gameObject.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                transform.GetChild(4).GetComponent<Animator>().SetTrigger("Attack");
                audioM.clip = hit;
                yield return new WaitForSeconds(1.7f);
                audioM.Play();
                transform.GetChild(3).GetChild(0).GetComponent<Animator>().SetTrigger("Disappear");
                transform.GetChild(3).GetChild(1).GetComponent<Animator>().SetTrigger("Disappear");
                transform.GetChild(3).GetChild(2).GetComponent<Animator>().SetTrigger("Disappear");
                yield return new WaitForSeconds(0.5f);
                transform.GetChild(4).GetComponent<Animator>().SetTrigger("Disappear");
                yield return new WaitForSeconds(3f);
                patternM.count += 1;
                patternM.isPlaying = false;
                gameObject.SetActive(false);

            }

            yield return null;
        }
    }

    private void TriggerCheck()
    {
        if (audioM.clip == juFox)
        {
            isReady = true;
        }
    }

    //private void FixedUpdate()
    //{
    //    time += Time.deltaTime;
    //    playerPos = new Vector3(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.y, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z);
    //}
}
