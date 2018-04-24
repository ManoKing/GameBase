using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour {

	void Start () {
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        DontDestroyOnLoad(GameObject.Find("Player"));
        DontDestroyOnLoad(GameObject.Find("Audio"));
        DontDestroyOnLoad(GameObject.Find("Main Camera"));
        DontDestroyOnLoad(GameObject.Find("GameManger"));
        //播放声音
        AudioPlayer.Instance.Play("bg-city");
        //添加管理
        gameObject.AddComponent<SqliteManager>();
        gameObject.AddComponent<UIManager>();
        //gameObject.AddComponent<DralogManege>();
        GameObject obj = Resources.Load<GameObject>("Item/Login");
        Instantiate(obj, GameObject.FindWithTag("MainCanvas").transform);
	}
}
