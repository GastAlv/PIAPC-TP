using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoPersecucion : MonoBehaviour
{
    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
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
        Debug.Log("ON ENABLE PERSE" + _time);
        _agent.speed = 5f;
        _time = 0f;
    }


    void Update()
    {
        _time += Time.deltaTime;


        if (_time >= 2f)
        {
            
            _time = 0f;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoVelocidad);
            return;
            
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
