using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower2 : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        for (int i = 0; i < 40; i++)
        {
            transform.GetChild(i).GetComponent<Transform>().position = new Vector2(Random.Range(-8.1f, 8.1f), Random.Range(-4.2f, 4.2f));
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.03f);
        }
    }
}
