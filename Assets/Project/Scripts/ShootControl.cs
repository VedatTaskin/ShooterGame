using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    Transform gunPoint;
    GameObject currentBullet;
    PoolManager pool;

    private void Awake()
    {
        gunPoint = transform.GetChild(0).transform;   
        
    }

    private void Start()
    {
        pool = GameObject.FindObjectOfType<PoolManager>();       

    }

    private void Update()
    {    
    
        if (Input.GetMouseButtonDown(0))
        {
            TakeBulletFromPool();       
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


}
