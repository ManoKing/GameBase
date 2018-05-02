using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Main : MonoBehaviour {
    public static GameObject audioManager;
    public static int flog;
    public static int flog1;
    public static int flog2;
	void Start () {
        TipManager.Instance.Hide();
        flog = 0;
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        DontDestroyOnLoad(GameObject.Find("Player"));
        DontDestroyOnLoad(GameObject.Find("Audio"));
        DontDestroyOnLoad(GameObject.Find("Main Camera"));
        DontDestroyOnLoad(GameObject.Find("GameManger"));
        //播放声音
        AudioPlayer.Instance.Play("bg-city");
        audioManager = GameObject.Find("Audio");
        audioManager.GetComponent<AudioSource>().loop = true;
        //添加管理
        gameObject.AddComponent<SqliteManager>();
        gameObject.AddComponent<UIManager>();
        //gameObject.AddComponent<DralogManege>();
        GameObject obj = Resources.Load<GameObject>("Item/Login");
        Instantiate(obj, GameObject.FindWithTag("MainCanvas").transform);
	}
    public static void ShowPromptBox(string show)
    {
        GameObject obj = Resources.Load<GameObject>("Test/ShowBox");
        GameObject prompt = Instantiate(obj, GameObject.FindWithTag("MainCanvas").transform);
        prompt.transform.GetChild(1).GetComponent<Text>().text=show;
    }
}
