using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpiral : MonoBehaviour
{
    public float speed;
    public float amplitude;
    Transform spawnTransf;
    Vector3 posInicial;
    Vector3 espiral;
    float cadencia;
    float espera;
    
	// Use this for initialization
	void Start () {

        speed = 2.0f;
        amplitude = 5.0f;
        espera = Time.time;
        cadencia = 0.0f;
        posInicial = transform.position;
        }
	

	void FixedUpdate () {

            cadencia = Time.time - espera;
            //espiral = new Vector3(Mathf.Exp(0.15f * Time.time) * amplitude * Mathf.Cos(speed * Time.time), Mathf.Exp(0.15f * Time.time) * amplitude * Mathf.Sin(speed * Time.time) , -15.0f * Mathf.Exp(0.15f * Time.time) );
            espiral = new Vector3(Mathf.Exp(0.15f * cadencia) * amplitude * Mathf.Cos(speed * cadencia), Mathf.Exp(0.15f * cadencia) * amplitude * Mathf.Sin(speed * cadencia) , -15.0f * Mathf.Exp(0.15f * cadencia) );
            transform.position = posInicial+espiral;    
    }

}
