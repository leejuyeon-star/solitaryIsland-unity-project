using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   //구조체 배열을 위함

 
public class AnimalSpawner : MonoBehaviour
{
    public int SpawnGroupNumber;

    
    [Serializable] public struct SpawnGroup{
        public GameObject animalPrefab;      //생성할 동물 프리팹
        public int animalPoint;             //생성하기 위해 필요한 포인트
        public GameObject SpawnButton;        //스폰해주는 버튼
    }

    
    [SerializeField] SpawnGroup[] Spawn;
    public GameObject animalParent;     //생성한 동물이 상속될 부모 오브젝트
    public Vector3 spawnPosition;       //동물 생성할 위치
    public GameObject _NoPointAlarm;    //"포인트가 부족합니다" 생성하는 txt오브젝트

    public GameObject AnimalSpawnCamera;
    public GameObject InGamePanel;
    public GameObject AnimalSpawnPanel;
    public GameObject InventoryPanel;

    public float RandomSpawnRange_X = 250f;        //랜덤으로 스폰될 장소 범위 x축
    public float RandomSpawnRange_Z = 250f;        //랜덤으로 스폰될 장소 범위 z축
    public float SpawnRange_Y = 100f;

    private void Start()
    {
        SpawnAnimal();
    }


    public void OnClickButton()
    {
        // 해당 동물의 포인트 <= 현 포인트인 경우, 포인트 일정량 지우고 동물 생성
        if(Spawn[0].animalPoint <= GameManager.Instance._trashCount.trashTouchCount)
        {
            Debug.Log("동물 생성");
            // 오브젝트 설정
            GameObject newObj = Instantiate(Spawn[0].animalPrefab); 
            newObj.transform.parent = animalParent.transform;
            newObj.transform.localPosition = spawnPosition;
            newObj.transform.localScale = new Vector3(10,10,10);

            //기타 변수값 갱신, UI 변화
            GameManager.Instance._trashCount.trashTouchCount -= Spawn[0].animalPoint;
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
            Debug.Log("포인트 부족");
            _NoPointAlarm.SetActive(true);
        }
        return;
    }


    // 로드한 만큼의 양으로 동물 오브젝트 생성
    private void SpawnAnimal()
    {
        for(int i=0; i<SpawnGroupNumber; i++)
        {
            for(int j=0; j<GameManager.Instance.MappingAnimalCount(Spawn[i].animalPrefab); j++)
            {
                GameObject newObj = Instantiate(Spawn[i].animalPrefab); 
                newObj.transform.parent = animalParent.transform;
                newObj.transform.localPosition = ReturnRandomPosition(RandomSpawnRange_X, SpawnRange_Y, RandomSpawnRange_Z);
                newObj.transform.localScale = new Vector3(10,10,10);
                int index = newObj.name.IndexOf("(Clone)");
                if (index > 0) 
                    newObj.name = newObj.name.Substring(0, index);
            }   
        }
    }
    

    // Vector3(0 ~ range_X, _Y, 0 ~ range_Z) 범위 내에서 랜덤한 위치 반환 
    private Vector3 ReturnRandomPosition(float range_X, float _Y, float range_Z)
    {
        range_X = UnityEngine.Random.Range((range_X) * -1, range_X);
        range_Z = UnityEngine.Random.Range((range_Z) * -1, range_Z);
        Vector3 RandomPostion = new Vector3(range_X, _Y, range_Z);
        return RandomPostion;
    }
    
}






