using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;        //필수

public class NoPointAlarm : MonoBehaviour
{
    public float time = 3.0f;
    private float currentTime = 0.0f;
    private TextMeshPro text;


    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }

    void Start()
    {
        time = 0;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);        //?기본 상태rgb는 어떻게 하는거냐
        // text.color = new Color32(18,20,195, 255);
        // text.color = new Color32(255, 128, 0, 255); 
    
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
        }    
        this.gameObject.SetActive(false);
    }
}
