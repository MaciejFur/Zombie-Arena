using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterVase : MonoBehaviour
{
    public Transform sphereWater;
    public float water;

    public AudioSource drinking;
    private bool isColliding = false;

    public Text drinkText;

    // Start is called before the first frame update
    void Awake()
    {
        water = 90f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isColliding == true)
        {
            if (water > 50f)
            {
                drinking.Play(0);
                if (water > 99f)
                {
                    PlayerHealth.playerHealth = 100;
                }
                else if (water > 50f)
                {
                    PlayerHealth.playerHealth += 50;
                }
                this.water = 0;
                


            }

        }
        if (water < 100f)
        {
            RefreshWater();

        }
        if (water < 100f)
        {
            if (water < 50f)
            {
                sphereWater.transform.localPosition = new Vector3(0f, -1.5f, 0f);
            }
            if (water > 50f && water < 100f)
            {
                sphereWater.transform.localPosition = new Vector3(0f, 0.4f, 0f);
            }
            if (water > 99f)
            {
                sphereWater.transform.localPosition = new Vector3(0f, 0.785f, 0f);
            }
        }
    }
    void RefreshWater()
    {
        water += 0.01f;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
            Debug.Log(water);
            if (water > 50f)
            {
                drinkText.text = "Press E to drink";

            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
            drinkText.text = "";

        }
    }


}
