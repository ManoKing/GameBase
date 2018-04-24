using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialog
{
	public string Name;
	public string Content;
	public Dialog(string name, string content)
	{
		Name = name;
		Content = content;
	}
}
public class DralogManege : MonoBehaviour
{
	public static DralogManege Instance;
	public Text NameText;
	public Text ContentText;
	private int index = 0;
	private Dialog[] dialogs;
	void Awake()
	{
		Instance = this;
		gameObject.SetActive(false);
	}
	//是否正在对话
	public bool IsShow()
	{
		if (gameObject.activeSelf)
		{
			return true;
		}
		return false;
	}
	//显示对话
	public void Show(params Dialog[] dialogs)
	{

		gameObject.SetActive(true);
		//重置
		this.dialogs = dialogs;
		index = 0;
		Next();
	}
	//下一条对话
	public void Next()
	{
		if (index < dialogs.Length)
		{
			Dialog dialog = dialogs[index++];
			NameText.text = dialog.Name;
			ContentText.text = dialog.Content;
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Next();
		}
	}
}