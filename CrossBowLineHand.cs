using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class CrossBowLineHand : MonoBehaviour
{

    [SerializeField]private CrossBowLineLoaded myCrossBowLineLoaded;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<XRBaseInteractor>())
        {

        }
    }


}
