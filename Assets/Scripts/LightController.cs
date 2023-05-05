using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour

{
    private MaquinaDeEstados maquinaDeEstados;
    private EstadoPersecucion estadoPersecucion;
    private EstadoVelocidad estadoVelocidad;

    public Light luz;
    public Color color;


    public float intervaloLuz = 10f;
    public float tiempoEncendidaMin = 3f;
    public float tiempoEncendidaMax = 5f;

    private float tiempoDesdeLuz;
    private float tiempoEncendida;

    void Start()
    {
        // obtener objeto y luego los componentes.

        maquinaDeEstados = GameObject.Find("Enemy").GetComponent<MaquinaDeEstados>();
        

    }

    void OnEnable()
    {
        estadoPersecucion = GameObject.Find("Enemy").GetComponent<EstadoPersecucion>();
        estadoVelocidad = GameObject.Find("Enemy").GetComponent<EstadoVelocidad>();
    }
    void Update()
    {

        //if (maquinaDeEstados.getEstadoActual != maquinaDeEstados.EstadoPersecucion)
        //{
        //    return;
        //}

        tiempoDesdeLuz += Time.deltaTime;
        if (tiempoDesdeLuz >= intervaloLuz)
        {
            this.GetComponent<BoxCollider>().enabled = true;
            luz.enabled = true;
            tiempoDesdeLuz = 0f;
            tiempoEncendida = 0f;
            //float posX = Random.Range(-8f, 8f);
            //float posZ = Random.Range(-8f, 8f);

            //luz.transform.position = new Vector3(transform.position.x + posX, transform.position.y , transform.position.z + posZ);

        }

        // Se comprueba si la luz está encendida
        if (luz.enabled)
        {
            // Se comprueba si ha pasado suficiente tiempo para apagar la luz
            tiempoEncendida += Time.deltaTime;
            if (tiempoEncendida >= Random.Range(tiempoEncendidaMin, tiempoEncendidaMax))
            {
                this.GetComponent<BoxCollider>().enabled = false;
                luz.color = color;
                luz.enabled = false;
            }
        }

        
       
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        this.GetComponent<BoxCollider>().enabled = false;
    //        luz.color = color;


    //        if (maquinaDeEstados.getEstadoActual == maquinaDeEstados.EstadoPersecucion)
    //        {
    //            estadoPersecucion.playerIsSafe = true;
    //            return;


    //        }
    //        if (maquinaDeEstados.getEstadoActual == maquinaDeEstados.EstadoVelocidad)
    //        {
    //            estadoVelocidad.playerIsSafe = true;
    //            return;
    //        }
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{

    //    //luz.color = Color.white;

    //    //luz.enabled = false;
    //}
}
