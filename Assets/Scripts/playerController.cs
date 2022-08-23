using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;     //사용시 꼭 작성

//자동으로 움직이는 오브젝트 (터치시 반응, 애니메이션 활성화시 이동)
public class playerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Animator animator;
    int stateint = 0;
    Vector3 moveDirection;
    [SerializeField]
    private float walkSpeed = 500.0f;     //이동 속도
    [SerializeField]
    private float runSpeed = 1000.0f;     //이동 속도
    [SerializeField]
    int MinState =  1;
    [SerializeField]
    int MaxState =  8;
    [SerializeField]
    int walkState = 4;
    [SerializeField]
    int runState = 5;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("touch", false);
        animator.SetInteger("state", 0);
        moveDirection = new Vector3(0,0,0);
        
        //1초마다 실행
        InvokeRepeating("setState", 0.0f, 1.0f);
    }

    // object 터치하는 순간 1회 호출(IPointerDownHandler)
    public void OnPointerDown(PointerEventData eventData){
        animator.SetBool("touch", true);
    }

    //object를 떼는 순간 1회 호출(IPointerUpHandler)
    public void OnPointerUp(PointerEventData eventData){
        animator.SetBool("touch", false);
    }


    //animator의 state변수를 랜덤으로 선택하는 함수
    private void setState() {
        moveDirection = selectDirection();
        stateint = Random.Range(MinState, MaxState);
        animator.SetInteger("state", stateint);
    }

        
    // 오브젝트의 이동방향을 랜덤으로 선택하는 함수
    public Vector3 selectDirection(){
        int dirNumber = Random.Range(0, 4); 
        if(dirNumber == 0){
            // Debug.Log("북");
            return new Vector3(0,0,1);    
        }
        else if (dirNumber == 1){
            // Debug.Log("남");
            return new Vector3(0,0,-1);  
        }
        else if (dirNumber == 2){
            // Debug.Log("동");
            return new Vector3(1,0,0);   
        }
        else{
            // Debug.Log("서");
            return new Vector3(-1,0,0);
        }
    }


    //state가 walk일때 or run일때 이동
    private void Update() {
        //walk일 때
        if(stateint == walkState){
            transform.position += moveDirection * walkSpeed * Time.deltaTime;
            transform.LookAt(transform.position + moveDirection);
        }
        //run일 때
        else if (stateint == runState){
            transform.position += moveDirection * runSpeed * Time.deltaTime;
            transform.LookAt(transform.position + moveDirection);
        }


    }







}
