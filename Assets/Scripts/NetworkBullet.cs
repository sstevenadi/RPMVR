using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkBullet : MonoBehaviourPunCallbacks
{
    [Header("The Bullet Properties")]
    public float bulletLifeTime;
    public float bulletDamage;
    
    // Start is called before the first frame update

    private void Awake()
    {
        gameObject.tag = "Bullets";
    }

    void Start()
    {
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Guns"))
        {
            Debug.Log("It did hit " + collision.gameObject.name);
            Destroy(gameObject);
        }
    }
}
