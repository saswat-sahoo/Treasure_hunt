using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public float speed=10;
    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public float gravity = -9.8f;
    [HideInInspector]
    public Vector3 velocity;
    [HideInInspector]
    public Transform groundcheck;
    [HideInInspector]
    public float groundDistance = 0.4f;
    [HideInInspector]
    public LayerMask groundMask;
    public GameObject pause;
        bool isGrounded;
    private void Start()
    {
        pause.SetActive(false);

    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y<0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * y;
       
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6f;
            controller.Move(move * speed * Time.deltaTime);
        }

       

        else
        {
            speed = 3f;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            pause.SetActive(true);

        }
        if (pause.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        




        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    public void Continue()
    {
        pause.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
