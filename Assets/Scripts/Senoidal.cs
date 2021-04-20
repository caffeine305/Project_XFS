using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senoidal : MonoBehaviour
{
    public float speed;
    public float amplitude;
    Vector3 posInicial;
    Vector3 oscilar;
    float cadencia;
    float espera;
    
	// Use this for initialization
	void Start () {

        speed = 5.0f;
        amplitude = 25.0f;
        espera = Time.time;
        cadencia = 0.0f;
        posInicial = transform.position;
        }
	

	void FixedUpdate () {

        cadencia = Time.time - espera;
        //oscilar = posInicial +new Vector3(amplitude * Mathf.Sin(speed * Time.time), 0.5f * amplitude * Mathf.Sin(speed * Time.time), amplitude * Mathf.Sin(speed * Mathf.PI* Time.time));
        oscilar = new Vector3((-0.5f)*amplitude*cadencia,amplitude * Mathf.Sin(speed * cadencia), 1);
        //speed = 2.0f;
        transform.position = posInicial +oscilar;
    }

}
