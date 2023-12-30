using System;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public static FirstPersonMovement shared;
    public float speed = 5;
    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    Rigidbody rigidbady;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();
    
    public FirstPersonMovement()
    {
        shared = this;
    }

    void Awake()
    {
        // Get the rigidbody on this.
        rigidbady = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input. 
        // проверка булевой "на земле" чтобы не ускорятся в воздухе
        if(GroundCheck.singletone.isGrounded == true) { }
            IsRunning = canRun && Input.GetKey(runningKey);
       
        
        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbady.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbady.velocity.y, targetVelocity.y);
    }
}