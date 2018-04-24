using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : UIBase {

	void Start () {
        AddButtonListen("img_system_N",SystemStting);
        AddButtonListen("img_skill_N", Shop);
        AddButtonListen("SkillAdd_N", Inventor);
        AddButtonListen("img_task_N", Task);
	}
    void Inventor()
    {
		GameObject obj = Resources.Load<GameObject>("ShopInventory/InventoryBg");
		Instantiate(obj, transform.parent);
    }
    void Shop()
    {
		GameObject obj = Resources.Load<GameObject>("ShopInventory/ShopBg");
		Instantiate(obj, transform.parent);
    }
    void Task()
    {
		GameObject obj = Resources.Load<GameObject>("Test/Task");
		Instantiate(obj, transform.parent);
    }
	void SystemStting()
    {
		GameObject obj = Resources.Load<GameObject>("Test/Setting");
        Instantiate(obj, transform.parent);
    }
	void Update () {
		
	}
}
