using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public Rigidbody myRB;
    private AudioSource myAudioSource;
    public AudioClip whistle;
    public AudioClip hitTree;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
    }

    public void Whistle()
    {
        myAudioSource.PlayOneShot(whistle,1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Hit(other);
    }


    private void Hit(Collider other)
    {
        if(other.gameObject.GetComponent<TreeScript>())
        {
            myRB.constraints = RigidbodyConstraints.FreezeAll;
            myAudioSource.PlayOneShot(hitTree, 1f);
        }
    }
}
