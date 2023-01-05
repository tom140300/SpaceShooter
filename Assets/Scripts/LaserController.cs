using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : DynamicObjectPooling<LaserController>
{
    [Header("Movement Variables")] public float speed;
    public int placement;
    public Rigidbody2D myRigidbody;

    public int damage;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this);
        }
    }

    public override Transform PoolContainer => GameManager.Pool;
    public override void OnSpawn()
    {
      gameObject.SetActive(true);
    }

    public void Init(Vector2 pos,Quaternion quaternion)
    {
        transform.rotation = quaternion;
        transform.position = pos;
        myRigidbody.velocity = myRigidbody.transform.up*speed;
        Destroy(this,3);
        
    }
}