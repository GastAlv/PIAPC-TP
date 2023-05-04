using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAlerta : MonoBehaviour
{
    public float velocidadGiro = 120f;
    public float duracionBusqueda = 4f;


    private MaquinaDeEstados maquinaDeEstado;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    private float tiempoBuscando;

    void Awake()
    {
        maquinaDeEstado = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
    }
    private void OnEnable()
    {
        controladorNavMesh.StopNavMeshAgent();
        tiempoBuscando = 0;


    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (controladorVision.PuedeVerAlJugador(out hit))
        {
            controladorNavMesh.perseguirObjetivo = hit.transform;
            maquinaDeEstado.ActivarEstado(maquinaDeEstado.EstadoPersecucion);
            return;
        }

        transform.Rotate(0f, velocidadGiro * Time.deltaTime, 0f);
        tiempoBuscando += Time.deltaTime;
        if (tiempoBuscando >= duracionBusqueda)
        {
            maquinaDeEstado.ActivarEstado(maquinaDeEstado.EstadoPatrulla);
            return;
        }
    }

}
