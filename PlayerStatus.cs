using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{

    public GameObject playerstatus;
    public TextMeshProUGUI healthStatusText;
    public TextMeshProUGUI thirstStatusText;
    public TextMeshProUGUI hungerStatusText;
    public TextMeshProUGUI StaminaStatusText;
    public SceneGameManager mySceneGameManager;
    public LvlCreator myLvlCreator;


    public GameObject myPostionGO;
    public Vector3 myCurrentPosition;
    public Vector3 myOldPosition;

    private float healthStatus;
    private float thirstStatus;
    private float hungerStatus;
    private float staminaStatus;



    void Start()
    {
        myLvlCreator = FindObjectOfType<LvlCreator>();
        StartStatus();
        myOldPosition = myPostionGO.transform.position;
    }

    void StatusChanged(float healthStatus_, float thirstStatus_, float hungerStatus_, float staminaStatus_)
    {
        healthStatusText.text = healthStatus_.ToString();
        thirstStatusText.text = thirstStatus_.ToString();
        hungerStatusText.text = hungerStatus_.ToString();
        StaminaStatusText.text = staminaStatus_.ToString();

    }

    void StartStatus()
    {
        healthStatus = 100f;
        thirstStatus = 100f;
        hungerStatus = 100f;
        staminaStatus = 100f;
        StatusChanged(healthStatus, thirstStatus, hungerStatus, staminaStatus);
    }

    public bool PlayerMovedBool(GameObject xrRig_)
    {
        return true;
    }

    public void PlayerMoved(Vector3 currentPostion_, Vector3 newPosition_)
    {
        float distance = Vector3.Distance(newPosition_, currentPostion_);
        //Debug.Log("Player moved distance: " + distance);
        staminaStatus = staminaStatus - Mathf.Round(distance);
        StatusChanged(healthStatus, thirstStatus, hungerStatus, staminaStatus);
        ActivateBuildingSphere();
    }


    public void CheckPositionChanged()
    {
        if (myOldPosition != myPostionGO.transform.position)
        {
            //Debug.Log("Position OLD X:" + myOldPosition.x + " Y:" + myOldPosition.y + " Z:" + myOldPosition.z);
            PlayerMoved(myPostionGO.transform.position, myOldPosition);
            myOldPosition = myPostionGO.transform.position;
            //Debug.Log("Position new X:" + myOldPosition.x + " Y:" + myOldPosition.y + " Z:" + myOldPosition.z);
            //ActivateBuildingSphere();
        }
        else
        {
            //Debug.Log("Position DIDN´t changed! X=" + myCurrentPosition.transform.position.x + " Z=" + myCurrentPosition.transform.position);
        }
    }


    public void RestoreStamina(int restoreValue_)
    {
        if (staminaStatus <= 100)
        {
            staminaStatus = staminaStatus + restoreValue_;
            if(staminaStatus > 100)
            {
                staminaStatus = 100;
            }
            StatusChanged(healthStatus, thirstStatus, hungerStatus, staminaStatus);
        }
    }

    public void ReduceHungerValue(int reduceValue_)
    {
        hungerStatus = hungerStatus - reduceValue_;
        StatusChanged(healthStatus, thirstStatus, hungerStatus, staminaStatus);
    }

    public bool MovingPossible()
    {
        if(staminaStatus > 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void LosingCondition()
    {
        if(healthStatus <= 0)
        {
            mySceneGameManager.GoToNextSene(2);
        }
    }

    public void EatFood(int foodValue_)
    {
        if(hungerStatus < 100)
        { 
            hungerStatus = hungerStatus + foodValue_;
            if(hungerStatus > 100)
            {
                hungerStatus = 100;
            }
            StatusChanged(healthStatus, thirstStatus, hungerStatus, staminaStatus);
        }
    }

    public void ActivateBuildingSphere()
    {
        int activatedSockets = 0;
        for (int i = 0; i < myLvlCreator.wallSocketList.Count;i++)
        { 
            if( Vector3.Distance(myOldPosition, myLvlCreator.wallSocketList[i].transform.position) < 3.0f)
            {
                myLvlCreator.wallSocketList[i].ActivateSphereAndScript();
                activatedSockets++;
            }
            else
            {
                myLvlCreator.wallSocketList[i].DeactivateSphereAndScript();
            }
        }
        Debug.Log("Activated " + activatedSockets + " sockets");
    }
}
