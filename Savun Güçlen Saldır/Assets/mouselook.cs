using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public PlayerController playerScript;

    [Range(50, 500)]
    public float sens;

    public Transform body;

    float xRot = 0f;

    public Transform leaner;
    public float zRot;
    bool canRotate = true;
    bool isRotating;

    public float smootingh;
    float currentRot;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }



    private void Update()
    {
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float roty = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= roty;

        transform.localRotation = Quaternion.Euler(xRot, 0f, currentRot);

        xRot = Mathf.Clamp(xRot, -80f, 80f);


        currentRot += rotX;
        currentRot = Mathf.Lerp(currentRot, 0, smootingh * Time.deltaTime);

        if (canRotate)
        {
            transform.localRotation = Quaternion.Euler(xRot, 0f, currentRot);
        }
        body.Rotate(Vector3.up * rotX);


        if (Input.GetKey(KeyCode.E))
        {
            zRot = Mathf.Lerp(zRot, -20.0f , 5f * Time.deltaTime);
            isRotating = true;
            canRotate = false;
            playerScript.speed = 2.5f;
        }
        if (Input.GetKeyUp(KeyCode.E)) // Input.GetKeyUp(KeyCode.E)
        {
            isRotating = false;
            canRotate = true;
            playerScript.speed = 5;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            zRot = Mathf. Lerp(zRot, 20.0f, 5f * Time.deltaTime);
            isRotating = true;
            canRotate = false;
            playerScript.speed = 2.5f;
        }

        if (Input.GetKeyUp(KeyCode.Q)) // Input.GetKeyUp(KeyCode.E)
        {
            isRotating = false;
            canRotate = true;
            playerScript.speed = 5;
        }

        if (!isRotating)
            zRot = Mathf.Lerp(zRot, 0.0f, 5f * Time.deltaTime);

        leaner.localRotation = Quaternion.Euler(0, 0, zRot);
    }
}
