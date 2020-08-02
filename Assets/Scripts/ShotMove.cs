using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour {

    public float speed;
    
	void Start () {

        GetComponent<Rigidbody>().velocity = transform.right * speed;
        //Ojo con esto: El Spawn Point está rotado -90, por eso la dirección es transform.right.
        //Quizá mas adelante arregle el spawn point a 0° y la dirección a transform.forward (sería lo mas natural)
        //pero por lo pronto así jala bien.

	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }


}
