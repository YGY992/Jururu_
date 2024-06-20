using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private static Score instance;

    public static Score Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new Score();
            }
            return instance;
        }
    }

    public float score = 0;
}
