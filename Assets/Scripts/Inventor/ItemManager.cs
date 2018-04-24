using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class ItemMadel
{
    public int ID;
    public string Name;
    public string Image;
    public string Des;
}

public class ItemManager
{
    public Dictionary<int, ItemMadel> ItemDic;
    private static ItemManager instance;
    public static ItemManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ItemManager();
            }
            return instance;
        }
    }

    private ItemManager()
    {
        ItemDic = new Dictionary<int, ItemMadel>();
        TextAsset ta = Resources.Load<TextAsset>("item");
        string json = ta.text;
        JsonData jd = JsonMapper.ToObject(json);
        foreach (JsonData itemJd in jd)
        {
            ItemMadel im = new ItemMadel();
            im.ID = (int)itemJd["id"];
            im.Name = itemJd["name"].ToString();
            im.Image = itemJd["image"].ToString();
            im.Des = itemJd["des"].ToString();
            ItemDic.Add(im.ID, im);
        }
    }
}