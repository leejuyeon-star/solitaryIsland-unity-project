using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 일정 시간에 랜덤한 양으로 오브젝트 생성
public class trashBagSpawner : MonoBehaviour
{
    public GameObject[] obj;                //오브젝트 종류의 개수
    public int objCreateMax = 3;           //최대 생성할 오브젝트 양
    
    private float timer;
    private int waitingTime;

    private int objectCount;
    private int objCreateCount;         //실제 생성할될오브젝트 양
    Vector3 spawnPosition;               //스폰될 장소

    // private ObjectPool objectPool;          //?그냥 이렇게 스크립트 가져온다고?

 
    void Start()
    {
        timer = 0.0f;
        waitingTime = 5;
        // objectPool = new ObjectPool();
    }
    
    void Update()
    {
        timer += Time.deltaTime;   
        if(timer > waitingTime)
        {
            //Action
            //메모리 풀 이용
            spawnPosition = transform.position;
            objCreateCount = Random.Range(0, objCreateMax);
            for(int i=0; i<objCreateCount; i++){
                Instantiate(obj[0], spawnPosition,Quaternion.Euler(0,0,0));
                // objectPool.ActivatePoolItem();  //!오브젝트 리턴하는데 이걸로 뭐하지?
            }
            timer = 0;
        }
    }

}
