using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public static class StaticSceneManager
{
	private static string image;

	public static void LoadScene(string sceneName, string imageToLoad)
	{
		image = imageToLoad;
		SceneManager.LoadScene(sceneName);
	}

	public static string GetSceneImage()
	{
		return image;
	}

	public static void setImage(string img)
	{
		image = img;
	}
}
