using UnityEngine;
using System.Collections;

public class StaticSettings {

	private static bool musicOn = true;
	private static bool soundOn = true;

	public static bool getMusicOn()
	{
		return musicOn;
	}

	public static void setMusicOn(bool value)
	{
		musicOn = value;
	}

	public static bool getSoundOn()
	{
		return soundOn;
	}

	public static void setSoundOn(bool value)
	{
		soundOn = value;
	}
}
