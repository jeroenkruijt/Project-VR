using UnityEngine;
using System.Collections;

public class testmovement : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // Move the object forward along its z axis 1 unit/second.
        transform.Translate(Vector3.forward * Time.deltaTime);

    }

    void OnMouseDown()
    {
        anim.SetTrigger("Run");
    }
}