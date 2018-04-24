using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }


}
