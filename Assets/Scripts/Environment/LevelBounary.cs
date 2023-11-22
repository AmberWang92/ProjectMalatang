using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounary : MonoBehaviour
{
    public static float leftSide = -3.5f;
    public static float rightSide = 3.5f;
    public float internalLfet;
    public float internalRfet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        internalLfet = leftSide;
        internalRfet = rightSide;
    }
}
