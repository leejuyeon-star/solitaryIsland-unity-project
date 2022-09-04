using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class garbageTouchEffect : MonoBehaviour
{
    //오브젝트 터치시 실행
    public void TouchEffect(GameObject hitObject)
    {
        GameManager.Instance.PlaySfxMusic(GameManager.sfx.PICKUP);
        (GameManager.Instance._trashCount.trashTouchCount)++;
        (GameManager.Instance._trashCount.trashCurrentCount)--;
        InGamePanelUIController.Instance.printGarbageCountUI();
        ObjectPooling.Instance.DeactivatePoolItem(hitObject);
    }

}
