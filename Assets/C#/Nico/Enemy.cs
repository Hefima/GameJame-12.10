using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HefimaLibrary;

public class Enemy : MonoBehaviour
{
    public Vector3 middlePoint;

    void Update()
    {
        HefiMath.RandomVector3(50, middlePoint);
    }
}
