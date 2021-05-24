using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public float speed;
    Vector3 posInicial;
    Vector3 buscar;
    GameObject playero;
    float cadencia;
    float espera;

    void Start()
    {
        speed = 2.0f;
        espera = Time.time;
        cadencia = 0.0f;
        posInicial = transform.position;
        playero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cadencia = Time.time - espera;
        buscar = (playero.transform.position - posInicial).normalized*speed*cadencia*speed*cadencia;
        transform.position = posInicial + buscar;

        if(playero.transform.position.z +15.0f > transform.position.z)
        {
            Destroy(this.gameObject);
        }

    }
}
