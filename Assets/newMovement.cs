using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class newMovement : MonoBehaviour
{

    Rigidbody rb;
    public truckScriptableObject truckScrip;


    private float mainAcceleration;
    private float lateralAcceleration;
    private float verticalAcceleration;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        
        //forward movement input to acceleration
        if (Input.GetKey(KeyCode.W))
        {
            mainAcceleration += truckScrip.mainAccelerationIncrement;
            mainAcceleration = Mathf.Clamp(mainAcceleration, 0, truckScrip.maxMainAcceleration);
            
        }
   

        if (Input.GetKey(KeyCode.S))
        {

            mainAcceleration -= truckScrip.mainAccelerationIncrement;
            mainAcceleration = Mathf.Clamp(mainAcceleration, -truckScrip.maxMainAcceleration /2,0) ;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            mainAcceleration = 0;
        }


        //vertical movement input to acceleration
        if (Input.GetKey(KeyCode.Space))
        {
            verticalAcceleration += truckScrip.verticalAccelerationIncrement;
            verticalAcceleration = Mathf.Clamp(verticalAcceleration, 0, truckScrip.maxVerticalAcceleration);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            verticalAcceleration -= truckScrip.verticalAccelerationIncrement;
            verticalAcceleration = Mathf.Clamp(verticalAcceleration, -truckScrip.maxVerticalAcceleration, 0);
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            verticalAcceleration = 0;
        }

     
        //lateral movement input to acceleration
        if (Input.GetKey(KeyCode.A))
        {
            lateralAcceleration -= truckScrip.lateralAccelerationIncrement;
            lateralAcceleration = Mathf.Clamp(lateralAcceleration, -truckScrip.maxLateralAcceleration, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {

            lateralAcceleration += truckScrip.lateralAccelerationIncrement;
            lateralAcceleration = Mathf.Clamp(lateralAcceleration,  0, truckScrip.maxLateralAcceleration);

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            lateralAcceleration = 0;
        }

        //rotating the camera
        transform.Rotate(Input.GetAxis("Mouse Y")* truckScrip.turnSpeed, Input.GetAxis("Mouse X") * truckScrip.turnSpeed, -Input.GetAxis("Mouse X") * truckScrip.turnSpeed);


        //assigning the velocity via acceleration and clamping it
        rb.velocity += transform.forward * mainAcceleration;
        rb.velocity += transform.right * lateralAcceleration;
        rb.velocity += transform.up * verticalAcceleration;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, truckScrip.maxVelocity);
     

        
        

        

    }
}
