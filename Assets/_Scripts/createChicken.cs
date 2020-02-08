using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createChicken : MonoBehaviour
{
    public GameObject chicken;
    public Transform spawnPoint;
    void Update()
    {
        if(WaveControl.fireStage == true)
            FirstWave();

        
    }
    void FirstWave()
    {
        Instantiate(chicken, spawnPoint.position, spawnPoint.rotation);
        WaveControl.fireStage = false;
    }
}
