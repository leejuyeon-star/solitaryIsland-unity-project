
// 스크립트의 기능 : 
// - 3d 모바일 환경에서 틀정 레이어에 해당하는 오브젝트를 터치 가능하도록 구현
// - 오직 모바일에서만 작동 가능.

// 사용법:
//! - empty game object에 해당 스크립트 넣기, raycaster 3D 넣기 카메라가 0,0,0에 있어야 하는이유?
// - 스크립트에 카메라 지정하기
// - 터치할 오브젝트에 collider 넣기 
// - 주의! 카메라에 collider 넣으면 작동하지 않음

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchesScript : MonoBehaviour
{
    public Camera Camera;
    public LayerMask LayerMask;     //충돌 감지할 레이어


#if UNITY_IOS || UNITY_ANDROID

    RaycastHit hitInfo;
    float MaxDistance = Mathf.Infinity;  
    protected Plane Plane;
    bool touch = false;

    private void Awake()
    {
        if (Camera == null) 
        {
            Camera = Camera.main;
        }

    }

    private void Update() 
    {
        // 오브젝트 한손가락으로 터치시(드래그x) effect발생
        if (Input.touchCount == 1 && !touch) 
        {
            Vector2 screenPos = Input.GetTouch(0).position;
            var rayNow = Camera.ScreenPointToRay(screenPos);
            if (Physics.Raycast(rayNow, out hitInfo, MaxDistance, LayerMask))       //오브젝트 터치시 hitInfo에 해당 오브젝트의 정보 저장
            {
                //effect
                // GameManager에게 해당 오브젝트를 터치했음을 알림
                GameObject hitObject = hitInfo.transform.gameObject;
                GetComponent<garbageTouchEffect>().TouchEffect(hitObject);
                
            }
            touch = true;
        } 
        else if (Input.touchCount <= 0 && touch) 
        {
            touch = false;
        }

        // 오브젝트 여러손가락으로 터치시 effect 발생
        

    }



#endif




}
