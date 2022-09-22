using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject hitEffect;
    
    void Start()
    {
        rb.velocity = transform.right * ShootController.bulletSpeed;
        Destroy(this.gameObject,1f);
    }

    void OnCollisionEnter2D(Collision2D colliderObject)
    {
        if(colliderObject.gameObject.tag == "Enemy")
        {
            //GameObject hitInstance = Instantiate(hitEffect,this.transform.position,transform.rotation);
            colliderObject.gameObject.GetComponent<EnemyStats>().TakeDamage(ShootController.bulletDamage);

            Destroy(this.gameObject, 0.01f); 
        }
    }
}
