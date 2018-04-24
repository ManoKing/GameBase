using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioPlayer.Instance.Play("betting");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            AudioPlayer.Instance.Play("UIMusic");
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            AudioPlayer.Instance.Stop("UIMusic");
        }


	}
}
