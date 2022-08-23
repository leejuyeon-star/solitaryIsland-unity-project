using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 동물 인벤토리 비활성화, 다른 화면 활성화
public class InactiveButton : MonoBehaviour
{
    public GameObject gameobject;
    public GameObject touchController;
    public GameObject ScrollAndPinch;
    
    public void OnClickButton()
    {
        gameobject.SetActive(false);
        touchController.SetActive(true);
        ScrollAndPinch.SetActive(true);
    }
}
