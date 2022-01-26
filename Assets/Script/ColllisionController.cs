using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColllisionController : MonoBehaviour
{
    public Text warning;
    [TextArea(3, 10)]
    public string[] warningstring;
    int colcount = 0;
    private void Start()
    {
    }
    private void OnCollisionEnter(Collision other)
    {
        colcount++;
        Debug.Log(other.collider.GetType());
        
            Debug.Log("gameover");
            SceneManager.LoadScene("AccidentScreen");

        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("slightcollision");
        warning.text = warningstring[Random.Range(0, warningstring.Length)];
    }
}
