using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartController : MonoBehaviour
{

    public float DelayTime;

    private float playTime;

    void Start()
    {
        playTime = 0.0f;
    }


    void Update()
    {
        playTime += Time.deltaTime;
        if(playTime >= DelayTime){
            (GameManager.Instance.heart)++;
            playTime = 0;
        }   
    }


}
