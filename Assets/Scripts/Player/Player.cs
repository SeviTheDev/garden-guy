using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Camera
    private Camera mainCam;
    private Transform cameraPosition;

    // Movement
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        // Camera
        mainCam = Camera.main;
        cameraPosition = transform.Find("CameraFollow");

        // Movement
        moveSpeed /= 100;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        cameraFollow();

        move();
    }


    private void cameraFollow()
    {
        mainCam.transform.position = cameraPosition.position;
        mainCam.transform.rotation = cameraPosition.rotation;
    }

    private void move()
    {
        this.movement.x = Input.GetAxisRaw("Horizontal");
        this.movement.z = Input.GetAxisRaw("Vertical");

        this.rb.MovePosition(rb.position + movement * this.moveSpeed * Time.fixedDeltaTime);
    }
}
