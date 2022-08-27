using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이 시간 계산
public class timeControl : MonoBehaviour
{

    public float intervaltime;

    private float realplayTime;

    void Start()
    {
        realplayTime = 0.0f;
    }


    void Update()
    {
        realplayTime += Time.deltaTime;
        if(realplayTime >= intervaltime){
            (GameManager.Instance.playDay)++;
            InGamePanelUIController.Instance.printTimeUI();
            realplayTime = 0;
        }
    }
}
