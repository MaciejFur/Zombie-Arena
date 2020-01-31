using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterVase : MonoBehaviour
{
    public Transform player;
    public Transform sphereWater;
    public static float water = 50;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        water = drinkWater.wasser;
        
        if (water < 100f)
        {
            if (water < 50)
            {
                sphereWater.transform.localPosition = new Vector3(0f, -1.5f, 0f);
            }
            if (water > 50 && water < 100)
            {
                sphereWater.transform.localPosition = new Vector3(0f, 0.4f, 0f);
            }
            if (water > 99)
            {
                sphereWater.transform.localPosition = new Vector3(0f, 0.78f, 0f);
            }
        }
    }
    
   
}
