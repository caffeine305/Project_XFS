using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnContactDestroy : MonoBehaviour {

    void OnTriggerEnter(Collider otherCol)
    {
        if (otherCol.tag == "Bounds")
        {
            return;
        }

        Destroy(otherCol.gameObject);
        Destroy(this.gameObject);
    }

}
