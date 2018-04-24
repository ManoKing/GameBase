﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Mono.Data.Sqlite;
public class LoginController : UIBase {
    public static string nameField;
	void Start () {
		
        AddButtonListen("btn_sign_N",Regist);
        AddButtonListen("btn_log_N", Login);

		//打开数据库
		SqliteManager.Instance.Open(Application.dataPath + "/user.db");
	}
	void Regist()
    {
		UIManager.Instance.UnRegistPanelGameObject("Login(Clone)");
		Destroy(gameObject);
		GameObject obj = Resources.Load<GameObject>("Item/Register");
        Instantiate(obj, transform.parent);
    }
	public void Login()
	{
	    nameField = GetChildGameObject("inp_act_N").GetComponent<InputField>().text;
		string pwdFileld = GetChildGameObject("inp_psw_N").GetComponent<InputField>().text;
		SqliteDataReader reader = SqliteManager.Instance.ExecuteReader("select * from user where name='" + nameField + "'");
		if (reader.Read())
		{
			string password = reader.GetString(1);
			if (password == pwdFileld)
			{
				Debug.Log("登录成功");
                //登录成功
				UIManager.Instance.UnRegistPanelGameObject("Login(Clone)");
				Destroy(gameObject);
				GameObject obj = Resources.Load<GameObject>("Item/CheckPerson");
				Instantiate(obj, transform.parent);
			}
			else
			{
				Debug.Log("密码错误");
			}
		}
		else
		{
			Debug.Log("账号不存在");
		}
		reader.Close();
	}
}
