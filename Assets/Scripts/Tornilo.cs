using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornillo : MonoBehaviour
{
    public float speed;
    public float amplitude;
    Vector3 posInicial;
    Vector3 oscilar;
    
	// Use this for initialization
	void Start () {

        speed = 2.0f;
        amplitude = 10.0f;
        posInicial = transform.position;
        }
	

	void FixedUpdate () {

        //oscilar = posInicial +new Vector3(amplitude * Mathf.Sin(speed * Time.time), 0.5f * amplitude * Mathf.Sin(speed * Time.time), amplitude * Mathf.Sin(speed * Mathf.PI* Time.time));
        //oscilar = posInicial +new Vector3(amplitude * Mathf.Sin(speed * Time.time), 1, 1);
        oscilar = posInicial +new Vector3(amplitude * Mathf.Sin(speed * Time.time), amplitude * Mathf.Cos(speed * Time.time), 1);
        //speed = 2.0f;
        transform.position = oscilar;
    }

}
