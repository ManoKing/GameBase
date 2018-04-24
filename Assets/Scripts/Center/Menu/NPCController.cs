using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCController : MonoBehaviour
{
	private bool isTrigger = false;
	void Start()
	{

	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) &&
			isTrigger == true
			&& DralogManege.Instance.IsShow() == false)
		{

			DralogManege.Instance.Show(
			new Dialog("NPC", "这里是哪里"),
			new Dialog("玩家", "这里是战场。。。你怎么还没逃走？"),
			new Dialog("NPC", "能不能带我走啊？"),
			new Dialog("玩家", "不能"),
				new Dialog("NPC", "......")
			);
		}

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			isTrigger = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			isTrigger = false;
		}
	}
}