using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealGeneration : MonoBehaviour
{
    public GameObject present;
    public int presentsAmount;
    public int minDensity = 10;
    public int maxDensity = 20;
    
    public Transform[] spawns;
    void Start()
    {
        if (spawns.Length <= 0) return;

        for(int i = 0; i < spawns.Length; i++)
        {
            for (int p = 0; p < presentsAmount; p++)
            {
                int spaceX = Random.Range(minDensity, maxDensity);
                int spaceZ = Random.Range(minDensity, maxDensity);
                int roatationX = Random.Range(-5, 10);
                int rotationY = Random.Range(-80, 80);
                int znak = Random.Range(0, 1) == 0 ? -1 : 1;
                Vector3 original = spawns[i].transform.position;
                GameObject newPresent = Instantiate(
                    present, new Vector3(original.x + spaceX * znak, 0, original.z + spaceZ * znak),
                    Quaternion.Euler(roatationX, rotationY, 0)) 
                    as GameObject;

                float scaleX = Random.Range(2f, 3f);
                float scaleY = Random.Range(2f, 3f);
                float scaleZ = Random.Range(2f, 3f);
                newPresent.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            }
        }
        
       
    }
}
