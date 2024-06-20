using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPool : MonoBehaviour
{
    public Vector3 playerPos;
    public AudioSource audioM;
    public AudioClip heartAppear;
    public AudioClip notThat;
    public AudioClip attack;

    public AudioSource sound;
    private void Awake()
    {
        sound = transform.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        for(int i = 0; i<30; i++)
        {
            transform.GetChild(i).GetComponent<Animator>().enabled = true;
        }
        StartCoroutine(Generate());
    }

    private void FixedUpdate()
    {
        playerPos = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);
        
    }

    private IEnumerator Generate()
    {
        yield return new WaitForSeconds(0.5f);
        sound.clip = heartAppear;
        for (int i = 0; i < 30; i++)
        {
            transform.GetChild(i).GetComponent<Transform>().position = playerPos;
            transform.GetChild(i).gameObject.SetActive(true);
            sound.Play();
            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.7f);
        audioM.clip = notThat;
        audioM.Play();
        sound.volume = 1f;
        yield return new WaitForSeconds(0.05f);
        sound.clip = attack;
        sound.Play();

        yield return null;
    }
}
