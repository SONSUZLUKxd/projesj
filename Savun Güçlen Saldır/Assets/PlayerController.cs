using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    public bool isGrounded;

    public Transform ground;
    public float distance = 0.3f;

    public float speed;
    public float jumpHeight;
    public float gravity;
    public Vector3 movementVector = Vector3.zero;
    public float originalHeight;
    public float crouchHeight;
    public Transform checker2;
    public bool canMove = true;
    public Vector3 inputVector = Vector3.zero;
    public LayerMask mask;
    public Transform cam;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public Vector3 move;
    public float horizontal;
    public float vertical;
    public float sallanmaMiktarı;
    public Transform camShakeObject;
    private void Update()
    {
        #region Movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        move = transform.right * horizontal + transform.forward * vertical;
        if (canMove)
        {
            controller.Move(move * speed * Time.deltaTime);
            
        }
        if(controller.velocity.magnitude > 0.9)
        {
            cam.position = camShakeObject.position + Random.insideUnitSphere * sallanmaMiktarı;
        } 

        #endregion

        #region Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        #endregion

        #region Gravity

        isGrounded = Physics.CheckSphere(ground.position, distance, mask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        #endregion

        #region Basic Crouch 
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = crouchHeight;
            ground.position = new Vector3(ground.position.x, ground.position.y + 2, ground.position.z);
            speed = 2.0f;
        }


        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = 5.0f;
            controller.height = originalHeight;
            ground.position = checker2.position;
        }
         #endregion


        //fjdjkfdkhkjh
        
        #region
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 9.0f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
        }
        
        #endregion
    }
}
