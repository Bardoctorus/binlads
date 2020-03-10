using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class truckScriptableObject : ScriptableObject
{

    //Refactor this - it's meant to just be Consts you Cunst.

    public float turnSpeed;
    public float maxVelocity;
    //acceleration values for forward and backward movement
    public float maxMainAcceleration;
    public float mainAccelerationIncrement;
    
    //acceleration values for lateral movement
    public float maxLateralAcceleration;
    public float lateralAccelerationIncrement;
    //acceleration values for vertical movement
    public float maxVerticalAcceleration;
    public float verticalAccelerationIncrement;
   
}
