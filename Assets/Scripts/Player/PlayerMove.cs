using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 5.0f;
    public float leftrightSpeed = 4.0f;
    static public bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.forward * Time.deltaTime * runSpeed,Space.World);
        if (canMove == true)
        { 
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBounary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftrightSpeed);
            }
        }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBounary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftrightSpeed * -1);
                }
        }
        }

    }
}
