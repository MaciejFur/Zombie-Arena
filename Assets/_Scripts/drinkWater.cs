using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkWater : MonoBehaviour
{
    // Start is called before the first frame update
    public static float wasser;

    private void Awake()
    {
        wasser = WaterVase.water;
    }
    void Update()
        {
            
            if (wasser < 100f)
            {
                InvokeRepeating("RefreshWater", 0.5f, 100f + Time.deltaTime);
                
            }
        }

        void RefreshWater()
        {
            wasser += 0.01f;
        }
        private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (wasser > 50f)
            {
                wasser= 0;
            }
        }
    }
}
