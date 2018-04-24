using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIController : UIBase {

	void Start () {
        AddButtonListen("img_head_N",InfoPerson);
	}
	void InfoPerson()
    {
		GameObject obj = Resources.Load<GameObject>("Test/PersonInfo");
		Instantiate(obj, transform.parent);
    }
	void Update () {
		
	}
}
