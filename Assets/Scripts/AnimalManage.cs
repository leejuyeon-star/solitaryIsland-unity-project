using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   //구조체 배열을 위함
using UnityEngine.UI;      //UI 클래스 사용을 위함
using UnityEngine.EventSystems;     //애니메이션 사용시 꼭 작성

 
public class AnimalManage : MonoBehaviour
{
    public int SpawnGroupNumber;
    [Serializable] public struct SpawnGroup{
        public GameObject animalPrefab;      //생성할 동물 프리팹
        // public int AccessPoint;             //생성하기 위해 필요한 포인트
        // public int Accessheart;             //생성하기 위해 필요한 heart
        // public GameObject SpawnButton;        //스폰해주는 버튼
        public int DestroyPoint;        //소멸하기 위해 필요한 포인트
        public GameObject animalParent;     //생성한 동물이 상속될 부모 오브젝트
        public GameObject[] animalObject;
        public bool isDestroy;
    }

    private int trashCount;

    
    [SerializeField] SpawnGroup[] Spawn;
    public Vector3 spawnPosition;       //동물 생성할 위치
    public GameObject animalDeadEffectPrefab;         //동물 죽는 이펙트 오브젝트

    private Vector3[] animalDeadPosition = new [] {new Vector3(0,0,0), new Vector3(0,0,0), new Vector3(0,0,0), new Vector3(0,0,0), new Vector3(0,0,0)};

    public Sprite[] gaugeImgSample;
    public GameObject guageObj;
    private Image guageImg;
    private GameObject AnimatorObj;      //애니메이터가 포함된 오브젝트
    private Animator animator;



    // public GameObject _NoPointAlarm;    //"포인트가 부족합니다" 생성하는 txt오브젝트
    // public GameObject _NoHeartAlarm;    //"heart가 부족합니다" 생성하는 txt오브젝트

    // public GameObject AnimalSpawnCamera;
    // public GameObject InGamePanel;
    // public GameObject AnimalSpawnPanel;
    // public GameObject InventoryPanel;

    // public float RandomSpawnRange_X = 250f;        //랜덤으로 스폰될 장소 범위 x축
    // public float RandomSpawnRange_Z = 250f;        //랜덤으로 스폰될 장소 범위 z축
    // public float SpawnRange_Y = 100f;



    // public void ClickAnimalButton()
    // {
    //     int buttonNumber = findSpawnGroup();
        
    //     // 해당 동물의 포인트 <= 현 포인트인 경우, 포인트 일정량 지우고 동물 생성
    //     if(Spawn[buttonNumber].AccessPoint <= GameManager.Instance._trashCount.trashTouchCount
    //             && Spawn[buttonNumber].Accessheart <= GameManager.Instance.heart)
    //     {
    //         Debug.Log("동물 생성");
    //         // 효과음
    //         GameManager.Instance.PlaySfxMusic(GameManager.sfx.SPAWNANIMAL);

    //         // 오브젝트 설정
    //         GameObject newObj = Instantiate(Spawn[buttonNumber].animalPrefab); 
    //         newObj.transform.parent = animalParent.transform;
    //         newObj.transform.localPosition = spawnPosition;
    //         newObj.transform.localScale = new Vector3(10,10,10);

    //         //기타 변수값 갱신, UI 변화
    //         GameManager.Instance._trashCount.trashTouchCount -= Spawn[buttonNumber].AccessPoint;
    //         int index = newObj.name.IndexOf("(Clone)");
    //         if (index > 0) 
    //             newObj.name = newObj.name.Substring(0, index);
    //         GameManager.Instance.PlusAnimalCount(newObj);
    //         InGamePanelUIController.Instance.printAniamlCountUI();
    //         InGamePanelUIController.Instance.printGarbageCountUI();

    //         AnimalSpawnCamera.SetActive(true);
    //         AnimalSpawnCamera.GetComponent<animalFollow>().SendObject(newObj);
    //         InGamePanel.SetActive(false);       //!걱정된다 true/false 바꾸면 모든 함수 멈추는데..
    //         AnimalSpawnPanel.SetActive(true);
    //         InventoryPanel.SetActive(false);
    //     }
    //     else if (Spawn[buttonNumber].AccessPoint > GameManager.Instance._trashCount.trashTouchCount
    //         && Spawn[buttonNumber].Accessheart <= GameManager.Instance.heart) 
    //     {
    //         Debug.Log("포인트 부족");
    //         _NoPointAlarm.SetActive(true);
    //     }
    //     else
    //     {
    //         Debug.Log("heart 부족");
    //         _NoHeartAlarm.SetActive(true);
    //     }
    //     return;
    // }


    // 로드한 만큼의 양으로 동물 오브젝트 생성
    // private void SpawnAnimal()
    // {
    //     for(int i=0; i<SpawnGroupNumber; i++)
    //     {
    //         for(int j=0; j<GameManager.Instance.MappingAnimalCount(Spawn[i].animalPrefab); j++)
    //         {
    //             GameObject newObj = Instantiate(Spawn[i].animalPrefab); 
    //             newObj.transform.parent = animalParent[i].transform;
    //             newObj.transform.localPosition = ReturnRandomPosition(RandomSpawnRange_X, SpawnRange_Y, RandomSpawnRange_Z);
    //             newObj.transform.localScale = new Vector3(1,1,1);
    //             int index = newObj.name.IndexOf("(Clone)");
    //             if (index > 0) 
    //                 newObj.name = newObj.name.Substring(0, index);
    //         }   
    //     }
    // }
    

