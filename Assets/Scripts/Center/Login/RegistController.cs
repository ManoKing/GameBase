using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Mono.Data.Sqlite;
public class RegistController : UIBase {

	void Start () {
        AddButtonListen("but_close_N", Close);
        AddButtonListen("but_shut_N", Close);
        AddButtonListen("but_register_N", Reg);
		//打开数据库
		SqliteManager.Instance.Open(Application.dataPath + "/user.db");
		//创建表
		SqliteManager.Instance.ExecuteNonQuery("create table if not exists user(name,password,phone)");
	}
	void Close()
    {
		GameObject obj = Resources.Load<GameObject>("Item/Login");
        Instantiate(obj, transform.parent);
		UIManager.Instance.UnRegistPanelGameObject("Register(Clone)");
		Destroy(gameObject);
    }
	public void Reg()
	{
        string nameField = GetChildGameObject("inp_name_L").GetComponent<InputField>().text;
        string pwdFileld = GetChildGameObject("inp_password_L").GetComponent<InputField>().text;
        string phoneFileld = GetChildGameObject("inp_phone_L").GetComponent<InputField>().text;
		//判断账号是否存在
		object obj = SqliteManager.Instance.ExecuteScalar("select count(*)from user where name='" + nameField + "'");
		int num = Convert.ToInt32(obj);
		if (num > 0)
		{
			Debug.Log("账号已存在");
			return;
		}
        SqliteManager.Instance.ExecuteNonQuery(string.Format("insert into user values('{0}','{1}','{2}')", nameField, pwdFileld,phoneFileld));
		Debug.Log("账号已创建");
	}
}
