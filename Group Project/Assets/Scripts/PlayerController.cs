using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Rigidbody playerRB;

    [Header("Mouse Control")]
    public Vector2 mouseTurn;
    public float sensitivity;

    [Header("Movement Control")]
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    public float maxSpeed;
    public float accelerationSpeed;

    [Header("Dash")]
    public float dashForce;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();// Get this shit to work or lock in where it need in a code or something, idk..

        Cursor.lockState = CursorLockMode.Locked;// Mouse locked and invisible

    }

    // Update is called once per frame
    void Update()
    {
        //Mouse Input
        mouseTurn.x += Input.GetAxis("Mouse X") * sensitivity;
        mouseTurn.y += Input.GetAxis("Mouse Y") * sensitivity;

        //Movement Input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        //Rotation by Mouse
        transform.localRotation = Quaternion.Euler(0, mouseTurn.x, 0);

        //Movement
        HandleMovement();

    }

    void HandleMovement()
    {
        if (verticalInput != 0f || horizontalInput != 0f) speed = Mathf.Min(maxSpeed, speed + accelerationSpeed);

        else speed = Mathf.Max(0f, speed - accelerationSpeed);

        transform.Translate(speed * Time.deltaTime * new Vector3(horizontalInput, 0, verticalInput));

    }


}
