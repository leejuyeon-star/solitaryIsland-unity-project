using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalClickSpawner : MonoBehaviour
{
    public GameObject animalPrefab;      //생성할 동물 프리팹
    public GameObject AnimalParent;     //생성한 동물이 상속될 부모 오브젝트
    public Vector3 spawnPosition;       //동물 생성할 위치
    public GameObject _NoPointAlarm;    //"포인트가 부족합니다" 생성하는 txt오브젝트
    public int animalPoint;             //생성하기 위해 필요한 포인트

    public GameObject AnimalSpawnCamera;
    public GameObject InGamePanel;
    public GameObject AnimalSpawnPanel;
    public GameObject InventoryPanel;

    public void OnClickButton()
    {
        // 해당 동물의 포인트 <= 현 포인트인 경우, 포인트 일정량 지우고 동물 생성
        if(animalPoint <= GameManager.Instance._trashCount.trashTouchCount)
        {
            // 오브젝트 설정
            GameObject newObj = Instantiate(animalPrefab); 
            newObj.transform.position = spawnPosition;
            newObj.transform.parent = AnimalParent.transform;
            newObj.transform.localScale = new Vector3(10,10,10);

            //기타 변수값 갱신, UI 변화
            GameManager.Instance._trashCount.trashTouchCount -= animalPoint;
            int index = newObj.name.IndexOf("(Clone)");
            if (index > 0) 
                newObj.name = newObj.name.Substring(0, index);
            GameManager.Instance.PlusAnimalCount(newObj);
            InGamePanelUIController.Instance.printAniamlCountUI();
            InGamePanelUIController.Instance.printGarbageCountUI();

            AnimalSpawnCamera.SetActive(true);
            AnimalSpawnCamera.GetComponent<animalFollow>().SendObject(newObj);
            InGamePanel.SetActive(false);       //!걱정된다 true/false 바꾸면 모든 함수 멈추는데..
            AnimalSpawnPanel.SetActive(true);
            InventoryPanel.SetActive(false);

        }
        else //그 외의 경우 "포인트가 부족합니다" 내보내기
        {
            _NoPointAlarm.SetActive(true);
        }
        return;
    }

    
}
