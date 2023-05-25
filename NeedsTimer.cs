using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsTimer : MonoBehaviour
{

    public bool timerOn = true;
    public float timeLeft;
    public int resetTime = 10;
    private int hungerInt = 0;
    private int hungerCounterMax = 2;
    public PlayerStatus myPlayerStatus;


        void Update()
    {
        if(timerOn)
        { 
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                timeLeft = resetTime;
                myPlayerStatus.RestoreStamina(10);
                //Debug.Log("Stamina restored");
                hungerInt++;
                IncreaseHunger();
            }
        }
    }


    public void IncreaseHunger()
    {
        if(hungerInt > hungerCounterMax)
        {
            myPlayerStatus.ReduceHungerValue(5);
            hungerInt = 0;
        }
    }



}
