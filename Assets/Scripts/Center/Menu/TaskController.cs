using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : UIBase {
	void Start()
	{
		AddButtonListen("Close_N", Close);
	}
	void Close()
	{
		UIManager.Instance.UnRegistPanelGameObject("Task(Clone)");
		Destroy(gameObject);
	}
}
