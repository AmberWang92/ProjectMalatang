using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableEntity : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    protected Rigidbody rb;
    protected Vector3 moveDirection = Vector3.forward;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected abstract void Move();

    public abstract void PerformAction();

}

