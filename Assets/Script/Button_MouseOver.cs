using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_MouseOver : MonoBehaviour
{
    public Animator anime;
    private void Awake()
    {
        anime = transform.GetComponent<Animator>();
    }
    public void MouseOver()
    {
        anime.SetBool("MouseOver", true);
    }
    public void MouseExit()
    {
        anime.SetBool("MouseOver", false);
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void Replay()
    {
        SceneManager.LoadScene("InGame");
    }
}
