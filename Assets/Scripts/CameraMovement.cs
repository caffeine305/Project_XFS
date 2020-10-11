using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public int cameraMoveSpeed = 25;

    void FixedUpdate() {
        float moveZ = cameraMoveSpeed; 

        transform.Translate(Vector3.forward * moveZ * Time.deltaTime);
    }
}
