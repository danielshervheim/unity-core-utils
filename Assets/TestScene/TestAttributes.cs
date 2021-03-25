using DSS.CoreUtils.Attributes;

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttributes : MonoBehaviour
{
    [ReadOnly]
    public int x = 0;

    [ReadOnlyRuntime]
    public int y = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
