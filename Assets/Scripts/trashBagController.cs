using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trashBagController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;     //이동 속도
    [SerializeField]
    private Vector3 moveDirection;   //이동 방향
    private Rigidbody rigid;    //Rigidbody component

    // 자동으로 강을 흘러 이동
    private void Awake() {
        rigid = GetComponent<Rigidbody>();      //Rigidbody
    }

    // private void Update() {
    //     // Rigidbody component로 object 이동
    //     rigid.velocity = moveDirection * moveSpeed; 
    // }

    // //다른 object에서 호출하면 object 방향 재설정
    // public void Setup(Vector3 direction){
    //     moveDirection = direction;
    // }



}
