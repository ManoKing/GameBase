using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GridBase : MonoBehaviour ,IPointerExitHandler,IPointerEnterHandler{
    protected bool isRight = true;
    public GameObject ItemPre;
    //判断当前是否为空
    public bool IsEmpty()
    {
        if (transform.childCount==0)
        {
            return true;
        }
        return false;
    }
    //添加物品
    public bool AddItem(int itemId)
    {
        if (IsEmpty()==false)
        {
            return false;
        }
        Item item= Instantiate(ItemPre,transform).GetComponent<Item>();
        item.ID = itemId;
        return true;
    }
    //移除物体
    public void RemoveItem()
    {
        if (IsEmpty()==false)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    //取出物体
    public Item GetItem()
    {
        if (IsEmpty())
        {
            return null;
        }
        return transform.GetChild(0).GetComponent<Item>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsEmpty())
        {
            return;
        }
        TipManager.Instance.Show(GetItem().ID,isRight);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TipManager.Instance.Hide();
    }
}
