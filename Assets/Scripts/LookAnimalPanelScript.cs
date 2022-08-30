using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 동물 인벤토리 활성화, 다른 화면 비활성화
public class LookAnimalPanelScript : MonoBehaviour
{
    public GameObject Panel;
    public GameObject hidePanel = null;
    public GameObject touchController;
    public GameObject ScrollAndPinch;
    public GameObject subCamera = null;

    public void activePanelButton()
    {
        Panel.SetActive(true);
        touchController.SetActive(false);
        ScrollAndPinch.SetActive(false);
        if(subCamera != null)
            subCamera.SetActive(true);
        
    }

    public void inactivePanelButton()
    {
        touchController.SetActive(true);
        ScrollAndPinch.SetActive(true);
        if(subCamera != null)
            subCamera.SetActive(false);
        if(hidePanel != null)
            hidePanel.SetActive(true);
        Panel.SetActive(false);
    }

}

