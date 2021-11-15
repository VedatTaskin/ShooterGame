using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Bir merminin �zeliklerini burada de�i�tirece�iz.
    //merminin tek at��ta ka� kere �a�r�laca�� ba�ka yerde
    [HideInInspector] public float explosionTimer;
    [HideInInspector] public bool explosionTimerIsActive; 


    private void OnEnable()
    {
        if (explosionTimerIsActive)
        {
            Invoke("OnDisable", explosionTimer);
        }
        else
        {
            Invoke("OnDisable", 5);  // Default we will deactivate a bullet in 5 seconds
        }
        
    }

    private void OnDisable()
    {
        transform.gameObject.SetActive(false);
    }

}
