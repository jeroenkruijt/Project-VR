using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColllisionController : MonoBehaviour
{
   // static Text warning;//
    public string warningstring;
    int colcount = 0;
    private void Start()
    {
       // warning = GameObject.Find("Text").GetComponent<Text>();//
    }
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
            //warning.text = warningstring;
            Debug.Log(colcount);
        }
    }
}
