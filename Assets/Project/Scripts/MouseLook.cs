using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    private Transform playerTransform;
    private GameObject bulletPool;
    private float mouseSensitivity = 200f;
    private float xRotation = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        LookRightAndLeft();
        LookUpAndDown();    
    }

    void LookRightAndLeft()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        playerTransform.Rotate(Vector3.up * mouseX);
    }

    void LookUpAndDown()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30f, 30f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

}
