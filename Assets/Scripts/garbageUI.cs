using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      //UI 클래스 사용을 위함
using TMPro;        //TextmeshPro사용을 위함


//쓰레기 터치시 Trashcount UI 출력
public class garbageUI : MonoBehaviour
{
    public GameObject ScoreTxt;
    private TextMeshProUGUI TrashUITxt;

    private void Start()
    {
        TrashUITxt = ScoreTxt.GetComponent<TextMeshProUGUI>();
        printUI();
    }


    //오브젝트 터치시 실행
    public void isTouch(GameObject hitObject)
    {
        (GameManager.Instance._trashCount.trashTouchCount)++;
        (GameManager.Instance._trashCount.trashCurrentCount)--;
        printUI();

        //오브젝트 삭제
        ObjectPooling.Instance.DeactivatePoolItem(hitObject);
        // Destroy(hitObject);
    }

    public void printUI()
    {
        TrashUITxt.text = string.Format("{0}/{1}", GameManager.Instance._trashCount.trashTouchCount, GameManager.Instance._trashCount.trashCurrentCount);
        return;
    }
}
