using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] tr;
    public int index;

    NavMeshAgent nav;
    void Start()
    {
        index = 0;
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination (tr[index].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.remainingDistance < 1.0f)
        {
            index++;
            if(index > tr.Length - 1)
                index = 0;
            nav.SetDestination(tr[index].position);
        }
    }
}
