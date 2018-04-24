using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingController : UIBase {

	void Start () {
        AddButtonListen("but_close_N",Close);
	}
	void Close()
    {
		UIManager.Instance.UnRegistPanelGameObject("Setting(Clone)");
		Destroy(gameObject);
    }
    void Update () {
		
	}
}
