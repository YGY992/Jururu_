using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Score score_;
    public float score = 0f;

    public Text scoretext;

    private void Awake()
    {
        scoretext = GetComponent<Text>();
        score_ = Score.Instance;
    }

    private void FixedUpdate()
    {
        score = score_.score;
        scoretext.text = score.ToString("N0");
    }
}
