using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AsyncOperationManager : MonoBehaviour
{
    Slider slider;
	private AsyncOperation opera;//异步操作类
    bool isShow;
	void Start()
	{

	}
	void Update()
	{
		if (opera != null)
		{
			//加载中,刷新进度
			slider.value = opera.progress;//异步的进度0到1
		}
        if (Vector3.Distance(transform.position,GameObject.FindWithTag("Player").transform.position)<30f&&!isShow)
        {
            isShow = true;
            StartCoroutine(Starts());  
        }
    }
    public void Quit()
	{
		Application.Quit();
	}
    IEnumerator Starts()
	{
		//加载场景
		//SceneManager.LoadScene(1);
		//transform.GetChild(1).gameObject.SetActive(false);
		GameObject obj = Resources.Load<GameObject>("Test/Loading");
		GameObject tmep=Instantiate(obj, transform.parent);
        slider = tmep.transform.GetChild(3).GetComponent<Slider>();
        yield return new WaitForSeconds(5f); 
		opera = SceneManager.LoadSceneAsync(1);
	}
}

