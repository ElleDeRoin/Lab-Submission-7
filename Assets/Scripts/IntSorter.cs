using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntSorter : MonoBehaviour
{
    NumberArray a;

    void Sort()
    {
        Array.Sort(a.numbers, 0, a.numbers.Length);
    }
}


