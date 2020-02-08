using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour
{
    public static int stageNumber = 0;
    public static bool fireStage = false;
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            stageNumber++;
            fireStage = true;
            
        }
    }
}
