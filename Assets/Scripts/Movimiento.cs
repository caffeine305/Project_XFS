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

    public GameObject shot;
    public Transform spawnPoint;
    public float fireRate = 0.5f;
    private float nextShot = 0.25f;


	void Start () {
		startedMovement = true;
	}

    void Update()
    {

        if ((Input.GetButton("Fire1")) && (Time.time > nextShot))
        {
            nextShot = Time.time + fireRate;
            Instantiate(shot, spawnPoint.position, spawnPoint.rotation);
        }
    }

    void FixedUpdate() {

        //leer controles y generar el movimiento
        float moveX = Input.GetAxis("Horizontal") * movementSpeed;
        float moveY = Input.GetAxis("Vertical") * movementSpeed;
        float moveZ = movementSpeed;

        Vector3 moveShip = new Vector3(moveX, -moveY, moveZ);

        GetComponent<Rigidbody>().velocity = moveShip;

        //Mover la nave

        transform.Translate(moveShip * Time.deltaTime); //Desplaza la nave por la pantalla

        //Evitar que la nave salga del obturador de la cámara

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax),
            GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + 20.0f
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.y * -tilt, GetComponent<Rigidbody>().velocity.x * tilt, 0.0f);

        /*
        if (moveX == 0)
        {
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.y * -tilt, 0.0f, 0.0f);
        }
        else
        {
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, GetComponent<Rigidbody>().velocity.x * tilt, 0.0f);
        }
        */
    }
}
