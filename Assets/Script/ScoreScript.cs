using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public float time = 0f;
    public float score = 0f;
    public Score score_;

    public Text scoretext;

    private void Awake()
    {
        scoretext = GetComponent<Text>();
        score_ = Score.Instance;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        score = time * 43;
        score_.score = score;
        scoretext.text = score.ToString("N0");
    }
}
