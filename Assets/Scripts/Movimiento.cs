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

	//private Animator anim;


	void Awake () {
		//anim = GetComponent <Animator> ();
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

        Vector3 moveShip = new Vector3(moveX, -moveY, moveZ);
        Vector3 tiltShip = new Vector3(moveY*tilt,moveX*tilt,0.0f);
           
        //Mover la nave
        //transform.Rotate(new Vector3(moveY * 2 * Time.deltaTime, moveX * 2 * Time.deltaTime, 0.0f));
        //transform.Translate(Vector3.forward * moveZ * Time.deltaTime);

        transform.Translate(moveShip * Time.deltaTime);
        transform.Rotate(tiltShip * Time.deltaTime);

        //Evitar que la nave salga del obturador de la cámara
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax),
            GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + 20.0f
        );
       
        /*
        //Leer orientación
        Vector3 currentRotation = transform.rotation.eulerAngles;
        
        //Clampear orientación leída
        currentRotation.x = Mathf.Clamp(currentRotation.x, rotationbound.rotXMin, rotationbound.rotXMax);
        currentRotation.y = Mathf.Clamp(currentRotation.y, rotationbound.rotYMin,rotationbound.rotYMax);
        currentRotation.z = 0.0f;
        //(No entiendo por que se traba...)

        //Aplicar rotación clampeada
        this.transform.rotation = Quaternion.Euler(currentRotation);
        */
    }
}
