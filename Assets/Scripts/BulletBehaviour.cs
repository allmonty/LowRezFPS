﻿using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    public float pushSpeed = 2.0f;
    public float verticalSpeed = 10.0f;
    public int damage = 1;

    [SerializeField] string targetLayer = "None";

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer(targetLayer))
        {
            pushAway(col.gameObject.GetComponent<Rigidbody>());
            Destroy(gameObject);
            col.gameObject.GetComponent<HealthControl>().takeDamage(damage);
        }
    }

    void pushAway(Rigidbody target)
    {
        Vector3 pushVelocity = rigid.velocity.normalized * pushSpeed;
        pushVelocity.y = verticalSpeed;
        target.velocity = pushVelocity + (Vector3.up * target.velocity.y);
    }
}
