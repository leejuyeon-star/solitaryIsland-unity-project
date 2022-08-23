using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 쓰레기봉투가 생성되면 일정 시간 이후 랜덤한 양과 랜덤한 물건의 오브젝트를 쓰레기봉투에서 생성, exploder도 생성, 바로터트리기
public class garbageSpawner : MonoBehaviour
{
    public int objectCount;            //오브젝트 개수
    public GameObject[] obj;       //오브젝트
    public int objCreateCount;         //한번에 스폰할 오브젝트 개수
    public GameObject exploder;        //폭탄 오브젝트
    public int waitingTime = 5;
    
    private float timer;
    private Vector3 spawnPosition;      //스폰될 장소

    public GameObject background;
    private MeshCollider backgroundMeshCollider;
    
    private Vector3 RandomPosition()
    {
        Vector3 originPosition = background.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = backgroundMeshCollider.bounds.size.x;
        float range_Z = backgroundMeshCollider.bounds.size.z;

        range_X = Random.Range( (range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range( (range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 50f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    //쓰레기 수 로드하여 랜덤한 종류로 랜덤한 곳에 뿌리기
    private void Awake()
    {
        backgroundMeshCollider = background.GetComponent<MeshCollider>();
        int _trashCurrentCount = GameManager.Instance._trashCount.trashCurrentCount;
        //objCreateCount만큼의 양으로 랜덤한 물건의 오브젝트를 쓰레기봉투에서 생성
        for(int i=0; i<_trashCurrentCount; i++)
        {
            int CreateObject = Random.Range(0, objectCount);
            GameObject clone = Instantiate(obj[CreateObject], RandomPosition(), Quaternion.Euler(0,0,0));
            clone.transform.localScale = new Vector3(100,100,100);
        }
    }
    



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
            spawnPosition = transform.position;
            //objCreateCount만큼의 양으로 랜덤한 물건의 오브젝트를 쓰레기봉투에서 생성
            for(int i=0; i<objCreateCount; i++)
            {
                int CreateObject = Random.Range(0, objectCount);
                GameObject clone = Instantiate(obj[CreateObject], spawnPosition, Quaternion.Euler(0,0,0));
                clone.transform.localScale = new Vector3(100,100,100);
            }
            //exploder도 생성
            Instantiate(exploder, spawnPosition, Quaternion.Euler(0,0,0));
            //터트리기

            //UI반영
            GameManager.Instance._trashCount.trashCurrentCount += objCreateCount;
            GameManager.Instance.printgarbageUI();
            //쓰레기봉투(이 스크립트가 들어있는 오브젝트) 삭제
            Destroy(gameObject);

            timer = 0.0f;
        }
    }
}
