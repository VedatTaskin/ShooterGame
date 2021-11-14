using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int count = 10;
    public string name = "x";
    public List<GameObject> bulletList;

    void Awake()
    {
        InstantiateBullet();
    }

    void InstantiateBullet()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject instance = Instantiate(Resources.Load(name, typeof(GameObject)), transform) as GameObject;
            instance.SetActive(false);
            bulletList.Add(instance);
        }
    }

}
