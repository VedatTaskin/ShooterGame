using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Bir merminin �zeliklerini burada de�i�tirece�iz.
    //merminin tek at��ta ka� kere �a�r�laca�� ba�ka yerde
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
