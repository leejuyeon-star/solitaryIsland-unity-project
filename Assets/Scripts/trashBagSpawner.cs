using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      //UI 클래스 사용을 위함
using TMPro;        //TextmeshPro사용을 위함
using UnityEngine.EventSystems;     //애니메이션 사용시 꼭 작성


// 일정 시간에 랜덤한 문구 나오면서 쓰레기봉투 생성
public class trashBagSpawner : MonoBehaviour
{
    public GameObject obj;                //쓰레기봉투
    public int objCreateMax = 3;           //최대 생성할 오브젝트 양
    
    private float timer;
    public int waitingTime = 10;

    private int objectCount;
    private int objCreateCount;         //실제 생성할될오브젝트 양
    Vector3 spawnPosition;               //스폰될 장소

    public GameObject alarmTxt;
    private TextMeshProUGUI alarmUITxt;

    public GameObject parentGroup;      //쓰레기봉투가 상속될 부모 오브젝트

    public GameObject AnimatorObj;      //애니메이터가 포함된 오브젝트
    private Animator animator;


    private List<string> alarmContent = new List<string>() {
        "오늘은 맥주 축제가 열리는 날입니다! 모두 즐겨요!", 
        "와라신문 - 스마트폰 E33 10G 국내 출시", 
        "주방신문 - 주방가구 신제품 '잘라잘라' 출시"
    };

 
    private void Start()
    {
        timer = 0.0f;
        alarmUITxt = alarmTxt.GetComponent<TextMeshProUGUI>();
        animator = AnimatorObj.GetComponent<Animator>();
        animator.SetBool("alarmOn", false);
        // objectPool = new ObjectPool();
    }
    
    private void Update()
    {
        timer += Time.deltaTime;   
        if(timer > waitingTime)
        {
            //Action
            printUI();      //UI에 띄우기
            InstantiateTrash();     // 쓰레기봉투 생성
            timer = 0;
        }
    }


    //UI에 띄우기
    private void printUI()
    {
        alarmUITxt.text = string.Format("{0}", alarmContent[SelectAlarmContent()]);
        animator.SetBool("alarmOn", true);
        return;
    }


    //alarmContent 랜덤 선택하기
    private int SelectAlarmContent()
    {
        int alarmCount = Random.Range(0, alarmContent.Count);
        return alarmCount;
    }


    //쓰레기 봉투 생성하기
    private void InstantiateTrash()
    {
        spawnPosition = transform.position;
        objCreateCount = Random.Range(1, objCreateMax);
        for(int i=0; i<objCreateCount; i++){
            GameObject clone = ObjectPooling.Instance.ActivatePoolItem(obj);
            // (obj[0], spawnPosition,Quaternion.Euler(0,0,0))
            //부모에 상속하기
            // clone.transform.parent = parentGroup.transform;
            clone.transform.localPosition = spawnPosition;
        }
    }




}
