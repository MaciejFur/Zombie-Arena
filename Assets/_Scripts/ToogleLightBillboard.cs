using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleLightBillboard : MonoBehaviour
{
    int number;
    public Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        number = Random.Range(1, 500);
        LightsOn();

    }
    void LightsOn ()
    {
        if(number < 6)
        {
            myLight.enabled = !myLight.enabled;
        }
    }
    
}
