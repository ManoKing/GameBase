using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMBase
{
    public Animator animator;
    public abstract void OnEnter();
    public abstract void OnLeave();
    public abstract void UpDate();

}

public class FSMManager
{
    FSMBase[] allState;
    byte curState;
    short stateIndex;
    public FSMManager (byte count)
    {
        allState = new FSMBase[count];
        curState = 0;
        stateIndex = -1;
    }
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="tmpBase">Tmp base.</param>
    public void AddState(FSMBase tmpBase)
    {
        if (curState<allState.Length)
        {
            allState[curState] = tmpBase;
            curState++;
        }
    }
    /// <summary>
    /// 状态跳转
    /// </summary>
    /// <param name="index">Index.</param>
    public void ChangeState(byte index)
    {
        if (stateIndex!=-1)
        {
            allState[curState].OnLeave();
        }
        stateIndex = curState;
        allState[index].OnEnter();
        curState = index;
    }

    public void Update()
    {
        if (stateIndex!=-1)
        {
            allState[curState].UpDate();
        }
    }
}
