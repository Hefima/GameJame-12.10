using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HefimaLibrary
{
    public class HefiMath : MonoBehaviour
    {
        public static Vector3 RandomVector3_Plane(float radius, Vector3 middlePoint)
        {
            return new Vector3(Random.Range(-radius, radius) + middlePoint.x, middlePoint.y, Random.Range(-radius, radius) + middlePoint.z);
        }

        public static Vector3 RandomVector3(float radius, Vector3 middlePoint)
        {
            return new Vector3(Random.Range(-radius, radius) + middlePoint.x, Random.Range(-radius, radius) + middlePoint.y, Random.Range(-radius, radius) + middlePoint.z);
        }
    }


    public class LUL : MonoBehaviour
    {
        
    }
}


