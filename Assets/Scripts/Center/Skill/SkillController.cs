using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum AnimalStateSkill
{
	Idle,
    Run,
    Walk,
    Skill1,
    Skill2,
    Skilla,
    Skill3,
    Hit,
    Die,
	Max
}
public class SkillController : UIBase {
	public float CD = 2f;
	private Image image;
    Image image2;
    Image image3;
    FSMManager fsmManger;
    Transform targetObj;
	void Start () {
        //获取技能冷却图片
        image = GetChildGameObject("img_1_L").GetComponent<Image>();
        image2 = GetChildGameObject("img_2_L").GetComponent<Image>();
        image3 = GetChildGameObject("img_3_L").GetComponent<Image>();
        targetObj = GameObject.FindWithTag("Player").transform;
        //添加动作
		fsmManger = new FSMManager((byte)AnimalStateSkill.Max);
		Animator ani = targetObj.GetComponent<Animator>();
        Idle idle = new Idle(ani);
        fsmManger.AddState(idle);
		Idle run = new Idle(ani);
		fsmManger.AddState(run);
		Idle walk = new Idle(ani);
        fsmManger.AddState(walk);
		Skill1 attack_1 = new Skill1(ani,ChangeState);
        fsmManger.AddState(attack_1);
		Skill2 attack_2 = new Skill2(ani,ChangeState);
        fsmManger.AddState(attack_2);
		Skilla attack_a = new Skilla(ani,ChangeState);
        fsmManger.AddState(attack_a);
		Skill3 attack_3 = new Skill3(ani,ChangeState);
        fsmManger.AddState(attack_3);
        //添加事件
        AddButtonListen("but_a_N", ASkill);
        AddButtonListen("but_1_N", Skill1);
        AddButtonListen("but_2_N", Skill2);
        AddButtonListen("but_3_N", Skill3);

	}
	public void ChangeState(byte index)
	{
		fsmManger.ChangeState(index);
	}
    void ASkill()
    {
       // fsmManger.ChangeState((byte)AnimalSkillState.Attack_a);
        fsmManger.ChangeState((byte)AnimalStateSkill.Skilla);
        AudioPlayer.Instance.Play("attack3");
        //AttackController.instance.Attack();
    }
    void Skill1()
    {
		if (image.fillAmount != 0)
		{
            
			//return false;
		}
		else
		{
            fsmManger.ChangeState((byte)AnimalStateSkill.Skill1);
			image.fillAmount = 1;
			GameObject obj = Resources.Load<GameObject>("RFX/39_RFX_Trajectory_Electro1");
            GameObject prompt = Instantiate(obj, targetObj);
            AudioPlayer.Instance.Play("attack1");
			//return true;
		}
    }

	void Skill2()
	{
		if (image2.fillAmount != 0)
		{
			//return false;
		}
		else
		{
            fsmManger.ChangeState((byte)AnimalStateSkill.Skill2);
			image2.fillAmount = 1;
			GameObject obj = Resources.Load<GameObject>("RFX/30_RFX_Magic_LightTeleport1");
			GameObject prompt = Instantiate(obj, targetObj.position, Quaternion.identity);
            AudioPlayer.Instance.Play("attack2");
			//return true;
		}
	}
   
	void Skill3()
	{
		if (image3.fillAmount != 0)
		{
			//return false;
		}
		else
		{
            fsmManger.ChangeState((byte)AnimalStateSkill.Skill3);
			image3.fillAmount = 1;
			GameObject obj = Resources.Load<GameObject>("RFX/27_RFX_Magic_FlameSwirl1");

			GameObject prompt = Instantiate(obj, targetObj.position, Quaternion.identity);
            AudioPlayer.Instance.Play("Skill");
            StartCoroutine(RFXTimer());
			//return true;
		}
	}
	public IEnumerator RFXTimer()
	{

		yield return new WaitForSeconds(3f);
		Destroy(GameObject.Find("27_RFX_Magic_FlameSwirl1(Clone)"));
	}
	void Update () {
		if (image.fillAmount != 0)
		{
			image.fillAmount -= Time.deltaTime / CD;
		}
		if (image2.fillAmount != 0)
		{
			image2.fillAmount -= Time.deltaTime / 5;
		}
		if (image3.fillAmount != 0)
		{
            image3.fillAmount -= Time.deltaTime / 15;
		}
        fsmManger.Update();
    }
}
//技能2
public class Idle : FSMBase
{
	public Idle(Animator tmpAnimal)
	{
		this.animator = tmpAnimal;
	}
	public override void OnEnter()
	{
        this.animator.SetInteger("StateIndex", 1);
	}

	public override void OnLeave()
	{

	}

	public override void UpDate()
	{

	}
}
//技能1
public class Skill1 : FSMBase
{
    ChangeDelegate changeIdle;
	public Skill1(Animator tmpAnimal,ChangeDelegate tmpDlegate)
	{
		this.animator = tmpAnimal;
        changeIdle = tmpDlegate;
	}
	float timer = 0;
	bool isPlayFinish;
	public override void OnEnter()
	{
		this.animator.SetInteger("StateIndex", 4);
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
		if (timer > 0.28f && !isPlayFinish)
		{
			isPlayFinish = true;

			//do samething
		}
		if (timer > 1)
		{
			timer = 0;
			isPlayFinish = false;
			changeIdle((byte)AnimalStateSkill.Idle);
		}
	}
}
//技能2
public class Skill2: FSMBase
{
	ChangeDelegate changeIdle;
	public Skill2(Animator tmpAnimal, ChangeDelegate tmpDlegate)
	{
		this.animator = tmpAnimal;
		changeIdle = tmpDlegate;
	}
	float timer = 0;
	bool isPlayFinish;
	public override void OnEnter()
	{
		this.animator.SetInteger("StateIndex", 5);
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
		if (timer > 0.28f && !isPlayFinish)
		{
			isPlayFinish = true;

			//do samething
		}
		if (timer > 2)
		{
			timer = 0;
			isPlayFinish = false;
			changeIdle((byte)AnimalStateSkill.Idle);
		}
	}
}

//技能a
public class Skilla : FSMBase
{
	ChangeDelegate changeIdle;
	public Skilla(Animator tmpAnimal, ChangeDelegate tmpDlegate)
	{
		this.animator = tmpAnimal;
		changeIdle = tmpDlegate;
	}
	float timer = 0;
	bool isPlayFinish;
	public override void OnEnter()
	{
		this.animator.SetInteger("StateIndex", 6);
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
		if (timer > 0.28f && !isPlayFinish)
		{
			isPlayFinish = true;

			//do samething
		}
		if (timer > 1)
		{
			timer = 0;
			isPlayFinish = false;
			changeIdle((byte)AnimalStateSkill.Idle);
		}
	}
}
//技能3
public class Skill3 : FSMBase
{
	ChangeDelegate changeIdle;
	public Skill3(Animator tmpAnimal, ChangeDelegate tmpDlegate)
	{
		this.animator = tmpAnimal;
		changeIdle = tmpDlegate;
	}
	float timer = 0;
	bool isPlayFinish;
	public override void OnEnter()
	{
		this.animator.SetInteger("StateIndex", 7);
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
		if (timer > 0.28f && !isPlayFinish)
		{
			isPlayFinish = true;

			//do samething
		}
		if (timer > 3)
		{
			timer = 0;
			isPlayFinish = false;
			changeIdle((byte)AnimalStateSkill.Idle);
		}
	}
}



