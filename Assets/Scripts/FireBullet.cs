using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    public int bulletAmount;
    //  public float fireRate;

    private Vector3 bulletMoveDirection;
    private Vector3 startPoint;

    void Awake()
    {
        GetComponent<Transform>();
        //startPoint = transform.position;
        startPoint = new Vector3(0,0,0);
    }

    void Start()
    {
        InvokeRepeating("Fire",0f,0.3f);
    }

    private void Fire()
    {
        float angleStep = 360f / bulletAmount;
        float angle = 0;

        for (int i = 0; i<= bulletAmount - 1; i++)
        {

            float bulDirx = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180f); 
            float bulDiry = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            //float bulDirz = startPoint.z + Mathf.Sin((angle * Mathf.PI) / 360f);

            Vector3 bulMoveVector = new Vector3(bulDirx,bulDiry,0);
            Vector3 bulDir = (bulMoveVector - startPoint).normalized;
            
            Debug.Log("Starting Poing: " + startPoint);
            Debug.Log("Bullet Move: " + bulMoveVector);

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;

            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            angle += angleStep;
            
        }
    }

}
