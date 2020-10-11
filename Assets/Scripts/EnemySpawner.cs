using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    void SetPosition()
    {
        //float x = Random.Range(-5.0f, 5.0f);
        //float y = Random.Range(-5.0f, 5.0f);
        float x = -150f;
        float y = 95f;
        float z = 400f;
        transform.position = new Vector3(x, y, z);
    }


    void Start()
    {
        //SetPosition();
        Instantiate(enemy, transform.position,transform.rotation);
    }
}