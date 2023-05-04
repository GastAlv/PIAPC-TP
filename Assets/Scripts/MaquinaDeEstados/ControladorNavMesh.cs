using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour
{
    [HideInInspector] public Transform perseguirObjetivo;

    
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarPuntoDestino(Vector3 puntoDestino)
    {
        navMeshAgent.destination = puntoDestino;
        navMeshAgent.isStopped = false;

    }

    public void ActualizarPuntoDestino()
    {
        ActualizarPuntoDestino(perseguirObjetivo.position);
    }

    public void StopNavMeshAgent()
    {
        navMeshAgent.isStopped = true;
    }

    public bool weHaveArrived()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;

    }
}
