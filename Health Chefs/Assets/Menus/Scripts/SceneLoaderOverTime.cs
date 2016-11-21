using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoaderOverTime : MonoBehaviour {

	void Start()
	{
		StartCoroutine (loadScene ());
	}

	IEnumerator loadScene()
	{
		yield return new WaitForSeconds(02);

		float fadeTime = GameObject.Find("Script").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("Menu");
	}
}
