using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accel : MonoBehaviour
{
    public float speed;
    Vector3 posInicial;
    Vector3 acelerar;
    float cadencia;
    float espera;

    
    void Start()
    {
        speed = 5.0f;
        espera = Time.time;
        cadencia = 0.0f;
        posInicial = transform.position;
    }


    void FixedUpdate()
    {
        cadencia = Time.time - espera;
        //oscilar = posInicial +new Vector3(amplitude * Mathf.Sin(speed * Time.time), 0.5f * amplitude * Mathf.Sin(speed * Time.time), amplitude * Mathf.Sin(speed * Mathf.PI* Time.time));
        acelerar = new Vector3(0,0 ,-speed*cadencia*speed*cadencia );
        //speed = 2.0f;
        transform.position = posInicial +acelerar;
    }
}
