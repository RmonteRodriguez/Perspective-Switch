using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public CharacterController controller;
    public Transform cam;

    public GameObject frontCamera;
    public GameObject backCamera;

    public string currentScene;
    public string nextLevel;

    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public float gravity = -9.81f;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform groundCheck;

    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Movement
        if (Input.GetKeyDown(KeyCode.A))
        {
            velocity.z = 10f;
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            velocity.z = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            velocity.z = -10f;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            velocity.z = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            frontCamera.SetActive(true);
            backCamera.SetActive(false);

            velocity.x = speed;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            velocity.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            frontCamera.SetActive(false);
            backCamera.SetActive(true);
            velocity.x = -speed;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            velocity.x = 0;
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kill")
        {
            SceneManager.LoadScene(currentScene);
        }

        if (other.gameObject.tag == "Win")
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
