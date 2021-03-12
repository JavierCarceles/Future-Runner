using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetGenerator : MonoBehaviour
{

    public GameObject[] calles;
    public float ZSpawn = 0;
    public float CalleLenght = 50;
    public int callesCount = 6;

    private List<GameObject> activeCalles = new List<GameObject>();

    public Transform jugadorTransform;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < callesCount; i++) {
            if (i == 0)
            {
                SpawnCalle(0);
            }
            else
            {
                SpawnCalle(UnityEngine.Random.Range(0, calles.Length));
            }            
        }
    }

    void Update()
    {
        if (jugadorTransform.position.z - 45 > ZSpawn - (CalleLenght * callesCount)) {
            SpawnCalle(UnityEngine.Random.Range(0, calles.Length));
            DeleteCalle();
        }
    }

    public void SpawnCalle(int calleNum) 
    {
        GameObject gameObject = Instantiate(calles[calleNum], transform.forward * ZSpawn, transform.rotation);
        activeCalles.Add(gameObject);
        ZSpawn += CalleLenght;
    }

    private void DeleteCalle() {

        Destroy(activeCalles[0]);
        activeCalles.RemoveAt(0);

    }

}
