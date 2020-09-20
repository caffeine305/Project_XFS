using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoSemilla : MonoBehaviour
{
    public GameObject semilla;
    public Transform broteSemilla;
    public List<Transform> brote;

    public float fireRate = 0.01f;

    void Start()
    {
        StartCoroutine(generarDisparo(fireRate));
        brote = new List<Transform>(){
            broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla,
            broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla,
            broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla,broteSemilla
        };

    }
 
    IEnumerator generarDisparo(float fireRate)
    {
        while(true)
        {
            for (int i=0; i < 23 ; i++)
            {
                Instantiate(semilla,brote[i].position, brote[i].rotation);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
 
} 