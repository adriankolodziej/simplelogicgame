using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerController : MonoBehaviour
{
    private CubeSpawner[] cubeSpawners;
    void Start()
    {
        cubeSpawners = (CubeSpawner[])FindObjectsOfType(typeof(CubeSpawner));
        for(int i=0;i<cubeSpawners.Length;i++)
		{
            cubeSpawners[i].SetupDefaultState(i);
            
        }     
    }
}
