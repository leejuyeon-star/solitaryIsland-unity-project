using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 동물 인벤토리 활성화, 다른 화면 비활성화
public class animalButton : MonoBehaviour
{
    public GameObject gameobject;
    public GameObject touchController;
    public GameObject ScrollAndPinch;

    public void OnClickButton()
    {
        gameobject.SetActive(true);
        touchController.SetActive(false);
        ScrollAndPinch.SetActive(false);
        
    }


}

