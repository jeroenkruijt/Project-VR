using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Event : MonoBehaviour
{
    private float bikeDistance;
    private bool reached=false;
    private GameObject bike;
    public float distance;
    public GameObject pedestrian;
    public Vector3 destination;

    private void Start()
    {
        bike = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        bikeDistance = Vector3.Distance(bike.transform.position, transform.position);
        if (bikeDistance <= distance && reached == false)
        {
            reached = true;
            SpawnNPC();
        }
    }
    private void SpawnNPC()
    {
        if (Random.Range(0, 10) > 0)
        {
           GameObject npc= Instantiate(pedestrian, transform.position, Quaternion.identity);
            npc.GetComponent<Pedestrian>().destination = destination;


        }
    }
}
