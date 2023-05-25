using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBowLineLoaded : MonoBehaviour
{

    private CrossBow myCrossBow;
    private CrossBowLineHand myLine;
    [SerializeField] private Transform lineUnloaded;

    void Start()
    {
        myCrossBow = GetComponentInParent<CrossBow>();
    }

    private void AttachedLine()
    {
        if(myCrossBow.lineFixed)
        {
            myLine.transform.position = transform.position; 
        }
        else
        {
            myLine.transform.position = lineUnloaded.transform.position;
        }
    }

    /*
    public void MoveLineToUnloadPos()
    {
        myLine.transform.position = lineUnloaded.transform.position;
        
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<CrossBowLineHand>())
        {
            myLine = other.gameObject.GetComponent<CrossBowLineHand>();
            myCrossBow.lineFixed = true;
        }
    }

    private void Update()
    {
        AttachedLine();
    }
}
