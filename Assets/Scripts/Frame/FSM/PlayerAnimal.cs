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
	public PlayerAttack(Animator tmpAnimator)
	{
		this.animator = tmpAnimator;
	}
	public override void OnEnter()
	{
		this.animator.SetInteger("StateIndex", 2);
	}

	public override void OnLeave()
	{

	}

	public override void UpDate()
	{

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
