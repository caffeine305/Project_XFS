using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvoker : MonoBehaviour
{
    [SerializeField]
    public GameObject enemy;
    void Start()
    {
        //Instantiate(enemy,transform.position,transform.rotation);
        //enemy.SetActive(false);
    }

    private void OnTriggerEnter(Collider otherCol)
    {
        if(otherCol.tag == "Spawniard") 
        {
            Instantiate(enemy,transform.position,transform.rotation);
            //enemy.SetActive(true);
        }
    }
}
