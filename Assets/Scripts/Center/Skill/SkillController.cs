using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillController : UIBase {
	public float CD = 1f;
	private Image image;
    FSMManager fsmManger;
    Transform targetObj;
	void Start () {
        image = GetChildGameObject("img_1_L").GetComponent<Image>();
        targetObj = GameObject.FindWithTag("Player").transform;
		fsmManger = new FSMManager((byte)AnimalState.Max);
		Animator ani = targetObj.GetComponent<Animator>();
		PlayerIdle attack_a = new PlayerIdle(ani);
		fsmManger.AddState(attack_a);
		PlayerWalk attack_1 = new PlayerWalk(ani);
        fsmManger.AddState(attack_1);
		PlayerJump attack_2 = new PlayerJump(ani);
		fsmManger.AddState(attack_2);
		PlayerJump attack_3 = new PlayerJump(ani);
        fsmManger.AddState(attack_3);
        //添加事件
        AddButtonListen("but_a_N", ASkill);
        AddButtonListen("but_1_N", Skill1);
        AddButtonListen("but_2_N", Skill2);
        AddButtonListen("but_3_N", Skill3);

	}
	
    void ASkill()
    {
       // fsmManger.ChangeState((byte)AnimalSkillState.Attack_a);
        fsmManger.ChangeState((byte)AnimalState.Walk);
    }
    void Skill1()
    {
		if (image.fillAmount != 0)
		{
			//return false;
		}
		else
		{
			image.fillAmount = 1;
			//return true;
		}
    }
	void Skill2()
	{

	}
	void Skill3()
	{

	}
	void Update () {
		if (image.fillAmount != 0)
		{
			image.fillAmount -= Time.deltaTime / CD;
		}
	}
}

