using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkObject : MonoBehaviour
{
    public float objectHealth;

    private void Awake()
    {
        gameObject.tag = "Object";
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            objectHealth = objectHealth - collision.gameObject.GetComponent<NetworkBullet>().bulletDamage;
        }
    }
}
