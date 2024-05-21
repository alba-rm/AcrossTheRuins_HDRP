using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IASpeed : MonoBehaviour
{
   public NavMeshAgent agentNat;
   public NavMeshAgent agentJac;

    // Start is called before the first frame update
    void Awake()
    {
   
    }
    void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                agentJac.speed = 1;
                agentNat.speed = 1;
            }
        }

    void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                agentJac.speed = 6;
                agentNat.speed = 6;
            }
        }
}
