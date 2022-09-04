using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //scene 종료를 위함
using UnityEngine.UI;      //UI 클래스 사용을 위함
using TMPro;        //TextmeshPro사용을 위함

public class gameOverUI : MonoBehaviour
{
    public GameObject garbageScoreTxt;
    public GameObject TimeTxt;
    public GameObject anotherTimeTxt;
    public GameObject touchController;
    public GameObject ScrollAndPinch;


    private void OnEnable()
    {
        GameManager.Instance.StopBgm(GameManager.bgm.MAIN);
        GameManager.Instance.PlayBgm(GameManager.bgm.START);
        printGarbageCountUI();
        printTimeUI();
        PrintAnotherTime();
        touchController.SetActive(false);
        ScrollAndPinch.SetActive(false);
    }


    public void printGarbageCountUI()
    {
        TextMeshProUGUI garbageUITxt = garbageScoreTxt.GetComponent<TextMeshProUGUI>();
        garbageUITxt.text = string.Format("주운 쓰레기 양 : {0}t \n버린 쓰레기 양 : {1}t", GameManager.Instance._trashCount.trashTouchCount, GameManager.Instance._trashCount.trashCurrentCount);
        return;
    }

    public void printTimeUI()
    {
        TextMeshProUGUI TimeUITxt = TimeTxt.GetComponent<TextMeshProUGUI>();
        TimeUITxt.text = string.Format("생명이 살아남은 시간 : {0}년", GameManager.Instance.playDay);
        return;
    }

    public void PrintAnotherTime()
    {
        TextMeshProUGUI anotherTimeUITxt = anotherTimeTxt.GetComponent<TextMeshProUGUI>();
        anotherTimeUITxt.text = string.Format("쓰레기가 썩는 시간 : {0}년", ((GameManager.Instance.playDay)*1000));
        return;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    
}
