using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColllisionController : MonoBehaviour
{
    int colcount = 0;
    private void OnCollisionEnter(Collision other)
    {
        colcount++;
        Debug.Log(other.collider.GetType());
        if (other.collider.GetType() == typeof(BoxCollider))
        {
            Debug.Log("gameover");
            SceneManager.LoadScene("AccidentScreen");

        }
        if (other.collider.GetType() == typeof(SphereCollider))
        {
            Debug.Log(colcount);
        }
    }
}
