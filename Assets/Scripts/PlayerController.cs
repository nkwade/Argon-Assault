using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Recieve Inputs
    [SerializeField] private InputAction movement;
    [SerializeField] private InputAction fire;


    [SerializeField] private GameObject[] lasers;

    //Speed for x and y movement
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    //range for where the user can move the spaceship
    [SerializeField] private float xRange;
    [SerializeField] private float yRange;
    //factors based off the current user position used in calculating rotation
    [SerializeField] private float posPitchFactor = 2f;
    [SerializeField] private float posYawFactor = 2f;
    //factors based off the the current user input using in calculatin rotatio
    [SerializeField] private float inputPitchFactor = 10f;
    [SerializeField] private float inputRollFactor = 10f;

    //the current factor of the user pressing down the movement controls
    float horizontalThrow;
    float verticalThrow;
    

    private void OnEnable() {
        movement.Enable();
        fire.Enable();
    }
    private void OnDisable() {
        movement.Disable();
        fire.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
        ProcessFiring();
    }

    

    private void ProcessMovement()
    {
        horizontalThrow = movement.ReadValue<Vector2>().x;
        verticalThrow = movement.ReadValue<Vector2>().y;

        float newX = transform.localPosition.x + (horizontalThrow * Time.deltaTime * xSpeed);
        float newY = transform.localPosition.y + (verticalThrow * Time.deltaTime * ySpeed);

        float xClamp = Mathf.Clamp(newX, -xRange, xRange);
        float yClamp = Mathf.Clamp(newY, -yRange, yRange);


        transform.localPosition = new Vector3(xClamp, yClamp, transform.localPosition.z);
    }
    
    private void ProcessRotation()
    {
        float pitch = (transform.localPosition.y * posPitchFactor) + (verticalThrow * inputPitchFactor); //pitch according to pos plus pitch according to the player pushing up
        float yaw = transform.localPosition.x * posYawFactor; //yaw according to current position on screen
        float roll = horizontalThrow * inputRollFactor; //roll according to current input from player

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    
    private void ProcessFiring()
    {
        if (fire.IsPressed()) {
            EnableLasers(true);
        } else {
            EnableLasers(false);
        }
    }
    private void EnableLasers(bool set)
    {
        foreach (GameObject laser in lasers) {
            ParticleSystem particleSystem = laser.GetComponent<ParticleSystem>();
            var em = particleSystem.emission;
            em.enabled = set;
        }
    }
}
