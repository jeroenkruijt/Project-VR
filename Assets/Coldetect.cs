using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coldetect : MonoBehaviour
{
    int colcount = 0;
    private void OnCollisionEnter(Collision other)
    {
        colcount++;
        Debug.Log(other.collider.GetType());
        if (other.collider.GetType() == typeof(BoxCollider))
        {
            Debug.Log("gameover");
            
        }
        if (other.collider.GetType() == typeof(SphereCollider))
        {
            Debug.Log(colcount);
        }
    }

}
