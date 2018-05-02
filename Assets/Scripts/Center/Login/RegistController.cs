using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Mono.Data.Sqlite;
using System.Text.RegularExpressions;

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
        string pwdFilelds = GetChildGameObject("inp_affirmpassword_L").GetComponent<InputField>().text;
        string phoneFileld = GetChildGameObject("inp_phone_L").GetComponent<InputField>().text;
        if (nameField==""||pwdFileld==""||phoneFileld=="")
        {
            Main.ShowPromptBox("填写不能为空");
            return;
        }
		if (nameField.Length >=6)
		{
			Main.ShowPromptBox("账号名字过长");
			return;
		}
        if (pwdFileld.Length<3)
        {
            Main.ShowPromptBox("密码设置不符合规则");
            return;
        }
        if (pwdFileld!=pwdFilelds)
        {
			Main.ShowPromptBox("密码不一致");
			return;
        }
		Regex rx = new Regex(@"^[1][3-8]\d{9}$");
		if (!rx.IsMatch(phoneFileld)) //不匹配
		{
            Main.ShowPromptBox("手机号格式不对，请重新输入！");    //弹框提示
            return;
		}
        //判断账号是否存在
        object obj = SqliteManager.Instance.ExecuteScalar("select count(*)from user where name='" + nameField + "'");
		int num = Convert.ToInt32(obj);
		if (num > 0)
		{
            Main.ShowPromptBox("账号已存在");
			return;
		}
        SqliteManager.Instance.ExecuteNonQuery(string.Format("insert into user values('{0}','{1}','{2}')", nameField, pwdFileld,phoneFileld));
        Main.ShowPromptBox("账号已创建");
    }
}
