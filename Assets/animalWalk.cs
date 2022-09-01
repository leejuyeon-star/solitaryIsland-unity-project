using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//자동으로 움직이는 오브젝트 (터치시 반응, 애니메이션 활성화시 이동)
public class animalWalk : MonoBehaviour
{
    int stateint = 0;
    Vector3 moveDirection;
    [SerializeField] private float walkSpeed = 5f;     //이동 속도
    [SerializeField] private float runSpeed = 10f;     //이동 속도
    [SerializeField] int MinState =  1;
    [SerializeField] int MaxState =  5;
    [SerializeField] int walkState = 4;
    [SerializeField] int runState = 5;

    private bool stop;

    private void Start()
    {
        moveDirection = new Vector3(0,0,0);
        
        //1초마다 실행
        InvokeRepeating("setState", 0.0f, 1.0f);
        stop = false;
    }


    //animator의 state변수를 랜덤으로 선택하는 함수
    private void setState() {
        moveDirection = selectDirection();
        stateint = Random.Range(MinState, MaxState);
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
        if(!stop)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezeRotation;
            // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;
            //walk일 때
            if(stateint == walkState){
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;
                transform.position += moveDirection * walkSpeed * Time.deltaTime;
                transform.LookAt(transform.position + moveDirection);
            }
            //run일 때
            else if (stateint == runState){
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;
                transform.position += moveDirection * runSpeed * Time.deltaTime;
                transform.LookAt(transform.position + moveDirection);
            }
            // else
            // {
            //     GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;
            // }
        }
    }

    public void Stop()
    {
        stop = true;
    }







}
