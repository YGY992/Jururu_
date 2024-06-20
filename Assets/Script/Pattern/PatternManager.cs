using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public AudioManager audioM;
    public string Pattern = "Rest"; //��������
    public string[] Patterns = new string[6];
    public string temp;
    public int ran;
    public int count;
    public bool isPlaying = false;
    private void Awake()
    {
        count = 0;
        Patterns[0] = "Donate"; //�������� //�Ϸ� 
        Patterns[1] = "Laugh"; //������ ���� //�Ϸ�
        Patterns[2] = "Where"; //�����? ã�ƺ�~ //�Ϸ�
        Patterns[3] = "Contract"; //�������� ���Ű��~ //�Ϸ�
        Patterns[4] = "Hentai"; //��Ÿ��.. ���� �� �����! // �Ϸ�
        Patterns[5] = "Jufox"; //�������� �Ǵٽ� ����Ҹ��� ��±��� // �Ϸ�


        PatternShuffle();
    }
    private void FixedUpdate()
    {
        //����� �Ŵ����� ���� ����
        if(isPlaying == false)
        {
            if(count < 6)
            {
                audioM.GetComponent<AudioManager>().ChangeAudio(Patterns[count]);
                isPlaying = true;
                Debug.Log("���� ����" + Patterns[count]);
            }
            else
            {
                PatternShuffle();
                count = 0;
                audioM.GetComponent<AudioManager>().ChangeAudio(Patterns[count]);

            }
        }
    }
    private void PatternShuffle()
    {
        for (int i = 0; i < Patterns.Length; i++)
        {
            ran = Random.Range(0, Patterns.Length);
            temp = Patterns[i];
            Patterns[i] = Patterns[ran];
            Patterns[ran] = temp;
        }

        for (int i = 0; i < Patterns.Length; i++)
        {
            Debug.Log(Patterns[i]);
        }
    }

    private void ChangeAudio()
    {
        audioM.GetComponent<AudioManager>().ChangeAudio(Patterns[count]);
        isPlaying = true;
    }

    public void PatternOn(int num)
    {
        transform.GetChild(num).gameObject.SetActive(true);
    }
}
