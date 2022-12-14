using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUI : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject mainPanel;
    public GameObject howToPanel;
    public GameObject stateUI;
    public GameObject touchController;
    public GameObject ScrollAndPinch;
    public GameObject trashBagSpawnCube;
    public GameObject zoomInCamera;

    public void ClickStart()
    {
        GameManager.Instance.PlaySfxMusic(GameManager.sfx.BUTTON);
        GameManager.Instance.StopBgm(GameManager.bgm.START);
        GameManager.Instance.PlayBgm(GameManager.bgm.MAIN);
        stateUI.SetActive(true);
        zoomInCamera.SetActive(false);
        GameManager.Instance.StartSetCamera();
        mainPanel.SetActive(true);
        touchController.SetActive(true);
        ScrollAndPinch.SetActive(true);
        trashBagSpawnCube.SetActive(true);
        startPanel.SetActive(false);
    }

    public void ClickHowTo()
    {
        howToPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void InactiveHowTo()
    {
        startPanel.SetActive(true);
        howToPanel.SetActive(false);
    }
}
