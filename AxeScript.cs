using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public Rigidbody myBlade;
    public AudioSource axeSound;


    void Start()
    {
        myBlade = FindObjectOfType<Rigidbody>();
        axeSound = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with" + collision.gameObject.name);
        if (collision.gameObject.GetComponent<TreeScript>())
        {
            collision.gameObject.GetComponent<TreeScript>().BeingCut(transform.position);
            axeSound.Play(0);
        }
    }
    
    /*
    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Collision with" + other.gameObject.name);
            if (other.gameObject.GetComponent<TreeScript>())
            {
                other.gameObject.GetComponent<TreeScript>().BeingCut();
                axeSound.Play(0);
             }
    }
    */
}
