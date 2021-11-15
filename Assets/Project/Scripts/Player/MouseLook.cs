using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    private Transform playerTransform;
    public float mouseSensitivity = 200f;
    private float xRotation = 0;
    private bool isSettingPanelActive;

    private void OnEnable()
    {
        EventManager.isSettingPanelActive += CanLook;
    }

    private void OnDisable()
    {
        EventManager.isSettingPanelActive -= CanLook;
    }

    void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }


    void LateUpdate()
    {
        if (!isSettingPanelActive)
        {
            LookRightAndLeft();
            LookUpAndDown();
        }
   
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
        transform.localRotation = Quaternion.Euler(xRotation-15f, 0f, 0f); // I added 15 degree bias;
    }

    void CanLook(bool value)
    {
        isSettingPanelActive = value;
    }

}
