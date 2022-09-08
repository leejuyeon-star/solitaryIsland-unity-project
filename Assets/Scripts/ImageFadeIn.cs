using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      //UI 클래스 사용을 위함

// 기능 : 오브젝트가 활성화될떄마다 text fade out 효과, 효과 끝나면 다시 비활성화됨 
// 사용법 : 
//      - 효과 낼 text 오브젝트에 스크립트 추가
//      - fade out하는 speed 설정
// 주의 : color32로 변형 불가. color만 가능

public class ImageFadeIn : MonoBehaviour
{
    public int waitTime;
    public int speed = 1;                   //fade out 속도
    private float currentTime = 0.0f;
    public Image Panel;       
    private float transparent;
    private float colorR;
    private float colorG;
    private float colorB;


    private void Awake()
    {
        colorR = Panel.color.r;
        colorG = Panel.color.g;
        colorB = Panel.color.b;

        if(speed == 0)
            speed = 1;
        
    }

    private void OnEnable()
    {
        // Debug.Log("활성화");
        currentTime = 0.0f;
        transparent = 0.0f;
        Panel.color = new Color(colorR, colorG, colorB, 0);
        IEnumerator enumerator = setTransparent(waitTime, speed);
        StartCoroutine(enumerator);
    }

    
    // private void Update()
    // {

    //     if (transparent >= 1)
    //     {
    //         transparent += (float)(currentTime * speed);
    //         Panel.color = new Color(colorR, colorG, colorB, transparent);
    //         currentTime += (Time.deltaTime * 0.0001f);
    //     }   
    //     else
    //     {
    //         // Debug.Log("비활성화");
    //         // this.gameObject.SetActive(false);
    //     } 
    // }


    private IEnumerator setTransparent(int waitTime, int speed)
    {
        yield return new WaitForSeconds(waitTime);

        while(transparent <= 1)
        {
            yield return new WaitForSeconds(0.1f);
            transparent += (float)(currentTime * speed);
            Panel.color = new Color(colorR, colorG, colorB, transparent);
            currentTime += (Time.deltaTime * 0.03f);
        }
    }
}
