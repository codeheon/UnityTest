using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = target.position + new Vector3(0, 3, -7);     
    }
}
