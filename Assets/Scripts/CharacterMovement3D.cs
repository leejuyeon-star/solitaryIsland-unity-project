using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//기능 : CharacterController 컴포넌트로 3D 오브젝트 움직이기
//유니티 강의 들어보기
public class CharacterMovement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;     //이동 속도

    [SerializeField]
    private Vector3 moveDirection;   //이동 방향
    private CharacterController characterController;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    private void Update() {
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    // //다른 object에서 호출하면 object 방향 재설정
    // public void Setup(Vector3 direction){
    //     moveDirection = direction;
    // }

}
