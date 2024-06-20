using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenFlower : MonoBehaviour
{
    private void Awake()
    {
        transform.position = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 1.4f));
    }
}
