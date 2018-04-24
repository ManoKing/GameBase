using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TipManager : MonoBehaviour {
    public static TipManager Instance;
    public Text NameText;
    public Text DesText;
	void Awake () {
        Instance = this;
	}
	
	void Update () {
        if (gameObject.activeSelf)
        {
            GetComponent<RectTransform>().position=Input.mousePosition;

        }
    }
    //显示
    public void Show(int itemId,bool isRight=true)
    {
        if (isRight)
        {
            GetComponent<RectTransform>().pivot=new Vector2(-0.1f, 1.1f);
        
        }
		else
		{
//            Debug.Log("Yes");
			//GetComponent<RectTransform>().position = new Vector2(1.1f, 1.1f);
            GetComponent<RectTransform>().pivot = new Vector2(1.1f, 1.1f);
		}
        gameObject.SetActive(true);
        NameText.text = ItemManager.Instance.ItemDic[itemId].Name;
        DesText.text = ItemManager.Instance.ItemDic[itemId].Des;
    }
    //隐藏
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
