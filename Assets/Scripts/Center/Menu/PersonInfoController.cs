using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class PersonInfoController : UIBase {

	void Start()
	{
		//打开数据库
		SqliteManager.Instance.Open(Application.dataPath + "/user.db");
		AddButtonListen("CloseBtn_N", Close);
        AddButtonListen("ChangeNameBtn_N", NameSelect);
        SqliteDataReader reader = SqliteManager.Instance.ExecuteReader("select * from player where id='" + LoginController.nameField + "'");
		if (reader.Read())
		{
			string name = reader.GetString(1);
            GetChildGameObject("Name_L").GetComponent<Text>().text=name;
		}
		else
		{
			Main.ShowPromptBox("数据库读取错误");
		}
		reader.Close();
	}
    void NameSelect()
    {
        Main.ShowPromptBox("能量不足！！！");
    }
	void Close()
	{
		UIManager.Instance.UnRegistPanelGameObject("PersonInfo(Clone)");
		Destroy(gameObject);
	}
	void Update () {
		
	}
}
