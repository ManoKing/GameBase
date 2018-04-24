using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
public class SqliteManager : MonoBehaviour
{
	public static SqliteManager Instance;
	private SqliteConnection con;
	private SqliteCommand command;
	private SqliteDataReader reader;
	void Awake()
	{
		Instance = this;
	}
	//打开方法
	public void Open(string fileName)
	{
		con = new SqliteConnection("data source=" + fileName);
        con.Open();
	}
	//关闭
	public void Close()
	{
		con.Close();
	}
	//执行
	public int ExecuteNonQuery(string cmd)
	{
		command = new SqliteCommand(cmd, con);
		int num = command.ExecuteNonQuery();
		command.Dispose();
		return num;
	}
	//单行查询
	public object ExecuteScalar(string cmd)
	{
		command = new SqliteCommand(cmd, con);
		object obj = command.ExecuteScalar();
		command.Dispose();
		return obj;
	}
	//查询
	public SqliteDataReader ExecuteReader(string cmd)
	{
		command = new SqliteCommand(cmd, con);
		reader = command.ExecuteReader();
		command.Dispose();
		return reader;
	}
}