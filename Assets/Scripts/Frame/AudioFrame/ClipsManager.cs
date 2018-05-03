using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipsManager  {


    string[] clipName;


    SingleClip[] singleClips;


    public ClipsManager()
    {

        Initial();
    }

    public void Initial()
    {
        //  从 配置文件  读取  txt
        clipName = new string[] { "bg-city", "Bg-transcript", "bg-choice" , "ice_attack","bird","attack1","attack2","attack3","Skill","Hurt"};



        singleClips = new SingleClip[clipName.Length];

        for (int i = 0; i < clipName.Length; i++)
        {
            AudioClip tmpClip = Resources.Load<AudioClip>("Audio/" + clipName[i]);

            SingleClip tmpSingleClip = new SingleClip(tmpClip);

            singleClips[i] = tmpSingleClip;

        }
    }



    public SingleClip GetClips(string  audioName)
    {

        int findIndex = -1;

        for (int i = 0; i < clipName.Length; i++)
        {

            if (audioName.Equals(clipName[i]))
            {

                findIndex = i;

                break;
            }

            
        }


        if (findIndex != -1)
        {

            return singleClips[findIndex];

        }

        return null;


 
    }
	

}
