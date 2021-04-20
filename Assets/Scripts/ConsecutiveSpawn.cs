using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsecutiveSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject enemy;
    public int numberOfEnemies;
    private Vector3 spawnPos;
    void Start()
    {
        spawnPos = transform.position;
    }

    private void OnTriggerEnter(Collider otherCol)
    {
        if(otherCol.tag == "Spawniard") 
        {
            StartCoroutine(SpawnEachXSecs());
        }
    }

    IEnumerator SpawnEachXSecs()
    {
        for(int i = 0;i<numberOfEnemies;i++){
            Instantiate(enemy,spawnPos,this.transform.rotation);
            yield return new WaitForSeconds (0.25f);
        }
    }


}
