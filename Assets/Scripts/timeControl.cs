using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      //UI 클래스 사용을 위함
using TMPro;        //TextmeshPro사용을 위함

//플레이 시간 계산, UI출력
public class timeControl : MonoBehaviour
{

    public TextMeshProUGUI playDayTxt;
    public float intervaltime;
    private float realplayTime;

    // Start is called before the first frame update
    void Start()
    {
        realplayTime = 0.0f;
        printUI();
    }


    // playTime
    void Update()
    {
        realplayTime += Time.deltaTime;
        if(realplayTime >= intervaltime){
            //playDay 데이터 갱신
            (GameManager.Instance.playDay)++;
            Debug.Log("time > intervaltime");
            //ui 반영
            printUI();
            realplayTime = 0;
        }
    }

    void printUI()
    {
        playDayTxt.text = string.Format("D+{0}", GameManager.Instance.playDay);
    }
}
