using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public bool isPushed;
    float xPos;
    void Start()
    {
        xPos = transform.position.x;
    }

    void Update()
    {
        if(isPushed) {
            transform.position = new Vector3(xPos, transform.position.y);
        } else {
            xPos = transform.position.x;
        }
    }
}
