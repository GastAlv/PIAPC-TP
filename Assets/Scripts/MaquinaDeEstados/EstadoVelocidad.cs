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
    private NavMeshAgent _agent;
    private RaycastHit hit;
    private float _time;

    

    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        _agent = GetComponent<NavMeshAgent>();
        
    }
    //private void Start()
    //{
    //    Debug.Log("START");
    //    _agent.speed = 10f;
    //    _time = 0f;
        
    //}
    void OnEnable()
    {
        Debug.Log("ON ENABLE");
        _agent.speed = 10f;
        _time = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        controladorNavMesh.ActualizarPuntoDestino();
        _time += Time.deltaTime;
        if (_time >= 4f && controladorVision.PuedeVerAlJugador(out hit, true))
        {
            
            _time = 0f;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }
        if (!controladorVision.PuedeVerAlJugador(out hit, true)) {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }
    }
}
