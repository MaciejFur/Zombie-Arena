using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseWindow : MonoBehaviour
{
    public Animator rightAnimator;
    public Animator leftAnimator;
    
    public bool isClosed = false;
    private bool isColliding = false;

    public AudioSource closing;
    public AudioSource opening;

    public Text windowText;
        
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && isColliding == true)
        {
            Debug.Log("hit");
            if(isClosed == true)
            {
                closing.PlayDelayed(.18f);
            }
            else
            {
                opening.Play(0);
            }
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
            if (isClosed == true)
            {
                windowText.text = "Press E to Close";
            }
            else
            {
                windowText.text = "Press E to Open";
            }
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
            windowText.text = "";
        }
    }
}
