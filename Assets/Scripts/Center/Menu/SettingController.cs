using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingController : UIBase {


	void Start () {
        GetChildGameObject("but_closeaudio_N").SetActive(false);
        AddButtonListen("but_close_N",Close);
        AddButtonListen("but_openaudio_N", OpenAudio);
        AddButtonListen("but_closeaudio_N", CloseAudio);
        AddButtonListen("but_ contact_N",WeChat);
        if (!Main.audioManager.activeSelf)
        {
            OpenAudio();
        }
    }
    void WeChat()
    {
        Application.OpenURL("https://github.com/explore");
    }
    void CloseAudio()
    {
        GetChildGameObject("but_closeaudio_N").SetActive(false);
        GetChildGameObject("but_openaudio_N").SetActive(true);
        Main.audioManager.SetActive(true);
    }
    void OpenAudio()
    {
        GetChildGameObject("but_closeaudio_N").SetActive(true);
        GetChildGameObject("but_openaudio_N").SetActive(false);
        Main.audioManager.SetActive(false);

	}
	void Close()
    {
		UIManager.Instance.UnRegistPanelGameObject("Setting(Clone)");
		Destroy(gameObject);
    }
    void Update () {
		
	}
}
