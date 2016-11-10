using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void loadScene(string scene)
	{
		SceneManager.LoadScene (scene);
	}
}
