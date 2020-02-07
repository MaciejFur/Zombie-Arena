using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterKills : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("Enemy")||
            other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject);
        }
    }
}
