using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] GameObject progressBar_elements;
    [SerializeField] Image progressBar_red;
    [SerializeField] TextMeshProUGUI textCounter;

    [SerializeField] GameObject bgElements;

    public void modifyValuePB(float fillAmount)
    {
        progressBar_red.fillAmount = fillAmount;
    }

    public void pbVisibility(bool value)
    {
        progressBar_elements.SetActive(value);
    }

    public void updateDeadCounter(int counter)
    {
        textCounter.text = counter.ToString();
        gameManager.gameManagerInstance.points = counter;
        gameManager.gameManagerInstance.SaveProgress();
    }
}
