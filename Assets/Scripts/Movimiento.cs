using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class Rotationbound
{
    public float rotXMin, rotXMax, rotYMin, rotYMax;
}

public class Movimiento : MonoBehaviour {

	public bool startedMovement = false;
	public int movementSpeed = 25;
    public Boundary boundary;
    public Rotationbound rotationbound;
    public float tilt;

	private Animator anim;

	void Awake () {
		anim = GetComponent <Animator> ();
	}

	void Start () {
		startedMovement = true;
	}

	void OnCollisionEnter (Collision hit) {

	}

	void Update () {
        

        if (Input.GetButtonDown ("Fire1")) {

        }
            	
	}

	void FixedUpdate () {

        //leer controles y generar el movimiento
        float moveX = Input.GetAxis("Horizontal") * movementSpeed;
        float moveY = Input.GetAxis("Vertical") * movementSpeed;
        float moveZ = movementSpeed;

        //Mover la nave
        transform.Rotate(new Vector3(moveY * Time.deltaTime, moveX * Time.deltaTime, 0.0f ));
        transform.Translate(Vector3.forward * moveZ * Time.deltaTime);

        //Evitar que la nave salga del obturador de la cámara
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax),
            GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + 20.0f
        );

        /*
        //Leer orientación

        //Investigar como modificar directamente un Cuaternio.

        Vector3 currentRotation = transform.rotation.eulerAngles;

        //Clampear orientación leída
        currentRotation.x = Mathf.Clamp(currentRotation.x, rotationbound.rotXMin, rotationbound.rotXMax);
        currentRotation.y = Mathf.Clamp(currentRotation.y, rotationbound.rotYMin, rotationbound.rotYMax);

        //Aplicar orientación Clampeada
        transform.rotation = Quaternion.Euler(currentRotation);            
        */

        //GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.z * -tilt);
        
    }
}
