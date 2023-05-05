using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoPersecucion : MonoBehaviour
{
    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    private PlayerController playerController;
    private NavMeshAgent _agent;
    private float _time = 0f;
    



    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        _agent = GetComponent<NavMeshAgent>();
        

    }
    //private void Start()
    //{
    //    Debug.Log("START PERSE");
    //    _agent.speed = 5f;
    //    _time = 0f;

    //}
    void OnEnable()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _agent.speed = 5f;
        _time = 0f;
        
    }


    void Update()
    {
        _time += Time.deltaTime;

        if (playerController.playerIsSafe)
        {
            playerController.playerIsSafe = false;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoMerodeador);
            return;
            
        }

        if (_time >= 2f)
        {
            
            _time = 0f;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoVelocidad);
            
            
        }
        RaycastHit hit;
        if (!controladorVision.PuedeVerAlJugador(out hit, true))
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }
        controladorNavMesh.ActualizarPuntoDestino();

    }
}
