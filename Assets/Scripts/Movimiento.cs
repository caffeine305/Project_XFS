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

    void FixedUpdate() {

        //leer controles y generar el movimiento
        float moveX = Input.GetAxis("Horizontal") * movementSpeed;
        float moveY = Input.GetAxis("Vertical") * movementSpeed;
        float moveZ = movementSpeed;

        Vector3 moveShip = new Vector3(moveX, -moveY, moveZ);

        float turnX = moveY * tilt;
        float turnY = moveX * tilt;

        /*
        Vector3 tiltShip = new Vector3(0.0f, 0.0f, 0.0f);

        if (moveX > 0)
        {
            tiltShip = new Vector3(
                Mathf.Clamp(turnX, 0.0f, rotationbound.rotXMax),
                GetComponent<Transform>().rotation.eulerAngles.y,
                0.0f);
        }
        else { 
        tiltShip = new Vector3(
            Mathf.Clamp(-turnX, rotationbound.rotXMin, 0.0f), 
            GetComponent<Transform>().rotation.eulerAngles.y, 
            0.0f);
        }

        if (moveY > 0)
        {
            tiltShip = new Vector3(
                GetComponent<Transform>().rotation.eulerAngles.x,
                Mathf.Clamp(-turnY, 0.0f, rotationbound.rotYMax),
                0.0f);
        }
        else
        {
            tiltShip = new Vector3(
                GetComponent<Transform>().rotation.eulerAngles.x,
                Mathf.Clamp(turnY, rotationbound.rotYMin,0.0f),
                0.0f);
        }


        if(moveX == 0)
            tiltShip = new Vector3(0.0f, GetComponent<Transform>().rotation.eulerAngles.y, 0.0f);

        if (moveY == 0)
            tiltShip = new Vector3(GetComponent<Transform>().rotation.eulerAngles.x,0.0f, 0.0f);

        */
        //Mover la nave
        
        transform.Translate(moveShip * Time.deltaTime); //Desplaza la nave por la pantalla
        //transform.Rotate(tiltShip * Time.deltaTime); //Se supone que debería de rotar la nave, pero...

        //Evitar que la nave salga del obturador de la cámara
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax),
            GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + 20.0f
        );
       
        /*
        //Leer orientación
        Vector3 currentRotation = transform.eulerAngles;
        
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
