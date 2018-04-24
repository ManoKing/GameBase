using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckPersonController : UIBase {

	void Start () {
		//打开数据库
		SqliteManager.Instance.Open(Application.dataPath + "/user.db");
		//创建表
		SqliteManager.Instance.ExecuteNonQuery("create table if not exists player(id,name)");

        AddButtonListen("NameButton_N", CreateName);
	}

    void CreateName()
    {
        string nameField = GetChildGameObject("InputName_N").GetComponent<InputField>().text;

        SqliteManager.Instance.ExecuteNonQuery(string.Format("insert into player values('{0}','{1}')",LoginController.nameField,nameField));
		
		UIManager.Instance.UnRegistPanelGameObject("CheckPerson(Clone)");
		Destroy(gameObject);
		GameObject obj = Resources.Load<GameObject>("MainUI/EasyTouth");
		Instantiate(obj, transform.parent);
		GameObject obj1 = Resources.Load<GameObject>("MainUI/MainUI");
		Instantiate(obj1, transform.parent);
		GameObject obj2 = Resources.Load<GameObject>("MainUI/Menu");
		Instantiate(obj2, transform.parent);
		GameObject obj3 = Resources.Load<GameObject>("MainUI/Skill");
		Instantiate(obj3, transform.parent);
    }
}
