using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    private int id;
    public int ID
    {
        get
        {
            return id;
        }
        set{
            id = value;
            GetComponent<Image>().sprite=Resources.Load<Sprite>("item/"+ItemManager.Instance.ItemDic[id].Image);
        }
    }
}
