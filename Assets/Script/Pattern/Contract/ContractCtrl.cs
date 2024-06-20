using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractCtrl : MonoBehaviour
{
    public AudioSource audioM;
    public PatternManager patternM;

    public AudioClip subscribeSong;
    public AudioClip contract1;
    public AudioClip contract2;
    public AudioClip contract_Cut;

    public GameObject stamp;
    public GameObject falling;
    public GameObject fox;

    public Animator ruru;

    public Vector3 playerPos;
    public Vector3 spawnPos1;
    public Vector3 spawnPos2;
    public Vector3 spawnPos3;
    public Vector3 spawnPos4;

    public Vector3 spawnPos5;
    public Vector3 spawnPos6;
    public Vector3 spawnPos7;
    public Vector3 spawnPos8;
    public Vector3 spawnPos9;
    public Vector3 spawnPos10;

    public Vector3 foxPos;
    public Vector3 fallingPos;

    public bool isReady;

    private void Awake()
    {
        ruru = transform.GetChild(0).GetComponent<Animator>();
        spawnPos1 = new Vector3(-6f, -0.25f, 0f);
        spawnPos2 = new Vector3(-4f, -0.25f, 0f);
        spawnPos3 = new Vector3(0f, -0.25f, 0f);
        spawnPos4 = new Vector3(2f, -0.25f, 0f);

        spawnPos5 = new Vector3(-7.5f, -0.25f, 0f);
        spawnPos6 = new Vector3(-5.5f, -0.25f, 0f);
        spawnPos7 = new Vector3(-3.5f, -0.25f, 0f);
        spawnPos8 = new Vector3(-1.5f, -0.25f, 0f);
        spawnPos9 = new Vector3(0.5f, -0.25f, 0f);
        spawnPos10 = new Vector3(2.5f, -0.25f, 0f);

    }

    private void OnEnable()
    {
        ruru.enabled = true;
        StartCoroutine(Contract());
    }

    private IEnumerator Contract()
    {
        while (true)
        {
            CheckAttack();
            if(isReady == true)
            {
                transform.GetChild(0).gameObject.SetActive(true);

                if (audioM.isPlaying == false)
                {
                    isReady = false;
                    yield return new WaitForSeconds(0.5f);
                    playerPos = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, -0.25f, GameObject.FindGameObjectWithTag("Player").transform.position.z);
                    Instantiate(stamp, playerPos, stamp.transform.rotation);
                    audioM.clip = contract1;
                    audioM.volume = 1;
                    audioM.Play();
                    yield return new WaitForSeconds(3f);
                    audioM.clip = contract2;
                    audioM.Play();
                    Instantiate(stamp, spawnPos1, stamp.transform.rotation);
                    Instantiate(stamp, spawnPos2, stamp.transform.rotation);
                    yield return new WaitForSeconds(1.5f);
                    audioM.Play();
                    Instantiate(stamp, spawnPos3, stamp.transform.rotation);
                    Instantiate(stamp, spawnPos4, stamp.transform.rotation);
                    yield return new WaitForSeconds(2f);
                    audioM.clip = contract_Cut;
                    for (int i = 0; i < 5; i++)
                    {
                        playerPos = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, -0.25f, GameObject.FindGameObjectWithTag("Player").transform.position.z);
                        foxPos = new Vector3(playerPos.x, -4.3f, 0f);
                        fallingPos = new Vector3(foxPos.x, 4f, 0f);
                        Instantiate(fox, foxPos, fox.transform.rotation);
                        yield return new WaitForSeconds(0.4f);
                        audioM.Play();
                        Instantiate(falling, fallingPos, falling.transform.rotation);
                        yield return new WaitForSeconds(0.7f);
                    }
                    audioM.clip = contract1;
                    audioM.Play();
                    Instantiate(stamp, spawnPos5, stamp.transform.rotation);
                    yield return new WaitForSeconds(0.45f);
                    Instantiate(stamp, spawnPos6, stamp.transform.rotation);
                    yield return new WaitForSeconds(0.45f);
                    Instantiate(stamp, spawnPos7, stamp.transform.rotation);
                    yield return new WaitForSeconds(0.45f);
                    Instantiate(stamp, spawnPos8, stamp.transform.rotation);
                    yield return new WaitForSeconds(0.45f);
                    Instantiate(stamp, spawnPos9, stamp.transform.rotation);
                    yield return new WaitForSeconds(1.2f);

                    audioM.Play();
                    Instantiate(stamp, spawnPos10, stamp.transform.rotation);
                    yield return new WaitForSeconds(0.45f);
                    Instantiate(stamp, spawnPos9, stamp.transform.rotation);
                    yield return new WaitForSeconds(0.45f);
                    Instantiate(stamp, spawnPos8, stamp.transform.rotation);
                    yield return new WaitForSeconds(0.45f);
                    Instantiate(stamp, spawnPos7, stamp.transform.rotation);
                    yield return new WaitForSeconds(0.45f);
                    Instantiate(stamp, spawnPos6, stamp.transform.rotation);
                    yield return new WaitForSeconds(1.2f);

                    transform.GetChild(0).GetComponent<Animator>().SetTrigger("Disappear");
                    yield return new WaitForSeconds(1f);
                    patternM.count += 1;
                    patternM.isPlaying = false;
                    gameObject.SetActive(false);
                }
            }
            yield return null;
        }
    }

    private void CheckAttack() //트리거 체크
    {
        if (audioM.clip == subscribeSong && audioM.isPlaying == true)
        {
            isReady = true;
        }
    }
}