using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShoot : ShootControl
{

    public int maxRandomAngle;
    private int randomness; 

    protected override void Shoot()
    {
        randomness = Random.Range(-maxRandomAngle,maxRandomAngle);
        Vector3 direction = gunPoint.transform.right;
        direction = Quaternion.Euler(0,randomness, 0) * direction;
        currentBullet.GetComponent<Rigidbody>().AddForce( direction* bulletSpeed, ForceMode.VelocityChange);
        UIManager.Instance.SetBulletCount(1);
    }
}
