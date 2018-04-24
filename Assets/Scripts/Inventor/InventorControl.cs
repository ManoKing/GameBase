using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class InventorControl : MonoBehaviour {
    public static InventorControl Instance;

    public InventorGridControl[] Grids;
    private void Awake()
    {
        Instance = this;
    }

    //得到一个空的格子
    public InventorGridControl GetEnmptyGrid()
    {
        foreach (InventorGridControl grid in Grids)
        {
            if (grid.IsEmpty())
            {
                return grid;
            }
        }
        return null;
    }
    //添加物品
    public bool AddItem(int itemId)
    {
        InventorGridControl grid = GetEnmptyGrid();
        if (grid==null)
        {
            return false;
        }
        grid.AddItem(itemId);
        return true;
    }
	////保存
	//public void Save()
	//{
	//    StringBuilder sb = new StringBuilder();
	//    for (int i = 0; i < Grids.Length; i++)
	//    {
	//        int id = Grids[i].IsEmpty() ? 0 : Grids[i].GetItem().ID;
	//        if (i<Grids.Length-1)
	//        {

	//            sb.Append(id+"|");
	//        }else
	//        {
	//            sb.Append(id);
	//        }
	//    }
	//    //写文件
	//    FileStream fs = new FileStream(Application.dataPath+"/save.txt",FileMode.Create);
	//    byte[] bytes = new UTF8Encoding().GetBytes(sb.ToString());
	//    fs.Read(bytes,0,bytes.Length);
	//    fs.Close();
	//}
	//保存
	public void Save()
	{
		//  1|2|1|3|0|0|0
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < Grids.Length; i++)
		{
			int id = Grids[i].IsEmpty() ? 0 : Grids[i].GetItem().ID;
			if (i < Grids.Length - 1)
			{
				sb.Append(id + "|");
			}
			else
			{
				sb.Append(id);
			}
		}

		//写文件
		FileStream fs = new FileStream(Application.dataPath + "/save.txt", FileMode.Create);
		byte[] bytes = new UTF8Encoding().GetBytes(sb.ToString());
		fs.Write(bytes, 0, bytes.Length);
		fs.Close();
	}


	//读取
	public void Load()
    {
		//读文件
		FileStream fs = new FileStream(Application.dataPath + "/save.txt", FileMode.Open);
		byte[] bytes = new byte[200];
		fs.Read(bytes, 0, bytes.Length);
		string s = new UTF8Encoding().GetString(bytes);

		string[] itemIds = s.Split('|');
		for (int i = 0; i < itemIds.Length; i++)
		{
			if (int.Parse(itemIds[i]) != 0)
			{
				Grids[i].AddItem(int.Parse(itemIds[i]));
			}
		}
	}
}
