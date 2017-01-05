using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class TimerCounter : MonoBehaviour {

	private float startTime = 0f;
	private float elapsedTime = 0f;
	private bool timeoutSceneLoaded = false;
	private DateTime timeSaved;
	private static TimerCounter timer;

	void Awake() 
	{
		DontDestroyOnLoad (transform.gameObject);
		if (timer == null) {
			timer = this;
		} else
			DestroyObject (gameObject);
	}

	// Use this for initialization
	void Start () {

		DateTime now = System.DateTime.Now;

		if (!System.IO.File.Exists(Application.persistentDataPath + "/time") && !System.IO.File.Exists(Application.persistentDataPath + "/elapsedTime"))
		{
			timeSaved = System.DateTime.Now;
			startTime = Time.time;
		} else 
		{
			timeSaved = FileManager.ReadFromBinaryFile<DateTime> (Application.persistentDataPath + "/time");
			elapsedTime = FileManager.ReadFromBinaryFile<float> (Application.persistentDataPath + "/elapsedTime");
			if (timeSaved.Day != now.Day || timeSaved.Month != now.Month || timeSaved.Year != now.Year) {
				startTime = Time.time;
				timeSaved = System.DateTime.Now;
			} 
			else
				startTime = Time.time - elapsedTime;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (SceneManager.GetActiveScene ().name.Equals ("Timeout"))
			timeoutSceneLoaded = true;
		else
			timeoutSceneLoaded = false;
		
		elapsedTime = Time.time - startTime;
		if (elapsedTime > 2 * 3600 && timeoutSceneLoaded == false) {
			SceneManager.LoadScene ("Timeout");
		}
	}

	void OnApplicationQuit()
	{
		DateTime date = System.DateTime.Now;
		FileManager.WriteToBinaryFile (Application.persistentDataPath + "/time", date);
		FileManager.WriteToBinaryFile (Application.persistentDataPath + "/elapsedTime", elapsedTime);
	}
}
