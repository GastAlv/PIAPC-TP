using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoMerodeador : MonoBehaviour
{
    private NavMeshAgent _agent;
    private MeshRenderer _capsule;
    private Light _luz;
    private MaquinaDeEstados _maquinaDeEstado;

    // Start is called before the first frame update
   
    void OnEnable()
    {
        _maquinaDeEstado = GetComponent<MaquinaDeEstados>();
        _luz = GameObject.Find("GameObject").transform.Find("Spot Light").GetComponent<Light>();
        _capsule = transform.Find("Capsule").GetComponent<MeshRenderer>();
        _capsule.material.color = Color.white;
        _agent = GetComponent<NavMeshAgent>();
        _agent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_luz.enabled == false)
        { 
            _agent.isStopped = false;
            _capsule.material.color = Color.blue;
            _maquinaDeEstado.ActivarEstado(_maquinaDeEstado.EstadoPersecucion);    

        }

    }
}
