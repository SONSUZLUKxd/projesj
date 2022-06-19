using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desh : MonoBehaviour
{
    public bool isDashing;

    private int dashAttempts;
    private float dashStarTime;

    [SerializeField] ParticleSystem forwardParticleSystem;
    [SerializeField] ParticleSystem backParticleSystem;
    [SerializeField] ParticleSystem leftParticleSystem;
    [SerializeField] ParticleSystem rightParticleSystem;
    PlayerController playerController;
    CharacterController CharacterController;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        CharacterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        HandleDash();
    }

    void HandleDash()
    {
        bool isTryingToDash = Input.GetKeyDown(KeyCode.X);

        if (isTryingToDash && !isDashing)
        {
            if (dashAttempts <= 50)
            {
                OnStartDash();
            }
        }

        if (isDashing)
        {
            if (Time.time - dashStarTime <= 0.4f)
            {
                if (playerController.movementVector.Equals(Vector3.zero))
                {
                    // Player is not giving any input, just dash forward
                    CharacterController.Move(playerController.move * 30f * Time.deltaTime);
                    if(playerController.move == Vector3.zero)
                    {
                        CharacterController.Move(transform.forward * 30f * Time.deltaTime);
                    }
                }
                else
                {
                    CharacterController.Move(playerController.movementVector.normalized * 30f * Time.deltaTime);
                }
            } else
            {
                OnEndDash();
            }
        }
    }

    void OnStartDash()
    {
        playDashParticles();
        isDashing = true;
        dashStarTime = Time.time;
        dashAttempts += 1;
    }

    void OnEndDash()
    {
        isDashing = false;
        dashStarTime = 0;
    }

    void playDashParticles()
    {
        if(playerController.vertical == 1 || playerController.vertical == 0)
        {
            forwardParticleSystem.Play();
        }
        if (playerController.vertical == -1)
        {
            backParticleSystem.Play();
        }
        if (playerController.horizontal == 1)
        {
            rightParticleSystem.Play();
        }
        if (playerController.horizontal == -1)
        {
            leftParticleSystem.Play();
        }
    }
}
