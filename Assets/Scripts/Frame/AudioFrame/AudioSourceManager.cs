using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager 
{


    List<AudioSource> allSources;


    GameObject ower;

    public AudioSourceManager(GameObject tmpOwer)
    {

        ower = tmpOwer;

        Initial();


    }


    public void Initial()
    {


        allSources = new List<AudioSource>();

        for (int i = 0; i < 1; i++)
        {

          AudioSource  tmpSources=   ower.AddComponent<AudioSource>();

          allSources.Add(tmpSources);
            
        }

    }

    public void StopPlayingAudio(string clipName)
    {

        for (int i = 0; i < allSources.Count; i++)
        {

            if (allSources[i].isPlaying)
            {
                if (allSources[i].clip.name.Equals(clipName))
                {
                    allSources[i].Stop();
                }
            }
            
        }
          

    }



    public AudioSource GetFreeAudioSource()
    {

        for (int i = 0; i < allSources.Count; i++)
        {

            if (!allSources[i].isPlaying)

                return allSources[i];
            
        }


        AudioSource tmpSources = ower.AddComponent<AudioSource>();

        allSources.Add(tmpSources);

        return tmpSources;
    }


    public void FreeAudioSource2()
    {

        int tmpCount=0;
        for (int i = 0; i < allSources.Count; i++)
        {

            AudioSource tmpSournce = allSources[i];

            if (!tmpSournce.isPlaying)
            {
                tmpCount++;

                if (tmpCount > 1)
                {

                    allSources.Remove(tmpSournce);
                }

            }
        }
    }
    public void FreeAudioSource()
    {

        List<AudioSource> indexList = new List<AudioSource>();

  

        for (int i = 0; i < allSources.Count; i++)
        {

            if (!allSources[i].isPlaying)
            {

                indexList.Add(allSources[i]);

            }
            
        }

        if (indexList.Count > 1)
        {

            for (int i = 1; i < indexList.Count; i++)
            {

                allSources.Remove(indexList[i]);
                
            }

        }

        indexList.Clear();

       
    }



}
