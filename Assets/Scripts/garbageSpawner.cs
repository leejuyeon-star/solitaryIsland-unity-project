using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 쓰레기봉투가 생성되면 일정 시간 이후 랜덤한 양과 랜덤한 물건의 오브젝트를 쓰레기봉투에서 생성, exploder도 생성, 바로터트리기
public class garbageSpawner : MonoBehaviour
{
    public int garbageKind;            //오브젝트 총 개수
    public GameObject[] garbagePrefab;
    public float RandomSpawnRange_X = 250f;        //랜덤으로 스폰될 장소 범위 x축
    public float RandomSpawnRange_Z = 250f;        //랜덤으로 스폰될 장소 범위 z축
    public float SpawnRange_Y = 100f;


    public int objCreateCount;         //한번에 스폰할 오브젝트 개수
    public GameObject exploder;        //폭탄 오브젝트
    public int waitingTime = 5;

    private float timer;

    private void Start()
    {
        SpawnGarbage();
    }

    void OnEnable()
    {
        timer = 0.0f;
        waitingTime = Random.Range(5, 10);
    }

    
    public void EffectAfterDeactivateTrashBag()
    {
            SpawnGarbagefromTrashbag();       //쓰레기, exploder 생성하기
            printUI();      //UI반영
    }
    
    
    
    //쓰레기, exploder 생성하기
    private void SpawnGarbagefromTrashbag()
    {
        Vector3 spawnPosition = transform.position;
        //objCreateCount만큼의 양으로 랜덤한 물건의 오브젝트를 쓰레기봉투에서 생성
        for(int i=0; i<objCreateCount; i++)
        {
            int CreateObject = Random.Range(0, garbageKind+1);
            GameObject clone = ObjectPooling.Instance.ActivatePoolItem(garbagePrefab[CreateObject], spawnPosition);
        }
        //exploder도 생성
        GameObject exploderClone = ObjectPooling.Instance.ActivatePoolItem(exploder, spawnPosition);
    }



    //UI에 반영
    private void printUI()
    {
        GameManager.Instance._trashCount.trashCurrentCount += objCreateCount;
        InGamePanelUIController.Instance.printGarbageCountUI();
    }


    //로드한 만큼의 양으로 랜덤한 물건의 오브젝트를 생성
    private void SpawnGarbage()
    {
        int _trashCurrentCount = GameManager.Instance._trashCount.trashCurrentCount;
        for(int i=0; i<_trashCurrentCount; i++)
        {
            int CreateObject = Random.Range(0, garbageKind+1);
            GameObject clone = ObjectPooling.Instance.ActivatePoolItem(garbagePrefab[CreateObject], ReturnRandomPosition(RandomSpawnRange_X, SpawnRange_Y, RandomSpawnRange_Z));
        }
    }


    // Vector3(0 ~ range_X, _Y, 0 ~ range_Z) 범위 내에서 랜덤한 위치 반환 
    private Vector3 ReturnRandomPosition(float range_X, float _Y, float range_Z)
    {
        range_X = Random.Range((range_X) * -1, range_X);
        range_Z = Random.Range((range_Z) * -1, range_Z);
        Vector3 RandomPostion = new Vector3(range_X, _Y, range_Z);
        return RandomPostion;
    }

}




