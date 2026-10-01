using System;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3; //if we wanted to edit UI or change scenes, these things wouldn't be accessible through an MB script


public class PlayerBehavior : MonoBehaviour
{
    private InputAction upButton;
    private InputAction downButton;
    private InputAction leftButton;
    private InputAction rightButton;

    private AudioSource ohGodOhNo;
    public Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        startPosition = transform.position;
    }

    void Start()
    {
        upButton = InputSystem.actions.FindAction("Up");
        downButton = InputSystem.actions.FindAction("Down");
        leftButton = InputSystem.actions.FindAction("Left");
        
        rightButton = InputSystem.actions.FindAction("Right");

        ohGodOhNo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = transform.position; // vector3 refers to the XYZ position of the thing we're talking about
        if (playerPosition.y>= 6f)
        {
            playerPosition.y = 0f;
        }
        if (playerPosition.y<= -6f)
        {
            playerPosition.y = 0f;
        }
        if (playerPosition.x<= -11f)
        {
            playerPosition.x = 0f;
        }
        if (playerPosition.x>= 11f)
        {
            playerPosition.x = 0f;
        }
        if(upButton.IsPressed())
        {
            playerPosition.y += 2 * Time.deltaTime;
            Debug.Log("go up");
        }
        if(downButton.IsPressed())
        {
            playerPosition.y -= 2 * Time.deltaTime;
            Debug.Log("go down");
        }

        if (leftButton.IsPressed())
        {
            playerPosition.x -= 2 * Time.deltaTime;
            Debug.Log("go left");
        }

        if (rightButton.IsPressed())
        {
            playerPosition.x += 2 * Time.deltaTime;
            Debug.Log("go right");
        }

        transform.position = playerPosition;
    }
    
    
    void OnTriggerEnter(Collider other) // this gives us information on the thing we collided with !!
    {
        ohGodOhNo.Play();
        Debug.Log("ew ew ew gross it's an [OBJECT]");
        if (other.gameObject.tag == "Enemy")
        {
            transform.position = startPosition;
        }
    }
}
