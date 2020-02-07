using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterKills : MonoBehaviour
{
    public AudioSource waterSplash;
    private void OnTriggerEnter(Collider other)
    {
        waterSplash.pitch = Random.Range(.9f, 3f);
        waterSplash.Play();
        if(other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("Enemy")||
            other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject);
        }

    }
}
