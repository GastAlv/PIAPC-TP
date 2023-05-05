using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public class EstadoVelocidad : MonoBehaviour
{
    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    private EstadoPersecucion estadoPersecucion;
    private PlayerController playerController;
    private NavMeshAgent _agent;
    private RaycastHit hit;
    private float _time;
    public bool playerIsSafe = false;

    

    void OnEnable()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        _agent = GetComponent<NavMeshAgent>();
        estadoPersecucion = GetComponent<EstadoPersecucion>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _agent.speed = 10f;
        _time = 0f;
        playerIsSafe = false;

    }
    //private void Start()
    //{
    //    Debug.Log("START");
    //    _agent.speed = 10f;
    //    _time = 0f;
        
    //}
   
    // Update is called once per frame
    void Update()
    {
        controladorNavMesh.ActualizarPuntoDestino();
        _time += Time.deltaTime;
        if (_time >= 3f && controladorVision.PuedeVerAlJugador(out hit, true))
        {
            
            _time = 0f;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }
        if (playerController.playerIsSafe) {
            playerController.playerIsSafe = false;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoMerodeador);
            return;
        }
        if (!controladorVision.PuedeVerAlJugador(out hit, true)) {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }

    }
}
