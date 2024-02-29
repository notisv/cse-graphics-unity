using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform lookTarget;
    public float speed = 12f;
    public float verticalSpeed = 200f;
    public float mouseSensitivity = 3f;
    float yaw;
    float pitch;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;

        // force player to look at the target object
        transform.LookAt(lookTarget.transform);
    }

    // Update is called once per frame
    void Update()
    {

        // Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        // Movement according to WASD keys
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        // Mouse look + Movement when W,D are pressed
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.rotation = Quaternion.Euler(pitch, yaw, 0);

        // Move Camera up and down with Q,E
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
        }

    }
}
