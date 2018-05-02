using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : UIBase {
	void Start()
	{
		GetChildGameObject("TaskLayers_L").transform.GetChild(1).gameObject.SetActive(false);
		GetChildGameObject("TaskLayers_L").transform.GetChild(2).gameObject.SetActive(false);
		AddButtonListen("Close_N", Close);
        AddButtonListen("StateBtn_N",Tset);
        if (Main.flog==0)
        {
            GetChildGameObject("StateBtn_N").transform.GetChild(0).GetComponent<Text>().text = "接受任务";
        }
        else if (Main.flog == 1)
        {
            GetChildGameObject("StateBtn_N").transform.GetChild(0).GetComponent<Text>().text = "已接受";
        }
        else if (Main.flog == 2)
        {
            GetChildGameObject("StateBtn_N").transform.GetChild(0).GetComponent<Text>().text = "领取奖励";
            GetChildGameObject("TaskLayers_L").transform.GetChild(1).gameObject.SetActive(true);

        }
		else if (Main.flog == 3)
		{
            GetChildGameObject("StateBtn_N").transform.GetChild(0).GetComponent<Text>().text = "已完成";
            GetChildGameObject("TaskLayers_L").transform.GetChild(1).gameObject.SetActive(true);


		}
        //TODO
        AddButtonListen("StateBtn1_N", Tset1);
		if (Main.flog1 == 0)
		{
			GetChildGameObject("StateBtn1_N").transform.GetChild(0).GetComponent<Text>().text = "接受任务";
		}
		else if (Main.flog1 == 1)
		{
			GetChildGameObject("StateBtn1_N").transform.GetChild(0).GetComponent<Text>().text = "已接受";
		}
		else if (Main.flog1 == 2)
		{
			GetChildGameObject("StateBtn1_N").transform.GetChild(0).GetComponent<Text>().text = "领取奖励";
			GetChildGameObject("TaskLayers_L").transform.GetChild(2).gameObject.SetActive(true);
		}
		else if (Main.flog == 3)
		{
			GetChildGameObject("StateBtn1_N").transform.GetChild(0).GetComponent<Text>().text = "已完成";
			GetChildGameObject("TaskLayers_L").transform.GetChild(2).gameObject.SetActive(true);

		}
        //TODO
        AddButtonListen("StateBtn2_N", Tset2);
		if (Main.flog2 == 0)
		{
			GetChildGameObject("StateBtn2_N").transform.GetChild(0).GetComponent<Text>().text = "接受任务";
		}
		else if (Main.flog2 == 1)
		{
			GetChildGameObject("StateBtn2_N").transform.GetChild(0).GetComponent<Text>().text = "已接受";
		}
		else if (Main.flog2 == 2)
		{
			GetChildGameObject("StateBtn2_N").transform.GetChild(0).GetComponent<Text>().text = "领取奖励";
		}
		else if (Main.flog2 == 3)
		{
			GetChildGameObject("StateBtn2_N").transform.GetChild(0).GetComponent<Text>().text = "已完成";

		}

    }
	void Tset2()
	{
		if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text == "领取奖励")
		{
			Main.flog2 = 3;
			GetChildGameObject("StateBtn2_N").transform.GetChild(0).GetComponent<Text>().text = "已完成";
			GameObject.Find("MainUI(Clone)").transform.Find("img_coinBck").GetChild(0).GetComponent<Text>().text = "5000";
		}
		else if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text == "接受任务")
		{
			Main.flog2 = 1;
			GetChildGameObject("StateBtn2_N").transform.GetChild(0).GetComponent<Text>().text = "已接受";
		}

	}
	void Tset1()
	{
		if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text == "领取奖励")
		{
			Main.flog1= 3;
			GetChildGameObject("StateBtn1_N").transform.GetChild(0).GetComponent<Text>().text = "已完成";
			GameObject.Find("MainUI(Clone)").transform.Find("img_coinBck").GetChild(0).GetComponent<Text>().text = "10000";
		}
		else if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text == "接受任务")
		{
			Main.flog1 = 1;
			GetChildGameObject("StateBtn1_N").transform.GetChild(0).GetComponent<Text>().text = "已接受";
		}

	}
    void Tset()
    {
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text=="领取奖励")
        {
			Main.flog = 3;
			GetChildGameObject("StateBtn_N").transform.GetChild(0).GetComponent<Text>().text = "已完成";
            GameObject.Find("MainUI(Clone)").transform.Find("img_coinBck").GetChild(0).GetComponent<Text>().text="5000";
        }
        else if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text == "接受任务")
        {
			Main.flog = 1;
			GetChildGameObject("StateBtn_N").transform.GetChild(0).GetComponent<Text>().text = "已接受";
        }

    }
	void Close()
	{
		UIManager.Instance.UnRegistPanelGameObject("Task(Clone)");
		Destroy(gameObject);
	}
}
