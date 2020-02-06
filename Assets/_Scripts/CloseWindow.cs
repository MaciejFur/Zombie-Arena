using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    bool closing = false;
    public Animator rightAnimator;
    public Animator leftAnimator;
    public bool isClosed = false;
    private bool isColliding = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && isColliding == true)
        {
            Debug.Log("hit");
            leftAnimator.SetBool("isClosed", !isClosed);
            rightAnimator.SetBool("isClosed", !isClosed);
            isClosed = !isClosed;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;

        }
    }
}
