using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PoopNavmesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    private void Awake()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
       // navMeshAgent.updateUpAxis = false;
       // navMeshAgent.updateRotation = false;
    }

    private void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;

        if(navMeshAgent.isStopped)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
