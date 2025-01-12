using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class SteeringBehaviorBase : MonoBehaviour  
{
    private Rigidbody2D rb;  
    private Steering[] steerings;  
    public float maxAcceleration = 10f;  
    public float maxAngularAcceleration = 3f;  
    public float drag = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        steerings = GetComponents<Steering>();  
        rb.linearDamping = drag;
    }
}

public abstract class Steering : MonoBehaviour
{
    public abstract SteeringData GetSteering(SteeringBehaviorBase  steeringbase);
}

public class SteeringData
{
    public Vector3 linear;  
    public float angular;

    public SteeringData()
    {
        linear = Vector3.zero;  angular = 0f;
    }
}