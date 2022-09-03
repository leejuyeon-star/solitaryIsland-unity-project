using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //scene 종료를 위함

public class EndingPanel : MonoBehaviour
{
    public GameObject touchController;
    public GameObject ScrollAndPinch;
    void OnEnable()
    {
        GameManager.Instance.StopBgm(GameManager.bgm.MAIN);
        GameManager.Instance.PlayBgm(GameManager.bgm.START);
        touchController.SetActive(false);
        ScrollAndPinch.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
