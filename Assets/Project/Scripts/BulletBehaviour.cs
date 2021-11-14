using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Bir merminin özeliklerini burada deðiþtireceðiz.
    //merminin tek atýþta kçe kere çaðrýlacaðý baþka yerde

    public float bulletLifeTime = 1f;

    private void OnEnable()
    {
        Invoke("OnDisable", 5);
    }

    private void OnDisable()
    {
        transform.gameObject.SetActive(false);
    }

}
