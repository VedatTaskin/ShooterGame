using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Resource : https://www.youtube.com/watch?v=_QajrabyTJc 

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 moveDirection = (Vector3.forward * zAxis) + (Vector3.right * xAxis);

        transform.Translate(moveDirection*speed * Time.deltaTime,Space.Self);

    }
}


