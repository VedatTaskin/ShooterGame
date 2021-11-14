using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Bir merminin özeliklerini burada deðiþtireceðiz.
    //merminin tek atýþta kaç kere çaðrýlacaðý baþka yerde
    public float explosionTimer;


    private void OnEnable()
    {
        Invoke("OnDisable", explosionTimer);
    }

    private void OnDisable()
    {
        transform.gameObject.SetActive(false);
    }

}
