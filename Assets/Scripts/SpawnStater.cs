using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 처음실행시 로드된 양만큼 오브젝트들 생성
public class SpawnStater : MonoBehaviour
{
    public int objectCount;            //오브젝트 개수
    public GameObject[] garbagePrefab;       //쓰레기 프리팹
    public GameObject[] animalPrefab;       //동물 프리팹

    public GameObject animalParent;         //동물이 상속될 부모 오브젝트

    public float range_X = 250f;        //랜덤으로 스폰될 장소 범위 x축
    public float range_Z = 250f;        //랜덤으로 스폰될 장소 범위 z축
    public float _Y = 100f;


    private void Awake()
    {
        SpawnGarbage();
        SpawnAnimal();
    }


    //로드한 만큼의 양으로 랜덤한 물건의 오브젝트를 생성
    private void SpawnGarbage()
    {
        int _trashCurrentCount = GameManager.Instance._trashCount.trashCurrentCount;
        for(int i=0; i<_trashCurrentCount; i++)
        {
            int CreateObject = Random.Range(0, objectCount);
            GameObject clone = ObjectPooling.Instance.ActivatePoolItem(garbagePrefab[CreateObject], ReturnRandomPosition(range_X, _Y, range_Z));
            clone.transform.localScale = new Vector3(100,100,100);
        }
    }


    // 로드한 만큼의 양으로 동물 오브젝트 생성
    private void SpawnAnimal()
    {
        for(int i=0; i<animalPrefab.Length; i++)
        {
            for(int j=0; j<GameManager.Instance.MappingAnimalCount(animalPrefab[i]); j++)
            {
                int index;
                GameObject newObj = Instantiate(animalPrefab[i]); 
                newObj.transform.parent = animalParent.transform;
                newObj.transform.localPosition = ReturnRandomPosition(range_X, _Y, range_Z);
                newObj.transform.localScale = new Vector3(10,10,10);
                index = newObj.name.IndexOf("(Clone)");
                if (index > 0) 
                    newObj.name = newObj.name.Substring(0, index);
            }   
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