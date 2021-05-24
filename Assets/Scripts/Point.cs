using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public float speed;
    Vector3 posInicial;
    Vector3 apuntar;
    GameObject playero;
    Rigidbody rig;
    Transform basecita;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        speed = 250.0f;
        
        basecita = gameObject.GetComponentInParent(typeof(Transform)) as Transform;
        posInicial = basecita.position;
        playero = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        apuntar = (playero.transform.position - posInicial).normalized * speed * Time.time;
        rig.velocity = apuntar;
        Debug.Log("dirección Bala:"+rig.velocity);
        Debug.Log("Apuntar:"+apuntar);
        Debug.Log("Posición Nave:"+playero.transform.position);


        if(playero.transform.position.z +3.0f > transform.position.z)
        {
            Destroy(transform.root.gameObject);
        }
    }
}
