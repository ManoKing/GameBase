using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonInfoController : UIBase {

	void Start()
	{
		AddButtonListen("CloseBtn_N", Close);
	}
	void Close()
	{
		UIManager.Instance.UnRegistPanelGameObject("PersonInfo(Clone)");
		Destroy(gameObject);
	}
	void Update () {
		
	}
}
