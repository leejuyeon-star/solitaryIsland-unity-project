using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;        //필수

// 기능 : 오브젝트가 활성화될떄마다 text fade out 효과, 효과 끝나면 다시 비활성화됨 
// 사용법 : 
//      - 효과 낼 text 오브젝트에 스크립트 추가
//      - fade out하는 speed 설정
// 주의 : color32로 변형 불가. color만 가능

public class textFadeOut : MonoBehaviour
{
    public int speed = 1;                   //fade out 속도
    private float currentTime = 0.0f;
    private TextMeshProUGUI text;       
    private float transparent;
    private float colorR;
    private float colorG;
    private float colorB;


    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        colorR = text.color.r;
        colorG = text.color.g;
        colorB = text.color.b;

        if(speed == 0)
            speed = 1;
        
    }

    private void OnEnable()
    {
        // Debug.Log("활성화");
        currentTime = 0.0f;
        transparent = 1.0f;
        text.color = new Color(colorR, colorG, colorB, 1);
    }

    
    private void Update()
    {

        if (transparent >= 0)
        {
            transparent -= (float)(currentTime * speed);
            text.color = new Color(colorR, colorG, colorB, transparent);
            currentTime += (Time.deltaTime * 0.01f);
        }   
        else
        {
            // Debug.Log("비활성화");
            this.gameObject.SetActive(false);
        } 
    }
}
