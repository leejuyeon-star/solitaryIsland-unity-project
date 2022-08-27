using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawnInactive : MonoBehaviour
{
    public GameObject AnimalSpawnPanel;
    public GameObject InGamePanel;
    public GameObject animalFollowCamera;


    public void OnClickButton()
    {
        AnimalSpawnPanel.SetActive(false);
        animalFollowCamera.SetActive(false);
        InGamePanel.SetActive(true);
    }
}
