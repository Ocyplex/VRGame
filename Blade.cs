using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    private AxeScript myAxe;

    private void Start()
    {
        myAxe = GetComponentInParent<AxeScript>();
    }
/*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with" + collision.gameObject.name);
        if (collision.gameObject.GetComponent<TreeScript>())
        {
            collision.gameObject.GetComponent<TreeScript>().BeingCut(new Vector3(transform.position.x,transform.position.y,transform.position.z));
            myAxe.axeSound.Play(0);
        }
    }
    */
}
