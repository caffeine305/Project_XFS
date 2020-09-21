using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShotBehaviour : MonoBehaviour {

    public float speed = 20.0f;
    public Transform parentTransform; 
    private Rigidbody body;
    
    
	void Start () 
    {
        body = GetComponent<Rigidbody>();
        parentTransform = GetComponent<Transform>();
        //rigidbody.velocity = transform.right * speed;

        //Ojo con esto: El Spawn Point está rotado -90, por eso la dirección es transform.right.
        //Quizá mas adelante arregle el spawn point a 0° y la dirección a transform.forward (sería lo mas natural)
        //pero por lo pronto así jala bien.

	}

    private void OnTriggerEnter(Collider otherCol)
    {
        if(otherCol.tag == "EnemyShot")
        {
            return;
        }
        Destroy(otherCol.gameObject);
        Destroy(this.gameObject);
    }

    void Update()
    {
        //Vector3 orientation = parentTransf orm.position;
        Vector3 orientation = parentTransform.forward; //
        Vector3 dirEuler = Vector3.Normalize(orientation);
        Vector3 direction = new Vector3(1,0,0);

        Vector3 effectiveDir = direction + dirEuler ;
        effectiveDir = Vector3.Normalize(effectiveDir);

        transform.Rotate(new Vector3(Random.Range(-1f,1f),Random.Range(1f,2f),Random.Range(1f,4f))* 15* Time.deltaTime );
        //transform.Translate(Vector3.Normalize(orientation) * Time.deltaTime);

        //body.AddForce(effectiveDir * speed);
        body.AddForce(orientation * speed);
        Destroy(this.gameObject,7f);
    }


}
