using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefMovement : MonoBehaviour
{
    private GameObject chefCameraRef;
    private Rigidbody chefRb;
    private ChefGround chefFeetRef;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed;
    public float jumpHeight;
    private float jumpVerticalSpeed;
    private float gravityValue = -9.81f;

    private void Start()
    {
        //controller = gameObject.GetComponent<CharacterController>();
        jumpVerticalSpeed = jumpHeight;
        chefRb = GetComponent<Rigidbody>();
        chefCameraRef = GetComponentInChildren<Transform>().gameObject;
        chefFeetRef = GetComponentInChildren<ChefGround>();
    }

    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //controller.Move(move * Time.deltaTime * playerSpeed);
        move = chefCameraRef.transform.TransformDirection(move);

        //this.transform.eulerAngles = new Vector3(0, chefCameraRef.transform.eulerAngles.y, 0);

        transform.Translate(move * playerSpeed * Time.deltaTime, Space.World);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && chefFeetRef.GetIsGrounded())
        {
            if(Input.GetAxis("Vertical") < 0)
            {
                if (jumpVerticalSpeed == jumpHeight)
                {
                    jumpVerticalSpeed /= 2;
                }
            }
            else
            {
                jumpVerticalSpeed = jumpHeight;
            }

            chefRb.velocity = new Vector3(chefRb.velocity.x, Mathf.Sqrt(jumpVerticalSpeed * -2.0f * gravityValue), chefRb.velocity.z);
        }

        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
    }
}