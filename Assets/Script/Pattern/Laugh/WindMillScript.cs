using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillScript : MonoBehaviour
{
    public Animator anime;
    public Animator LeftW;
    public Animator RightW;
    public Animator UpperW;
    public Animator LowerW;


    public LaughCtrl laughC;

    public Vector3 Rot;

    private bool isSpin;

    public float spin;
    private float spinSpeed;

    private void Awake()
    {
        spinSpeed = 55f;
        LeftW = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        UpperW = transform.GetChild(0).GetChild(1).GetComponent<Animator>();
        LowerW = transform.GetChild(0).GetChild(2).GetComponent<Animator>();
        RightW = transform.GetChild(0).GetChild(3).GetComponent<Animator>();


        anime = GetComponent<Animator>();

        //anime.SetTrigger("Windmill_Ready");
        //Invoke("Setting", 3f);
        //Invoke("SpinCheck", 6f);
        //Invoke("WindmillFalse", 1f);
    }

    private void OnEnable()
    {
        isSpin = false;

        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(3).gameObject.SetActive(true);

        anime.enabled = true;
        LeftW.enabled = true;
        RightW.enabled = true;
        LowerW.enabled = true;
        UpperW.enabled = true;


        spin = 0f;
        Rot = new Vector3(0f, 0f, 0f);
        transform.GetChild(0).GetComponent<Transform>().eulerAngles = Rot;

        anime.SetTrigger("Windmill_Ready");
        Invoke("Setting", 2f);
        Invoke("SpinCheck", 5f);
        Invoke("WindmillFalse", 1f);
    }

    private void FixedUpdate()
    {
        if (isSpin == true)
        {
            laughC.isWindmill = false;
            Spin();
            if(spin >= 10f)
            {
                isSpin = false;
                anime.SetTrigger("Windmill_Disappear");
                LeftW.SetTrigger("Disappear");
                RightW.SetTrigger("Disappear");
                LowerW.SetTrigger("Disappear");
                UpperW.SetTrigger("Disappear");
            }
        }
    }

    public void Setting()
    {
        LeftW.SetTrigger("Open");
        RightW.SetTrigger("Open");
        UpperW.SetTrigger("Open");
        LowerW.SetTrigger("Open");
    }

    private void SpinCheck()
    {
        isSpin = true;
    }

    private void Spin()
    {
        spin += Time.deltaTime;

        Rot.x = transform.GetChild(0).GetComponent<Transform>().localRotation.x;
        Rot.y = transform.GetChild(0).GetComponent<Transform>().localRotation.y;
        Rot.z = spin * spinSpeed;

        transform.GetChild(0).GetComponent<Transform>().eulerAngles = Rot;
    }
    private void WindmillFalse()
    {
        laughC.isWindmill = false;
    }
    public void SetActiveFalse()
    {
        anime.enabled = false;
        gameObject.SetActive(false);
    }
}
