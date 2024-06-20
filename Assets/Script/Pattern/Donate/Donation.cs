using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donation : MonoBehaviour
{
    public AudioSource audioM;

    public AudioClip no;

    private void Awake()
    {
        audioM = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().audioSource;
    }

    private void FixedUpdate()
    {
        if(audioM.clip == no && audioM.isPlaying == true)
        {
            transform.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
}