    // Vector3(0 ~ range_X, _Y, 0 ~ range_Z) 범위 내에서 랜덤한 위치 반환 
    private Vector3 ReturnRandomPosition(float range_X, float _Y, float range_Z)
    {
        range_X = UnityEngine.Random.Range((range_X) * -1, range_X);
        range_Z = UnityEngine.Random.Range((range_Z) * -1, range_Z);
        Vector3 RandomPostion = new Vector3(range_X, _Y, range_Z);
        return RandomPostion;
    }

    private void DestroyAnimal(int Number)
    {
        int i=0;
        foreach(GameObject obj in Spawn[Number].animalObject)
        {
            // obj.GetComponent<animalWalk>().Stop();
            animalDeadPosition[i] = obj.transform.position;
            i++;
            IEnumerator coroutin = deadAnimalAnimation(obj);
            StartCoroutine(coroutin);
            // obj.GetComponent<animalAnimationControll>().animateAnimalDeath();
        }
        // IEnumerator coroutine2 = EffectAnimalDead(i);
        IEnumerator coroutine = DelayDestroy(Number, i);
        StartCoroutine(coroutine);
        // StartCoroutine(coroutine2);
        // IEnumerator coroutine2 = EffectAnimalDead(i);
        // IEnumerator coroutine = DelayDestroy(Number);
        // StartCoroutine(coroutine);
        // StartCoroutine(coroutine2);
        Spawn[Number].isDestroy = true;
    }

    IEnumerator deadAnimalAnimation(GameObject obj)
    {
        float time = 0;
        while(time <= 2)
        {
            obj.transform.Rotate(new Vector3(0,0,time*1f));
            time += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator DelayDestroy(int Number, int count)
    {
        yield return new WaitForSeconds(6f);
        for(int i=0; i<count; i++)
        {
            ObjectPooling.Instance.ActivatePoolItem(animalDeadEffectPrefab, animalDeadPosition[i]);
        }
        yield return new WaitForSeconds(2f);
        for(int i=0; i<count; i++)
        {
            ObjectPooling.Instance.DeactivatePoolItem(animalDeadEffectPrefab);
        }
        Spawn[Number].animalParent.SetActive(false);
    }
    // IEnumerator DelayDestroy(int Number)
    // {
    //     yield return new WaitForSeconds(6f);
    //     Spawn[Number].animalParent.SetActive(false);
    // }

    // IEnumerator EffectAnimalDead(int count)
    // {
    //     for(int i=0; i<count; i++)
    //     {
    //         Debug.Log("..");
    //         ObjectPooling.Instance.ActivatePoolItem(animalDeadEffectPrefab, animalDeadPosition[i]);
    //         yield return null;
    //     }
    // }

    private void ChangeUI(int Number)
    {
        guageImg.sprite = gaugeImgSample[Number];
    }
    

    private void Update()
    {

        trashCount = GameManager.Instance._trashCount.trashCurrentCount;
        if(trashCount >= Spawn[0].DestroyPoint && !(Spawn[0].isDestroy))
        {
            DestroyAnimal(0);
            ChangeUI(0);
            animator.SetBool("isDead", true);
            GameManager.Instance.PlaySfxMusic(GameManager.sfx.DEAD);
        }
        if(trashCount >= Spawn[1].DestroyPoint && !(Spawn[1].isDestroy))
        {
            DestroyAnimal(1);
            ChangeUI(1);
            animator.SetBool("isDead", true);
            GameManager.Instance.PlaySfxMusic(GameManager.sfx.DEAD);
        }
        if(trashCount >= Spawn[2].DestroyPoint && !(Spawn[2].isDestroy))
        {
            DestroyAnimal(2);
            ChangeUI(2);
            animator.SetBool("isDead", true);
            GameManager.Instance.PlaySfxMusic(GameManager.sfx.DEAD);
        }
        if(trashCount >= Spawn[3].DestroyPoint && !(Spawn[3].isDestroy))
        {
            DestroyAnimal(3);
            ChangeUI(3);
            animator.SetBool("isDead", true);
            GameManager.Instance.PlaySfxMusic(GameManager.sfx.DEAD);
        }
        if(trashCount >= Spawn[4].DestroyPoint && !(Spawn[4].isDestroy))
        {
            DestroyAnimal(4);
            ChangeUI(4);
            animator.SetBool("isDead", true);
            GameManager.Instance.PlaySfxMusic(GameManager.sfx.DEAD);
        }
        if(trashCount >= Spawn[5].DestroyPoint && !(Spawn[5].isDestroy))
        {
            DestroyAnimal(5);
            animator.SetBool("isDead", true);
            GameManager.Instance.PlaySfxMusic(GameManager.sfx.DEAD);
            GameManager.Instance.GameOver();
        }
  

    }

    // private int findSpawnGroup()
    // {
    //     for(int i=0; i<Spawn.Length; i++)
    //     {
    //         if(EventSystem.current.currentSelectedGameObject.name == string.Format("{0}", Spawn[i].SpawnButton.name))
    //             return i;
    //     }
    //     Debug.Log("AimalSpawner의 findeSpawnGroup() 오류");
    //     return -1;
    // }


    private void Start()
    {
        guageImg = guageObj.GetComponent<Image>();
        AnimatorObj = guageObj;
        animator = AnimatorObj.GetComponent<Animator>();
        animator.SetBool("isDead", false);
    }








    
}






