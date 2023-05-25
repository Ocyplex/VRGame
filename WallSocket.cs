using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallSocket : MonoBehaviour
{
    private LvlCreator myLvlCreator;
    private SphereCollider mySphereCollider;


    private void Start()
    {
        myLvlCreator = FindObjectOfType<LvlCreator>();
        myLvlCreator.wallSocketList.Add(this);
        mySphereCollider = GetComponent<SphereCollider>();
        mySphereCollider.enabled = false;
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.1f); //DrawWireSphere
    }
    */
    public void ActivateSphereAndScript()
    {
        mySphereCollider.enabled = true;
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Color.red, 2f);
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawCube(transform.position, new Vector3(0.3f,0.3f,0.3f));
    }

    public void DeactivateSphereAndScript()
    {
        mySphereCollider.enabled = false;
    }
}
