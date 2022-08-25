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
    // public GameObject parentGroup;      //쓰레기봉투가 상속될 부모 오브젝트

    void start()
    {
        timer = 0.0f;
        waitingTime = Random.Range(5, 20);
    }
    
    void Update()
    {
        
        timer += Time.deltaTime;       
        if(timer > waitingTime)  //쓰레기봉투가 생성된 시점부터 waitingTime 이후 실행
        {
            //Action
            InstantiateGarbage();       //쓰레기 생성하기
            printUI();      //UI반영
            ObjectPooling.Instance.DeactivatePoolItem(gameObject);
            // Destroy(gameObject);         //쓰레기봉투(이 스크립트가 들어있는 오브젝트) 삭제
            timer = 0.0f;
        }
    }
    
    
    
    //쓰레기, exploder 생성하기
    private void InstantiateGarbage()
    {
        Vector3 spawnPosition;      //스폰될 장소
        spawnPosition = transform.position;
        //objCreateCount만큼의 양으로 랜덤한 물건의 오브젝트를 쓰레기봉투에서 생성
        for(int i=0; i<objCreateCount; i++)
        {
            int CreateObject = Random.Range(0, objectCount+1);
            GameObject clone = ObjectPooling.Instance.ActivatePoolItem(obj[CreateObject]);
            // GameObject clone = Instantiate(obj[CreateObject], spawnPosition, Quaternion.Euler(0,0,0));
            clone.transform.position = spawnPosition;   //
            
            // //부모에 상속하기
            // inheritToParent(clone, spawnPosition);
        }
        //exploder도 생성
        //! exploder 사라지는 스크립트 오브젝트 풀링으로 수정해야함
        GameObject exploderClone = ObjectPooling.Instance.ActivatePoolItem(exploder);
        exploderClone.transform.position = spawnPosition;
        // GameObject exploderClone = Instantiate(exploder, spawnPosition, Quaternion.Euler(0,0,0));
        // //부모에 상속하기       (오브젝트 풀링 후에 하기)
        // inheritToParent(exploderClone, spawnPosition);
    }

    //UI에 띄우기
    private void printUI()
    {
        GameManager.Instance._trashCount.trashCurrentCount += objCreateCount;
        GameManager.Instance.printgarbageUI();
    }

    // // 부모에 상속하기
    // private void inheritToParent(GameObject gameobject, Vector3 spawnPosition)
    // {
    //     gameobject.transform.parent = parentGroup.transform;
    //     gameobject.transform.localPosition = spawnPosition;
    //     return;
    // }

}




