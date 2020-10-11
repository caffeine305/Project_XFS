using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 moveDirection;
    public float moveSpeed;

    
    private void OnEnable()
    {
        Invoke("Remove",9f);
    }
    


    void FixedUpdate()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //transform.Rotate(new Vector3(9,6,3) );
    }

    public void SetMoveDirection(Vector3 dir)
    {
        moveDirection = dir;
    }
    
    private void Remove()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider otherCol)
    {
        if(otherCol.tag == "EnemyShot")
        {
            return;
        }
        otherCol.gameObject.SetActive(false);
        Remove();
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

}
