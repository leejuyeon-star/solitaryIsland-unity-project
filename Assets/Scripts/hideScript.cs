using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideScript : StateMachineBehaviour
{
    // 상태가 다음 상태로 바뀌기 직전에 실행
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("alarmOn", false);
    }
}
