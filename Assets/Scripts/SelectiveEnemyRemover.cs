using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectiveEnemyRemover : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCol)
    {
        var foo = otherCol.transform.parent.gameObject;
        if(otherCol.tag == "Enemy" || otherCol.tag == "EnemyShot")
        {
            Destroy(foo);
        }
    }
}
