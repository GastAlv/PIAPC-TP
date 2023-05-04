using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EstadoPatrulla : MonoBehaviour
{
    public Transform[] WayPoints;
    private ControladorNavMesh controladorNavMesh;
    private MaquinaDeEstados maquinaDeEstado;
    private ControladorVision controladorVision;


    private int siguientePunto;


    void Awake()
    {
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        maquinaDeEstado = GetComponent<MaquinaDeEstados>();
        controladorVision = GetComponent<ControladorVision>();  
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
        if (controladorNavMesh.weHaveArrived())
        {
            siguientePunto = (siguientePunto + 1) % WayPoints.Length;
            actualizarWayPoint();
        }



    }

    void OnEnable()
    {
        actualizarWayPoint();
    }

    void actualizarWayPoint() {

        controladorNavMesh.ActualizarPuntoDestino(WayPoints[siguientePunto].position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enabled) {

            maquinaDeEstado.ActivarEstado(maquinaDeEstado.EstadoAlerta);

        }

    }
}
