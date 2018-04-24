using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ShopGridControl : GridBase,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //点击把物品添加到背包
        if (IsEmpty()==false)
        {
            InventorControl.Instance.AddItem(GetItem().ID);
        }
    }


}
