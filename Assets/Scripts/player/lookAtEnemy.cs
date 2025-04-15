using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lookAtEnemy : MonoBehaviour
{
    UI_Controller uiController;
    enemyPool enemyPool;

    float counter;
    float totalTime = 3f;
    bool startCounter = false;
    public static int deadCounter;

    void Start()
    {
        uiController = GameObject.Find("player").GetComponent<UI_Controller>();
        enemyPool = GameObject.Find("enemyPool").GetComponent<enemyPool>();
    }

    void Update()
    {
        if (startCounter)
        {
            counter += Time.deltaTime;
            float fillAmount = Mathf.Clamp01(counter / totalTime);
            if (uiController != null)
            {
                uiController.modifyValuePB(fillAmount);
            }


            if (counter >= totalTime)
            {
                notLooking();
                enemyPool.returnObject(gameObject);
                deadCounter++;
                uiController.updateDeadCounter(deadCounter);
            }
        }
    }

    void resetValues()
    {
        if (uiController != null)
        {
            uiController.pbVisibility(false);
            uiController.modifyValuePB(0);
        }
        counter = 0;
    }

    public void looking()
    {
        if (uiController != null)
        {
            uiController.pbVisibility(true);
        }
        startCounter = true;
    }

    public void notLooking()
    {
        startCounter = false;
        resetValues();
    }
}
