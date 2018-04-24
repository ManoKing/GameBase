using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventorGridControl : GridBase, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private void Start()
    {
        isRight = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsEmpty())
        {
            return;
        }
        //保存拖拽物体
        eventData.selectedObject = GetItem().gameObject;
        //更改父物体
        eventData.selectedObject.transform.SetParent(transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        eventData.selectedObject.GetComponent<RectTransform>().position=Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter!=null&&eventData.pointerEnter.tag=="Grid")
        {
            InventorGridControl oldGrid = eventData.pointerDrag.GetComponent<InventorGridControl>();
            InventorGridControl newGrid = eventData.pointerEnter.GetComponent<InventorGridControl>();
            if (newGrid.IsEmpty())
            {
                //直接放
                eventData.selectedObject.transform.SetParent(newGrid.transform);
                eventData.selectedObject.GetComponent<RectTransform>().localPosition=Vector2.zero;


            }else
            {
                //交换
                newGrid.GetItem().transform.SetParent(oldGrid.transform);
                oldGrid.GetItem().GetComponent<RectTransform>().localPosition = Vector2.zero;
				eventData.selectedObject.transform.SetParent(newGrid.transform);
				eventData.selectedObject.GetComponent<RectTransform>().localPosition = Vector2.zero;
            }
        }
		else
		{
            //恢复原位
            eventData.selectedObject.transform.SetParent(eventData.pointerDrag.transform);
            eventData.selectedObject.GetComponent<RectTransform>().localPosition=Vector2.zero;
		}
    }
}
