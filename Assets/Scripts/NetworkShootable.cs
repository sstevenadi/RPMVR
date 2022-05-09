using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class NetworkShootable : MonoBehaviourPunCallbacks
{
    [Header("Bullet GameObject")]
    public GameObject bullet;
    public GameObject muzzleFlash;
    public Transform shootPoint;

    [Header("Bullet Properties")]
    public float shootForce;

    private PhotonView _myPV;

    private void Awake()
    {
        _myPV = GetComponent<PhotonView>();
        gameObject.tag = "Guns";
    }
    
    public void NetworkShoot()
    {
        if (!_myPV.IsMine) return;
        photonView.RPC("Shoot", RpcTarget.AllBuffered);
    }
    
    [PunRPC]
    public void Shoot()
    {
        GameObject theBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);

        theBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);

        if (muzzleFlash != null)
        {
            Instantiate(muzzleFlash, shootPoint.position, Quaternion.identity);
        }
    }
}
