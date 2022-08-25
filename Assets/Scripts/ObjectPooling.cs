using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;      //싱글톤

    public GameObject trashBagPrefab;         //쓰레기봉투
    public GameObject exploder;               //exploder
    public GameObject[] garbagePrefab;        //쓰레기들
    

    public GameObject trashBagParent;       //쓰레기봉투가 상속될 그룹
    public GameObject exploderParent;       // exploder가 상속될 그룹
    public GameObject garbageParent;        //쓰레기가 상속될 그룹

    public int increaseCount = 5;      //오브젝트가 부족할때 Instantiate()로 추가 생성되는 오브젝트 개수

    private Queue<GameObject> trashBagQueue = new Queue<GameObject>();  //쓰레기봉투 큐

    private Queue<GameObject> exploderQueue = new Queue<GameObject>();  //exploder 큐

    private Queue<GameObject> garbageQueue0 = new Queue<GameObject>();  //쓰레기 큐
    private Queue<GameObject> garbageQueue1 = new Queue<GameObject>();  //쓰레기 큐
    private Queue<GameObject> garbageQueue2 = new Queue<GameObject>();  //쓰레기 큐
    private Queue<GameObject> garbageQueue3 = new Queue<GameObject>();  //쓰레기 큐
    private Queue<GameObject> garbageQueue4 = new Queue<GameObject>();  //쓰레기 큐
    private Queue<GameObject> garbageQueue5 = new Queue<GameObject>();  //쓰레기 큐
    private Queue<GameObject> garbageQueue6 = new Queue<GameObject>();  //쓰레기 큐
    private Queue<GameObject> garbageQueue7 = new Queue<GameObject>();  //쓰레기 큐
    private Queue<GameObject> garbageQueue8 = new Queue<GameObject>();  //쓰레기 큐
    private Queue<GameObject> garbageQueue9 = new Queue<GameObject>();  //쓰레기 큐

    
    private void Awake()
    {
        Instance = this;
        FirstInstantiateObjects();
    }

    //처음 awake시 모든 오브젝트를 inistiate 해놓기
    private void FirstInstantiateObjects() 
    {
        InstantiateObjects(trashBagPrefab);
        InstantiateObjects(exploder);
        InstantiateObjects(garbagePrefab[0]);
        InstantiateObjects(garbagePrefab[1]);
        InstantiateObjects(garbagePrefab[2]);
        InstantiateObjects(garbagePrefab[3]);
        InstantiateObjects(garbagePrefab[4]);
        InstantiateObjects(garbagePrefab[5]);
        InstantiateObjects(garbagePrefab[6]);
        InstantiateObjects(garbagePrefab[7]);
        InstantiateObjects(garbagePrefab[8]);
        InstantiateObjects(garbagePrefab[9]);
        return;
    }   

    

    //오브젝트 instantiate, 큐에 저장
    private void InstantiateObjects(GameObject obj)    
    {
        GameObject newObj;
        int index;
        for(int i=0; i<increaseCount; i++)
        {
            newObj = Instantiate(obj); 
            newObj.SetActive(false);
            MappingParent(obj, newObj);
            index = newObj.name.IndexOf("(Clone)");
            if (index > 0) 
                newObj.name = newObj.name.Substring(0, index);
            Instance.MappingQueue(obj).Enqueue(newObj);
        }
        return;
    }


    //오브젝트 활성화
    public GameObject ActivatePoolItem(GameObject obj)
    {
        if(Instance.MappingQueue(obj).Count <= 0)      
        {
            Instance.InstantiateObjects(obj);              
        }
        GameObject gameobject = Instance.MappingQueue(obj).Dequeue();
        gameobject.SetActive(true);
        return gameobject;
    }


    //오브젝트 비활성화
    public void DeactivatePoolItem(GameObject obj)
    {
        Instance.MappingQueue(obj).Enqueue(obj);
        obj.SetActive(false);
        return;
    }


    //!!!!오브젝트에 해당하는 큐를 매핑 안된다!!!
    private Queue<GameObject> MappingQueue(GameObject obj)
    {
        
        Queue<GameObject> ObjectQueue = new Queue<GameObject>();
        if(obj.name == trashBagPrefab.name) 
        {
            ObjectQueue = trashBagQueue;
        }
        else if (obj.name == exploder.name)
        {
            ObjectQueue = exploderQueue;
        }
        else if (obj.name == garbagePrefab[0].name)
        {
            ObjectQueue = garbageQueue0;
        } 
        else if (obj.name == garbagePrefab[1].name)
        {
            ObjectQueue = garbageQueue1;
        }
        else if (obj.name == garbagePrefab[2].name)
        {
            ObjectQueue = garbageQueue2;
        }
        else if (obj.name == garbagePrefab[3].name)
        {
            ObjectQueue = garbageQueue3;
        }
        else if (obj.name == garbagePrefab[4].name)
        {
            ObjectQueue = garbageQueue4;
        }
        else if (obj.name == garbagePrefab[5].name)
        {
            ObjectQueue = garbageQueue5;
        }
        else if (obj.name == garbagePrefab[6].name)
        {
            ObjectQueue = garbageQueue6;
        }
        else if (obj.name == garbagePrefab[7].name)
        {
            ObjectQueue = garbageQueue7;
        }
        else if (obj.name == garbagePrefab[8].name)
        {
            ObjectQueue = garbageQueue8;
        }
        else if (obj.name == garbagePrefab[9].name)
        {
            ObjectQueue = garbageQueue9;
        }
        else
        {
            Debug.Log("error!! ObjectPooling의 MappingQueue() 오류");
        }
        return ObjectQueue;
    }


    //오브젝트가 상속될 부모 매핑
    private void MappingParent(GameObject obj, GameObject newObj)
    {
        GameObject objectParent;
        if(obj == trashBagPrefab) 
        {
            objectParent = trashBagParent;
        }
        else if (obj == exploder)
        {
            objectParent = exploderParent;
        }
        else
        {
            objectParent = garbageParent;
        }
        newObj.transform.parent = objectParent.transform;
        // obj.transform.localPosition = spawnPosition;
        return;
    }


}
