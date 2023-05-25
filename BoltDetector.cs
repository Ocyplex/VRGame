using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDetector : MonoBehaviour
{
    public Bolt myBolt;
    public CrossBow myCrossBow;

    private void Start()
    {
        myCrossBow = GetComponentInParent<CrossBow>();
    }

    private void AttachedBolt() //Attaching the bolt to the attachpoint, tracking the position and rotation of the bolt
    {
        if (myCrossBow.myBolt != null)
        {
            myBolt.transform.position = transform.position;
            myBolt.transform.rotation = transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.GetComponentInParent<Bolt>() && myCrossBow.reloadAble && !myCrossBow.loaded)
        {
            myBolt = other.gameObject.GetComponentInParent<Bolt>();
            myCrossBow.myBolt = myBolt;
            myCrossBow.reloadAble = false;
            myCrossBow.loaded = true;
        }
    }

    private void Update()
    {
        AttachedBolt();
    }
}
