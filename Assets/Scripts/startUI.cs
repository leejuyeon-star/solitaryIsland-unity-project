using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUI : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject mainPanel;
    public GameObject howToPanel;
    public GameObject touchController;
    public GameObject ScrollAndPinch;
    public GameObject trashBagSpawnCube;

    public void ClickStart()
    {
        GameManager.Instance.PlaySfxMusic(GameManager.sfx.BUTTON);
        GameManager.Instance.StopBgm(GameManager.bgm.START);
        GameManager.Instance.PlayBgm(GameManager.bgm.MAIN);
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
