using UnityEngine;
using System.Collections;

public class CheckSounds : MonoBehaviour {

	public AudioSource audio;
	
	// Update is called once per frame
	void Update () {
		if (StaticSettings.getSoundOn () == true)
			audio.mute = false;
		else
			audio.mute = true;
	}
}
