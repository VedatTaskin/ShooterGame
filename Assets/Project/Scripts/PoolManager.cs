using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int count = 10;
    public string name = "x";
    public List<GameObject> bulletList;
    public GameData data;

    void Awake()
    {
        InstantiateBullet(0,count);
    }

    public void InstantiateBullet(int startPos, int numberOfBullet)
    {
        for (int i = startPos; i < numberOfBullet; i++)
        {
            GameObject instance = Instantiate(Resources.Load(name, typeof(GameObject)), transform) as GameObject;
            instance.transform.localScale *= data.SizeScaleFactor;
            instance.GetComponent<BulletBehaviour>().explosionTimer = data.ExplosionTimer;                     

            if (data.Color =="red")
            {
                instance.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (data.Color == "black")
            {
                instance.GetComponent<MeshRenderer>().material.color = Color.black;
            }
            instance.SetActive(false);
            bulletList.Add(instance);
        }

    }

}
