using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughAttack : MonoBehaviour
{
    public BoxCollider2D col;
    public AudioManager audioM;
    public Animator anime;

    public Vector3 Center = new Vector3(0,0,0);

    public bool isAttack;
    public bool isGather;

    private void Awake()
    {
        isAttack = false;
        isGather = false;
        col = GetComponent<BoxCollider2D>();
        anime = GetComponent<Animator>();
        anime.enabled = true;
        audioM = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        anime.enabled = true;
    }

    private void FixedUpdate()
    {
        if(isGather == true)
        {
            Gather();
        }
        if (transform.position == Center)
        {
            isGather = false;
            transform.GetComponentInParent<LaughCtrl>().isWindmill = true;
            Invoke("Del", 0.5f);
        }
    }


    public void Attack()
    {
        anime.SetBool("Attack", true);
    }

    public void Gather()
    {
        Vector3 Pos;
        Pos.x = Mathf.Lerp(transform.position.x, Center.x, 0.1f);
        Pos.y = Mathf.Lerp(transform.position.y, Center.y, 0.1f);
        Pos.z = transform.position.z;

        transform.position = Pos;
    }

    public void Del()
    {
        anime.enabled = false;
        gameObject.SetActive(false);
    }
}
