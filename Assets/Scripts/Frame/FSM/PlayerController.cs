using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalState
{
    Idle,
    Attack,
    Walk,
    Jump,
    Max

}
public class PlayerController : MonoBehaviour {

    FSMManager fsmManger;
    private void Start()
    {
        fsmManger = new FSMManager((byte)AnimalState.Max);
        Animator ani = GetComponent<Animator>();
        PlayerIdle tmpIdle = new PlayerIdle(ani);
        fsmManger.AddState(tmpIdle);
//        PlayerAttack tmpAttack = new PlayerAttack(ani);
 //       fsmManger.AddState(tmpAttack);
        PlayerWalk tmpWalk= new PlayerWalk(ani);
        fsmManger.AddState(tmpWalk);
        PlayerJump tmpJump = new PlayerJump(ani);
        fsmManger.AddState(tmpJump);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            fsmManger.ChangeState((byte)AnimalState.Walk);
        }
    }
}
