using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camAnimation : MonoBehaviour
{
    public CharacterController playerController;
    public Animation anim;
    private bool isMoving;

    private bool left;
    private bool right;
    void CameraAnimationa()
    {
        if(playerController.isGrounded == true)
        {
            if(isMoving == true)
            {
                if(left == true)
                {
                    if (!anim.isPlaying)
                    {
                        anim.Play("walkleft");
                        left = false;
                        right = true;
                    }
                }
            }
        }
    }
    
    void Start()
    {
        left = true;
        right = false;
        
    }

   
    void Update()
    {
        float ınputX = Input.GetAxis("Horizontel");
        float InputY = Input.GetAxis("Vertical");

        if (ınputX != 0 || InputY != 0)
        {
            isMoving = true;
        }
        else if (ınputX == 0 && InputY == 0)
        {
            isMoving = false;
        }
        CameraAnimationa();
    }
        
    
}
