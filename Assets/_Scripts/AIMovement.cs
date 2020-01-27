using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public LayerMask mask;
    public GameObject AI;
    public Rigidbody rb;
    public Transform t;
    public float speed = 0f;
    void Start()
    {
        //t = AI.GetComponent<Transform>();
        //rb = AI.GetComponent<Rigidbody>();
        Debug.Log(t);
    }
    void Update ()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100, mask))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            t.position += t.forward * speed * Time.deltaTime;

        }
        else if (!Physics.Raycast(ray, out hitInfo, 100, mask))
        {
            
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
            t.position += -t.forward * speed * Time.deltaTime;
            t.Rotate(0, Random.Range(90f, 270f), 0);
        }


    }
}