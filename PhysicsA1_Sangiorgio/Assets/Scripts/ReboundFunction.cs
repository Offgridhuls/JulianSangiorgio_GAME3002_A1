using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundFunction : MonoBehaviour
{
    public AudioSource goal;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        goal = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.back * 20, ForceMode.VelocityChange);
        rb.AddTorque(Vector3.forward);
        goal.Play();
        print("Goal");
    }


   
}
