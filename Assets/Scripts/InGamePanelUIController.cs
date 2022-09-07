using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      //UI 클래스 사용을 위함
using TMPro;        //TextmeshPro사용을 위함

public class InGamePanelUIController : MonoBehaviour
{
    public static InGamePanelUIController Instance;
    
    public GameObject garbageScoreTxt;
    public GameObject animalScoreTxt;
    public GameObject TimeTxt;

    private void Start()
    {
        Instance = this;
        printGarbageCountUI();
        printAniamlCountUI();
        printTimeUI(); 
    }


    private void OnEnable()
    {
        printGarbageCountUI();
        printAniamlCountUI();
        printTimeUI();
    }

    public void printGarbageCountUI()
    {
        TextMeshProUGUI garbageUITxt = garbageScoreTxt.GetComponent<TextMeshProUGUI>();
        garbageUITxt.text = string.Format("{0}t", GameManager.Instance._trashCount.trashTouchCount);
        return;
    }

    public void printAniamlCountUI()
    {
        // TextMeshProUGUI animalUITxt = animalScoreTxt.GetComponent<TextMeshProUGUI>();
        // animalUITxt.text = string.Format("{0}", GameManager.Instance.GetAnimalCountSum()); 
    }

    public void printTimeUI()
    {
        TextMeshProUGUI TimeUITxt = TimeTxt.GetComponent<TextMeshProUGUI>();
        TimeUITxt.text = string.Format("D+{0}", GameManager.Instance.playDay);
    }

}
