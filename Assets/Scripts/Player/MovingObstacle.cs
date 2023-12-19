using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MovableEntity
{
    public Transform pointATransform;
    public Transform pointBTransform;
    private Vector3 target;

    protected override void Start()
    {
        base.Start();
        target = pointBTransform.position;   
    }

    protected override void Move()
    {
        
        Vector3 direction = (target - transform.position).normalized;

        
        rb.velocity = direction * moveSpeed;

        
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            
            target = target == pointATransform.position ? pointBTransform.position : pointATransform.position;
        }
    }

    void FixedUpdate()
    {
        Move();  
    }
}

