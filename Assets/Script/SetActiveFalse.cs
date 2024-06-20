using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalse : MonoBehaviour
{
    private void Disappear()
    {
        transform.GetComponent<Animator>().enabled = false;
        gameObject.SetActive(false);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public void AudioPlay()
    {
        transform.GetComponent<AudioSource>().Play();
    }

    public void SDTagChange()
    {
        transform.GetChild(0).gameObject.tag = "SD";
    }
}
