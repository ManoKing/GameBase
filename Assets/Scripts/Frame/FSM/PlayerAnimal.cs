using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangeDelegate(byte index);

public class PlayerIdle : FSMBase
{
    public PlayerIdle(Animator tmpAnimal)
    {
        this.animator = tmpAnimal;
    }
    public override void OnEnter()
    {
        this.animator.SetInteger("StateIndex",1);
    }

    public override void OnLeave()
    {
        
    }

    public override void UpDate()
    {
        
    }
}

public class PlayerAttack : FSMBase
{
    ChangeDelegate changeIdle;
    public PlayerAttack(Animator tmpAnimator,ChangeDelegate tmpDlegate)
    {
        this.animator = tmpAnimator;
        changeIdle = tmpDlegate;
    }

    float timer = 0;
    bool isPlayFinish;
    public override void OnEnter()
    {
        this.animator.SetInteger("StateIndex",2);
        timer = 0;
        isPlayFinish = false;
    }

    public override void OnLeave()
    {
        timer = 0;
        isPlayFinish = false;
    }

    public override void UpDate()
    {
        timer += Time.deltaTime;
        if (timer>0.28f&&!isPlayFinish)
        {
            isPlayFinish = true;

            //do samething
        }
        if (timer>1)
        {
            timer = 0;
            isPlayFinish = false;
            changeIdle((byte)AnimalState.Idle);
        }
    }
}
public class PlayerWalk : FSMBase
{
    public PlayerWalk(Animator tmpAnimator)
    {
        this.animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        this.animator.SetInteger("StateIndex",3);
    }

    public override void OnLeave()
    {
        
    }

    public override void UpDate()
    {
        
    }
}
public class PlayerJump : FSMBase
{
    public PlayerJump (Animator tmpAnimator)
    {
        this.animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        this.animator.SetInteger("StateIndex",4);
    }

    public override void OnLeave()
    {
        
    }

    public override void UpDate()
    {
        
    }
}
