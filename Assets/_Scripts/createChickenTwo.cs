using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createChickenTwo : MonoBehaviour
{
    public GameObject chicken;
    void Update()
    {
        if (WaveControl.fireStage == true &&
            WaveControl.stageNumber == 2)
            SecondWave();


    }
    void SecondWave()
    {
        Instantiate(chicken);
        WaveControl.fireStage = false;
    }
}
