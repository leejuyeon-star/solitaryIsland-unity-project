using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 쓰레기봉투가 생성되면 일정 시간 이후 랜덤한 양과 랜덤한 물건의 오브젝트를 쓰레기봉투에서 생성, exploder도 생성, 바로터트리기
public class garbageSpawnExploder : MonoBehaviour
{
    public int objectCount;            //오브젝트 개수
    public GameObject[] obj;       //오브젝트
    public int objCreateCount;         //한번에 스폰할 오브젝트 개수
    public GameObject exploder;        //폭탄 오브젝트
    public int waitingTime = 5;

    private float timer;

    void OnEnable()
    {
        timer = 0.0f;
        waitingTime = Random.Range(5, 20);
    }
    
    void Update()
    {
        
        timer += Time.deltaTime;       
        if(timer > waitingTime)  //쓰레기봉투가 생성된 시점부터 waitingTime 이후 실행
        {
            Debug.Log("쓰레기봉투 삭제");
            //Action
            InstantiateGarbage();       //쓰레기, exploder 생성하기
            printUI();      //UI반영
            ObjectPooling.Instance.DeactivatePoolItem(gameObject);      //쓰레기봉투 삭제
        }
    }
    
    
    
    //쓰레기, exploder 생성하기
    private void InstantiateGarbage()
    {
        Vector3 spawnPosition = transform.position;
        //objCreateCount만큼의 양으로 랜덤한 물건의 오브젝트를 쓰레기봉투에서 생성
        for(int i=0; i<objCreateCount; i++)
        {
            int CreateObject = Random.Range(0, objectCount+1);
            GameObject clone = ObjectPooling.Instance.ActivatePoolItem(obj[CreateObject], spawnPosition);
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

}




