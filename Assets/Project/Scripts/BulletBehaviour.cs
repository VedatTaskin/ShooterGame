using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Bir merminin �zeliklerini burada de�i�tirece�iz.
    //merminin tek at��ta k�e kere �a�r�laca�� ba�ka yerde

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
