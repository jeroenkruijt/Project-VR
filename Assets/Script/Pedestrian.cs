using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public Vector3 destination;
    
    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 3);
    }
}
