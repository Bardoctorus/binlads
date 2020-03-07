using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class newMovement : MonoBehaviour
{

    Rigidbody rb;
    float fwdSpeed;
    float sideSpeed;
    float prevSpeed;
    float upSpeed;
    public float turnSpeed;
    public float speedMult;
    public float nudgeForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        //TODO Rework the side thrusters to allow for more subtle movements
        // in general, ther eneeds to be a ramp up of accelleration that resets to 0 after each affect.
        // Think about the nature of code examples where accelleration was the acting force in that moment
        // to change the velocity, before returning to 0

        //also all of this should probably happen elsewhere.
        if (Input.GetKey(KeyCode.W))
        {
            fwdSpeed += 0.1f; 
        }

        if (Input.GetKey(KeyCode.S))
        {
            fwdSpeed -= 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += transform.up * speedMult;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.velocity += -transform.up * speedMult;
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity += -transform.right * speedMult;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity += transform.right * speedMult;
        }


        transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse X"));

        if(fwdSpeed != prevSpeed)
        {
            float acceleration = fwdSpeed - prevSpeed;
            rb.velocity += transform.forward * acceleration * speedMult;
        }

        prevSpeed = fwdSpeed;

    }
}
