using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 동물 생성시 동물에게 카메라 줌인. 
// 사용법 : 카메라에 스크립트 넣기, offset에 현 카메라의 x,y,z 좌표 넣기
public class animalFollow : MonoBehaviour
{
    private Vector3 target;    //줌인할 오브젝트
    public Vector3 offset;

    void OnEnable()
    {
    }

    private void Update()
    {
        transform.position = target + offset;
    }

    // public IEnumerator SendObject(GameObject obj)
    // {
    //     target = obj.transform.position;
    // }
    public void SendObject(GameObject obj)
    {
        target = obj.transform.position;
    }
}
