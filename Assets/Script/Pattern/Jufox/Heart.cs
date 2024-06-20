using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public AudioSource sound;

    private Animator anime;

    public AudioClip attack;

    private void Awake()
    {
        anime = transform.GetComponent<Animator>();
        
    }
    private void Start()
    {
        sound = transform.GetComponentInParent<AudioSource>();
    }

    private void OnEnable()
    {
        anime.enabled = true;
    }

    private void FixedUpdate()
    {
        if (sound.clip == attack)
        {
            anime.SetTrigger("Attack");
        }
    }

    public void Destroy()
    {
        anime.enabled = false;
        gameObject.SetActive(false);
    }
}
