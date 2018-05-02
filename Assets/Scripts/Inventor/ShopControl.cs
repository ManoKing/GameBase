using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour {
    //销售商品
    public int[] Itemids;
    //格子
    public ShopGridControl[] Grids;

	void Start () {
        for (int i = 0; i < Itemids.Length; i++)
        {
            Grids[i].AddItem(Itemids[i]);
        }
        transform.Find("Sava_CLose").GetComponent<Button>().onClick.AddListener(Close);
        transform.Find("Sava").GetComponent<Button>().onClick.AddListener(InventorControl.Instance.Save);
    }

    void Close()
    {
        Destroy(gameObject);
    }
}
