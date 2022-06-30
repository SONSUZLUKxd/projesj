using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Animator anim;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public Vector3 move;
    public float horizontal;
    public float vertical;
    public float sallanmaMiktarı;
    public Transform camShakeObject;
    public Slider energyBar;
    public GameObject background;
    public Rigidbody rb;
    public float speedd;
    private void Update()
    {
        Debug.Log(speedd);
        speedd = move.magnitude * 10;
        #region Movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        move = transform.right * horizontal + transform.forward * vertical;
        if (canMove)
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if(speedd > 1) { anim.SetBool("headbob", true); }
        else { anim.SetBool("headbob", false); }
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

        #region Run
        //bismillah
        if (Input.GetKey(KeyCode.LeftShift) && energyBar.value >= 1)
        {
            speed = 9.0f;
            energyBar.value -= 10 * Time.deltaTime;
        }
        else
        {
            energyBar.value += 6 * Time.deltaTime;
            speed = 5.0f;
        }
        if(energyBar.value < 8 && Input.GetKey(KeyCode.LeftShift))
        {
            background.GetComponent<Image>().color = Color.Lerp(background.GetComponent<Image>().color, Color.red, 5 * Time.deltaTime);
;       }
        else { background.GetComponent<Image>().color = Color.Lerp(background.GetComponent<Image>().color, Color.gray, 5 * Time.deltaTime); }
        #endregion
    }
}
