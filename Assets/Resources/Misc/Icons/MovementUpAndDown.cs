using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUpAndDown : MonoBehaviour
{
    private float speed = 5f;
    private float height = 0.5f;
 
    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z) ;
    }
}
