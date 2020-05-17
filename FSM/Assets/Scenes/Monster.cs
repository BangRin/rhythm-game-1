using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eState
{
    Idle,
    Follow,
    Attack
}

public class Monster : MonoBehaviour
{
    private eState curState = eState.Idle;
    private GameObject target;

    private void Update()
    {
        switch(curState)
        {
            case eState.Idle:
                Move();
                if(isFindPlayer)
                {
                    ChangeState(eState.Follow);
                }
                break;
            case eState.Attack:
                AttackTarget();
                if (canAttackPlayer == false)
                {
                    ChangeState(eState.Follow);
                }
                else if (isPlayerDead)
                {
                    ChangeState(eState.Idle);
                }
                break;
            case eState.Follow:
                MoveTarget();
                if(canAttackPlayer)
                {
                    ChangeState(eState.Attack);
                }
                break;
        }
    }
    private void ChangeState(eState targetState)
    {
        if (curState == targetState)
            return;

        switch(curState)
        {
            case eState.Idle:
                OnExitIdle();
                break;
            case eState.Attack:
                OnExitAttack();
                break;
            case eState.Follow:
                OnExitFollow();
                break;
        }
        curState = targetState;
        switch (curState)
        {
            case eState.Idle:
                OnEnterIdle();
                break;
            case eState.Attack:
                OnEnterAttack();
                break;
            case eState.Follow:
                OnEnterFollow();
                break;
        }
    }

    

}
