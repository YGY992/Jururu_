using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTF : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            ColOff();
            Invoke("ColOn", 5f);
        }
    }

    private void ColOff()
    {
        transform.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void ColOn()
    {
        transform.GetComponent<BoxCollider2D>().enabled = true;
    }
}
