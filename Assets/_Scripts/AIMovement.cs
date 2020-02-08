using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    // Variables used for Raycasting detection
    public LayerMask mask;
    public GameObject AI;
    public Rigidbody rb;

    public Transform target;
    public Transform t;
    public GameObject player;
    public float speed = 1.5f;

    // Animator variables
    public Animator chicken;
    public bool isWalking = false;
    public bool isRunning = false;

    
    void Start()
    {
       
    }
    void Update ()
    {
        if (player == null)
        {
            player = GameObject.Find("Handgun_01_FPSController");
            target = player.GetComponent<Transform>();
        }
        t.LookAt(target);
        AnimationControl();
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100, mask))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            if (isWalking == true || isRunning == true)
                t.position += t.forward * speed * Time.deltaTime;

        }
        else if (!Physics.Raycast(ray, out hitInfo, 100, mask))
        {

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
            t.position += -t.forward * speed * Time.deltaTime;
            t.rotation = Quaternion.identity;
            
        }
        /*Ray ray = new Ray(transform.position + new Vector3(0f,2.2f,0f), transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 3, mask))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            t.position += t.forward * speed * Time.deltaTime;

        }
        else if (!Physics.Raycast(ray, out hitInfo, 3, mask))
        {

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
            t.position += -t.forward * speed * Time.deltaTime;
            t.Rotate(0, Random.Range(90f, 270f), 0);
        }*/
        


    }
    void AnimationControl()
    {
        if(isRunning == true)
        {
            speed = 3f;
            chicken.SetBool("Run", isRunning);

        }
        else
        {
            chicken.SetBool("Run", false);
        }
        if (isWalking == true)
        {
            speed = 1.5f;
            chicken.SetBool("Walk", true);
        }
        else
        {
            chicken.SetBool("Walk", false);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("Weapon"))
        {
            isRunning = true;
            isWalking = false;
        }
        /*if (col.gameObject.CompareTag("Building") && isRunning == false)
        {
            t.Rotate(0, Random.Range(90f, 270f), 0);
        }*/
    }
}