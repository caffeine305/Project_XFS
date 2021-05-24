using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSpawnBullet : MonoBehaviour
{
    public GameObject bullet;
    public float cadence;
    GameObject playero;

    void Awake()
    {
        cadence = 0.75f;
        playero = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("FireBullets",0f,cadence);
    }

    private void FireBullets()
    {
        Instantiate(bullet, this.transform.position,this.transform.rotation);
    }

    void FixedUpdate()
    {
        //transform.position = posInicial + apuntar;

        if(playero.transform.position.z +15.0f > transform.position.z)
        {
            Destroy(transform.root.gameObject);
        }

    }

}
