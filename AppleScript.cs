using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{

    public PlayerStatus myPlayerStatus;
    private int foodValue = 15;
    public AudioSource eatSoundSource;

    private void Start()
    {
        myPlayerStatus = FindObjectOfType<PlayerStatus>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.2f); //DrawWireSphere
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Camera>())
        {
            myPlayerStatus.EatFood(foodValue);
            eatSoundSource.Play(0);
            Debug.Log("Apple eaten");
            Destroy(gameObject);
        }
    }
}
