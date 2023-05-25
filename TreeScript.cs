using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{

    public LvlCreator myLevelCreator;
    private bool wasCut = false;
    private float force = 5f;

    private void Start()
    {
        myLevelCreator = FindObjectOfType<LvlCreator>();
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with" + collision.gameObject.name);
        if(collision.gameObject.name == "Axe")
        {
            GameObject.Destroy(this);
        }
    }
    */
    public void BeingCut(Vector3 axeVector_)
    {
        if(!wasCut)
        { 
            Instantiate(myLevelCreator.apple, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),Quaternion.identity);
            FallTree(axeVector_);
        }
    }

    private void FallTree(Vector3 axeVector_)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        Vector3 forceVector = new Vector3(transform.position.x, transform.position.y, transform.position.z) - axeVector_;
        GetComponent<Rigidbody>().AddForce(forceVector * force);
    }
}
