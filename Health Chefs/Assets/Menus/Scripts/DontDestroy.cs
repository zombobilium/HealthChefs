using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	private static DontDestroy dontDestroy;

	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
		if (dontDestroy == null) {
			dontDestroy = this;
		} else
			DestroyObject (gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (StaticSettings.getMusicOn () == true)
			transform.GetComponent<AudioSource> ().mute = false;
		else
			transform.GetComponent<AudioSource> ().mute = true;
	}
}
