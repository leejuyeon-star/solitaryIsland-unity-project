using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageSpawnStater : MonoBehaviour
{
    public int objectCount;            //오브젝트 개수
    public GameObject[] obj;       //오브젝트

    private float range_X = 250;        //랜덤으로 스폰될 장소 범위 x축
    private float range_Z = 250;        //랜덤으로 스폰될 장소 범위 z축

    public GameObject parentGroup;      //쓰레기봉투가 상속될 부모 오브젝트


    //쓰레기 수 로드하여 랜덤한 종류로 랜덤한 곳에 뿌리기
    private void Start()
    {
        int _trashCurrentCount = GameManager.Instance._trashCount.trashCurrentCount;
        //로드한 만큼의 양으로 랜덤한 물건의 오브젝트를 쓰레기봉투에서 생성
        for(int i=0; i<_trashCurrentCount; i++)
        {
            int CreateObject = Random.Range(0, objectCount);
            Vector3 randomPosition = RandomPosition();
            GameObject clone = ObjectPooling.Instance.ActivatePoolItem(obj[CreateObject]);
            clone.transform.position = randomPosition;
            // GameObject clone = Instantiate(obj[CreateObject], randomPosition, Quaternion.Euler(0,0,0));
            clone.transform.localScale = new Vector3(100,100,100);
            // 부모에 상속하기
            // inheritToParent(clone, randomPosition);
        }
    }

    //랜덤한 장소 선택
    private Vector3 RandomPosition()
    {
        range_X = Random.Range((range_X) * -1, range_X);
        range_Z = Random.Range((range_Z) * -1, range_Z);
        Vector3 RandomPostion = new Vector3(range_X, 100f, range_Z);
        // Vector3 respawnPosition = originPosition + RandomPostion;
        Vector3 respawnPosition = RandomPostion;
        return respawnPosition;
    }

    // // 부모에 상속하기
    // private void inheritToParent(GameObject gameobject, Vector3 spawnPosition)
    // {
    //     gameobject.transform.parent = parentGroup.transform;
    //     gameobject.transform.localPosition = spawnPosition;
    //     return;
    // }

}
