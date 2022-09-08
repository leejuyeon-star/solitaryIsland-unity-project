using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      //UI 클래스 사용을 위함
using TMPro;        //TextmeshPro사용을 위함

public class garbageStoryUIControl : MonoBehaviour
{
    public int[] level;
    private int _trashTouchCount;

    public GameObject[] garbageUI;
    public GameObject[] garbageTxt;
    public GameObject[] storyUI;
    public GameObject[] storyTxt;

    public GameObject garbageUICheck;
    public GameObject storyUICheck;

    public GameObject garbagePanel;
    public GameObject storyPanel;
    public GameObject hidePanel = null;

    public GameObject touchController;
    public GameObject ScrollAndPinch;



    public void activeGarbagePanel()
    {
        garbageUICheck.SetActive(false);
        GameManager.Instance.PlaySfxMusic(GameManager.sfx.BUTTON);
        garbagePanel.SetActive(true);
        touchController.SetActive(false);
        ScrollAndPinch.SetActive(false);
    }

    public void inactiveGarbagePanel()
    {
        GameManager.Instance.PlaySfxMusic(GameManager.sfx.BUTTON);
        touchController.SetActive(true);
        ScrollAndPinch.SetActive(true);
        hidePanel.SetActive(true);
        garbagePanel.SetActive(false);
    }

    public void activeStoryPanel()
    {
        storyUICheck.SetActive(false);
        GameManager.Instance.PlaySfxMusic(GameManager.sfx.BUTTON);
        storyPanel.SetActive(true);
        touchController.SetActive(false);
        ScrollAndPinch.SetActive(false);
        hidePanel.SetActive(false);
    }

    public void inactiveStoryPanel()
    {
        GameManager.Instance.PlaySfxMusic(GameManager.sfx.BUTTON);
        touchController.SetActive(true);
        ScrollAndPinch.SetActive(true);
        hidePanel.SetActive(true);
        storyPanel.SetActive(false);
    }

    



    private void Start()
    {
        if(GameManager.Instance.iscomplete0)
            settingGarbage(0);
        else
            inactiveGarbage(0);
        if(GameManager.Instance.iscomplete1)
            settingGarbage(1);
        else
            inactiveGarbage(1);
        if(GameManager.Instance.iscomplete2)
            settingGarbage(2);
        else
            inactiveGarbage(2);
        if(GameManager.Instance.iscomplete3)
            settingGarbage(3);
        else
            inactiveGarbage(3);
        if(GameManager.Instance.iscomplete4)
            settingGarbage(4);
        else
            inactiveGarbage(4);
        if(GameManager.Instance.iscomplete5)
            settingGarbage(5);
        else
            inactiveGarbage(5);
    }
    


    
    // Update is called once per frame
    private void Update()
    {
        _trashTouchCount = GameManager.Instance._trashCount.trashTouchCount;
        if(level[0] <= _trashTouchCount && !GameManager.Instance.iscomplete0)
        {
            activeGarbage(0);
        }
        else if(level[1] <= _trashTouchCount && !GameManager.Instance.iscomplete1)
        {
            activeGarbage(1);
        }
        else if(level[2] <= _trashTouchCount && !GameManager.Instance.iscomplete2)
        {
            activeGarbage(2);
        }
        else if(level[3] <= _trashTouchCount && !GameManager.Instance.iscomplete3)
        {
            activeGarbage(3);
        }
        else if(level[4] <= _trashTouchCount && !GameManager.Instance.iscomplete4)
        {
            activeGarbage(4);
        }
        else if(level[5] <= _trashTouchCount && !GameManager.Instance.iscomplete5)
        {
            activeGarbage(5);
            GameManager.Instance.Ending();
        }
    }

    private void settingGarbage(int n)
    {
        garbageUICheck.SetActive(true);
        storyUICheck.SetActive(true);
        garbageTxt[n].SetActive(false);
        garbageUI[n].SetActive(true);
        storyTxt[n].SetActive(false);
        storyUI[n].SetActive(true);
    }

    private void activeGarbage(int n)
    {
        GameManager.Instance.PlaySfxMusic(GameManager.sfx.LEVELUP);
        garbageUICheck.SetActive(true);
        storyUICheck.SetActive(true);
        garbageTxt[n].SetActive(false);
        garbageUI[n].SetActive(true);
        storyTxt[n].SetActive(false);
        storyUI[n].SetActive(true);
        switch(n)
        {
            case 0:
                GameManager.Instance.iscomplete0 = true;
                GameManager.Instance.garbageCreatePlus -= 1;
                Debug.Log("0:"+GameManager.Instance.garbageCreatePlus);
                break;
            case 1:
                GameManager.Instance.iscomplete1 = true;
                GameManager.Instance.garbageCreatePlus -= 1;
                Debug.Log("1:"+GameManager.Instance.garbageCreatePlus);
                break;
            case 2:
                GameManager.Instance.iscomplete2 = true;
                GameManager.Instance.garbageCreatePlus -= 1;
                Debug.Log("2:"+GameManager.Instance.garbageCreatePlus);
                break;
            case 3:
                GameManager.Instance.iscomplete3 = true;
                GameManager.Instance.garbageCreatePlus -= 1;
                Debug.Log("3:"+GameManager.Instance.garbageCreatePlus);
                break;
            case 4:
                GameManager.Instance.iscomplete4 = true;
                GameManager.Instance.garbageCreatePlus -= 1;
                Debug.Log("4:"+GameManager.Instance.garbageCreatePlus);
                break;
            case 5:
                GameManager.Instance.iscomplete5 = true;
                GameManager.Instance.garbageCreatePlus -= 1;
                Debug.Log("5:"+GameManager.Instance.garbageCreatePlus);
                break;
        }
        return;
    }

    public void inactiveGarbage(int n)
    {
        garbageTxt[n].SetActive(true);
        garbageUI[n].SetActive(false);
        storyTxt[n].SetActive(true);
        storyUI[n].SetActive(false);
        return;
    }

}
