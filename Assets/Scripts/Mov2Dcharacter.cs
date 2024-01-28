using System.Collections;

using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]

public class Mov2Dcharacter : MonoBehaviour // https://www.youtube.com/watch?v=1uW-GbHrtQc

{

    public float walkSpeed = 6f;

    public float runSpeed = 12f;

    public float jumpPower = 7f;

    public float gravity = 10f;

    public float lookSpeed = 2f;

    public float lookXLimit = 45f;

    public float defaultHeight = 2f;

    public float crouchHeight = 1f;

    public float crouchSpeed = 3f;



    private Vector3 moveDirection = Vector3.zero;

    private float rotationX = 0;

    private CharacterController characterController;
    


    private bool canMove = true;



    void Start()

    {

        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

    }



    void Update()

    {

      //  Vector3 forward = transform.TransformDirection(Vector3.forward);

     //   Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 right = Vector3.right;

        float orientationY = 180f;
        float orientationLocalX = 0f;

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        orientationLocalX = Input.GetAxis("Vertical")*10;

        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        orientationY = 180 - Input.GetAxis("Horizontal") * 90;

        float movementDirectionY = moveDirection.y;

        moveDirection = right * curSpeedY;


        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)

        {
            orientationLocalX = 15f;
            moveDirection.y = jumpPower;

        }

        else

        {

            moveDirection.y = movementDirectionY;

        }



        if (!characterController.isGrounded)

        {
            orientationLocalX = 15f;
            moveDirection.y -= gravity * Time.deltaTime;

        }



        if (Input.GetKey(KeyCode.R) && canMove)

        {
            orientationLocalX -= 5f;
            characterController.height = crouchHeight;

            walkSpeed = crouchSpeed;

            runSpeed = crouchSpeed;



        }

        else

        {

            characterController.height = defaultHeight;

            walkSpeed = 6f;

            runSpeed = 12f;

        }

      
        characterController.Move(moveDirection * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0); // TO_FIX (!!!)
      

        if (canMove)

        {

         
            transform.rotation = Quaternion.Euler(0, orientationY, 0);

            transform.rotation *= Quaternion.Euler(orientationLocalX, 0, 0);
        }

    }

}