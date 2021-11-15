using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    protected Transform gunPoint;
    protected GameObject currentBullet;
    PoolManager pool;
    float nextFire;

    [Header("Bullet Settings")]
    public int numberOfBulletPerOneShot = 3; // how many bullet will be instaniated for each click
    public float attackRate = 3;            // according to attackrate we will change the time between shots;
    public float bulletSpeed = 20;
    private float screenHeight;
    private bool isSettingPanelActive;

    private void OnEnable()
    {
        EventManager.isSettingPanelActive += SettingPanelStatus;
    }

    private void OnDisable()
    {
        EventManager.isSettingPanelActive -= SettingPanelStatus;
    }

    private void Start()
    {
        pool = GameObject.FindObjectOfType<PoolManager>();
        gunPoint = transform.GetChild(0).transform;
        screenHeight = Screen.height;
    }

    private void Update()
    {
        if (!isSettingPanelActive)
        {
            if (Input.mousePosition.y < screenHeight * 0.8f)
            {
                if (Input.GetMouseButtonDown(0) && CanWeShoot())
                {
                    StartCoroutine(ShootPlaner());
                }
            }
        }
    }

    IEnumerator ShootPlaner()
    {
        for (int i = 0; i < numberOfBulletPerOneShot; i++)
        {
            TakeBulletFromPool();
            Shoot();            
            yield return new WaitForSeconds(0.1f);

            //maybe we want to set the shoot time interval according to attackRate
            //yield return new WaitForSeconds(attackRate / numberOfBulletPerOneShot); 
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
                currentBullet.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                currentBullet.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                currentBullet.SetActive(true);
                break;
            }

            else
            {
                if (i==pool.bulletList.Count-1)
                {
                    GameObject newBullet = Instantiate(pool.bulletList[i], pool.transform) as GameObject;
                    newBullet.SetActive(false);
                    pool.bulletList.Add(newBullet);
                }
            }
        }
    }

    protected virtual void Shoot()
    {
        currentBullet.GetComponent<Rigidbody>().AddForce(gunPoint.transform.right * bulletSpeed, ForceMode.VelocityChange);
        UIManager.Instance.SetBulletCount(1);
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

    void SettingPanelStatus( bool value)
    {
        isSettingPanelActive = value;
    }

}
