using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyPanelControll : MonoBehaviour
{
    public GameObject Panel;
    public GameObject hidePanel = null;
    public GameObject touchController;
    public GameObject ScrollAndPinch;

    public GameObject storyUICheck;

    public void activePanelButton()
    {
        storyUICheck.SetActive(false);
        GameManager.Instance.PlaySfxMusic(GameManager.sfx.BUTTON);
        Panel.SetActive(true);
        touchController.SetActive(false);
        ScrollAndPinch.SetActive(false);
        hidePanel.SetActive(false);
    }

    public void inactivePanelButton()
    {
        GameManager.Instance.PlaySfxMusic(GameManager.sfx.BUTTON);
        touchController.SetActive(true);
        ScrollAndPinch.SetActive(true);
        hidePanel.SetActive(true);
        Panel.SetActive(false);
    }
}
