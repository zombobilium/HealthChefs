using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Settings : MonoBehaviour {

	public Button musicOn;
	public Button musicOff;
	public Button soundOn;
	public Button soundOff;
	public Text title;
	public Text som;
	public Text musica;

	// Use this for initialization
	void Start () {

		if (StaticLanguage.getLanguage ().Equals ("portuguese")) {
			title.text = "Definições";
			som.text = "Som";
			musica.text = "Música";
		} else {
			title.text = "Settings";
			som.text = "Sound";
			musica.text = "Music";
		}
	
		if (StaticSettings.getMusicOn () == true) 
		{
			musicOn.gameObject.SetActive (true);
			musicOff.gameObject.SetActive (false);
		} 
		else 
		{
			musicOn.gameObject.SetActive (false);
			musicOff.gameObject.SetActive (true);
		}

		if (StaticSettings.getSoundOn () == true) 
		{
			soundOn.gameObject.SetActive (true);
			soundOff.gameObject.SetActive (false);
		} 
		else 
		{
			soundOn.gameObject.SetActive (false);
			soundOff.gameObject.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeMusic()
	{
		if (StaticSettings.getMusicOn() == true) {
			StaticSettings.setMusicOn (false);
			musicOn.gameObject.SetActive (false);
			musicOff.gameObject.SetActive (true);
		} else {
			StaticSettings.setMusicOn (true);
			musicOn.gameObject.SetActive (true);
			musicOff.gameObject.SetActive (false);
		}
	}

	public void changeSound()
	{
		if (StaticSettings.getSoundOn() == true) {
			StaticSettings.setSoundOn (false);
			soundOn.gameObject.SetActive (false);
			soundOff.gameObject.SetActive (true);
		} else {
			StaticSettings.setSoundOn (true);
			soundOn.gameObject.SetActive (true);
			soundOff.gameObject.SetActive (false);
		}
	}
}
