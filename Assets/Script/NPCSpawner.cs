using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public int npcToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        int count = 0;
        while (count < npcToSpawn)
        {
            GameObject obj = Instantiate(npcPrefab);
            Transform child = transform.GetChild(0);
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForSeconds(0);

            count++;
        }
    }
}
