using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    Transform gunPoint;
    GameObject currentBullet;
    PoolManager pool;
    float nextFire;

    [Header("Bullet Settings")]
    public int numberOfBulletPerOneShot = 3; // how many bullet will be instaniated for each click
    public float attackRate = 3;            // according to attackrate we will change the time between shots;
 

    private void Start()
    {
        pool = GameObject.FindObjectOfType<PoolManager>();
        gunPoint = transform.GetChild(0).transform;

    }

    private void Update()
    {    
    
        if (Input.GetMouseButtonDown(0) && CanWeShoot())
        {
            StartCoroutine(ShootPlaner());
        }
    }

    IEnumerator ShootPlaner()
    {
        for (int i = 0; i < numberOfBulletPerOneShot; i++)
        {
            TakeBulletFromPool();
            Shoot();
            yield return new WaitForSeconds(attackRate / numberOfBulletPerOneShot);
        }

    }

    private void TakeBulletFromPool()
    {
        for (int i = 0; i <pool.bulletList.Count ; i++)
        {
            if (!pool.bulletList[i].activeInHierarchy)
            {
                currentBullet = pool.bulletList[i].gameObject;
                currentBullet.transform.position = gunPoint.position;
                currentBullet.transform.rotation = gunPoint.rotation;
                currentBullet.SetActive(true);
                break;
            }

            else
            {
                if (i==pool.bulletList.Count-1)
                {
                    GameObject newBullet = Instantiate(Resources.Load(pool.name, typeof(GameObject)), pool.transform) as GameObject;
                    newBullet.SetActive(false);
                    pool.bulletList.Add(newBullet);
                }
            }
        }
    }

    void Shoot()
    {
        // shoot doen't work :(

        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        //Debug.DrawRay(transform.position, forward, Color.green);
        //currentBullet.GetComponent<Rigidbody>().AddRelativeForce(gunPoint.transform.localPosition., ForceMode.Impulse);

        UIController.Instance.SetBulletCount(1);
    }

    bool CanWeShoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + attackRate; // belli aralýklarla ateþ edilebilecek "fireRate kontrol ediyor"
            return true;
        }
        else return false;
    }

}
