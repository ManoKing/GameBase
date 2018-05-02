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
			new Dialog("村民", "剑圣你终于来了，我等了你好久，快点去救救村民门吧"),
			new Dialog("村民", "他们被万恶的恶人带入地穴，生命岌岌可危。"),
			new Dialog("村民", "你往前走，前面有一个山洞，他其实是个传送门，站到哪里，就可以去地穴了。"),
			new Dialog("村民", "你这里有一些物品，可能用的到，都给你吧"),
				new Dialog("村民", "你是全村的希望。。。")
			);
		}

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			isTrigger = true;
            Main.flog1 = 2;
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