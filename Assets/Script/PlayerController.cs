using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody2D rigid;
    public BoxCollider2D col;
    public LifeScript lifeScript;
    public Animator anime;

    public float movespeed;

    public bool Damaged;

    private void Awake()
    {
        Damaged = false;
        playerTransform = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anime = GetComponent<Animator>();


        movespeed = 4.5f;
    }

    private void FixedUpdate()
    {
        Move();

        if(Damaged == true)
        {
            OnDamaged();
            Damaged = false;
        }
    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        playerTransform.Translate(horizontal * movespeed * Time.deltaTime, 0f, 0f);
        playerTransform.Translate(0f, vertical * movespeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Attack")
        {
            Damaged = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Barrier")
        {
            gameObject.layer = 7;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Barrier")
        {
            gameObject.layer = 6;
        } 
        
    }

    private void OnDamaged()
    {
        Debug.Log("피격당함");
        //플레이어 무적
        transform.GetComponent<AudioSource>().Play();
        anime.SetBool("Damaged", true);
        gameObject.layer = 7;
        Invoke("OffDamaged", 2.5f);

        //라이프 감소
        lifeScript.life += 1;
        lifeScript.GetComponent<Transform>().GetChild(lifeScript.life).gameObject.SetActive(false);
        if(lifeScript.life >= 3)
        {
            SceneManager.LoadScene("GameOver");
        }

        
    }

    private void OffDamaged()
    {
        anime.SetBool("Damaged", false);
        gameObject.layer = 6;
    }
}