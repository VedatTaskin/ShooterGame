using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Resource : https://www.youtube.com/watch?v=_QajrabyTJc 

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isSettingPanelActive;

    private void OnEnable()
    {
        EventManager.isSettingPanelActive += CanMove;
    }

    private void OnDisable()
    {
        EventManager.isSettingPanelActive -= CanMove;
    }

    void FixedUpdate()
    {
        if (!isSettingPanelActive)
        {
            Move();
        }        
    }

    void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 moveDirection = (Vector3.forward * zAxis) + (Vector3.right * xAxis);

        if (Vector3.SqrMagnitude (moveDirection) >0.1f)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.position = transform.position;
        }
    }

    void CanMove(bool value)
    {
        isSettingPanelActive = value;
    }
}


