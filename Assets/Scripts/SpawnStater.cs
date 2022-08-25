using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStater : MonoBehaviour
{
    public int objectCount;            //오브젝트 개수
    public GameObject[] garbagePrefab;       //쓰레기 프리팹
    public GameObject[] animalPrefab;       //동물 프리팹

    public GameObject animalParent;         //동물이 상속될 부모 오브젝트

    private float range_X = 250;        //랜덤으로 스폰될 장소 범위 x축
    private float range_Z = 250;        //랜덤으로 스폰될 장소 범위 z축


    //쓰레기 수 로드하여 랜덤한 종류로 랜덤한 곳에 뿌리기
    private void Awake()
    {
        SpawnGarbage();
        SpawnAnimal();
    }


    //로드한 만큼의 양으로 랜덤한 물건의 오브젝트를 생성
    private void SpawnGarbage()
    {
        int _trashCurrentCount = GameManager.Instance._trashCount.trashCurrentCount;
        //로드한 만큼의 양으로 랜덤한 물건의 오브젝트를 생성
        for(int i=0; i<_trashCurrentCount; i++)
        {
            int CreateObject = Random.Range(0, objectCount);
            GameObject clone = ObjectPooling.Instance.ActivatePoolItem(garbagePrefab[CreateObject]);
            clone.transform.position = RandomPosition();
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
                newObj.transform.position = RandomPosition();
                newObj.transform.parent = animalParent.transform;
                newObj.transform.localScale = new Vector3(10,10,10);
                index = newObj.name.IndexOf("(Clone)");
                if (index > 0) 
                    newObj.name = newObj.name.Substring(0, index);
            }   
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
