using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject PatternManager;

    public GameObject LaughPrefab;

    public GameObject Flower1Prefab;
    public GameObject Flower2Prefab;
    public GameObject Flower3Prefab;

    public GameObject HeartPrefab;

    private GameObject[] Laugh;
    private GameObject[] Flower1;
    private GameObject[] Flower2;
    private GameObject[] Flower3;

    private GameObject[] Heart;

    private void Awake()
    {
        PatternManager = GameObject.FindGameObjectWithTag("Pattern");
        Laugh = new GameObject[27];

        Flower1 = new GameObject[60];
        Flower2 = new GameObject[40];
        Flower3 = new GameObject[50];

        Heart = new GameObject[30];

        Generate();
    }

    private void Generate()
    {
        //익익익
        for(int i=0; i<Laugh.Length; i++)
        {
            Laugh[i] = Instantiate(LaughPrefab);
            Laugh[i].transform.parent = PatternManager.GetComponent<Transform>().GetChild(1).transform; //자식으로 보내기
            Laugh[i].SetActive(false);
        }

        //어딨게? 꽃잎
        for(int i = 0; i<Flower1.Length; i++)
        {
            Flower1[i] = Instantiate(Flower1Prefab);
            Flower1[i].transform.parent = PatternManager.GetComponent<Transform>().GetChild(2).GetChild(0).GetChild(0).transform;
            Flower1[i].SetActive(false);
        }
        for (int i = 0; i < Flower2.Length; i++)
        {
            Flower2[i] = Instantiate(Flower2Prefab);
            Flower2[i].transform.parent = PatternManager.GetComponent<Transform>().GetChild(2).GetChild(0).GetChild(1).transform;
            Flower2[i].SetActive(false);
        }
        for (int i = 0; i < Flower3.Length; i++)
        {
            Flower3[i] = Instantiate(Flower3Prefab);
            Flower3[i].transform.parent = PatternManager.GetComponent<Transform>().GetChild(2).GetChild(0).GetChild(2).transform;
            Flower3[i].SetActive(false);
        }

        //주폭스 하트
        for (int i = 0; i < Heart.Length; i++)
        {
            Heart[i] = Instantiate(HeartPrefab);
            Heart[i].transform.parent = PatternManager.GetComponent<Transform>().GetChild(5).GetChild(2).transform;
            Heart[i].SetActive(false);
        }
    }
}
