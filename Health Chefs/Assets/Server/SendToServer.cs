using UnityEngine;
using System.Collections;

[System.Serializable]
public class SendToServer {

	//User
	private float id = -1f;

	//Minigame1
	private float Minigame1HighScore = 0f;
	private float Minigame1TimesPlayed = 0f;

	//Mingame2
	private float Minigame2HighScore = 0f;
	private float Minigame2TimesPlayed = 0f;

	//Minigame3
	private float Minigame3HighScore = 0f;
	private float Minigame3TimesPlayed = 0f;

	//Minigame4
	private float Minigame4HighScore = 0f;
	private float Minigame4TimesPlayed = 0f;


	public float Id {
		get 
		{
			return id;
		}
		set 
		{
			id = value;
		}
	}

	public float minigame1Highscore {
		get {
			return Minigame1HighScore;
		}
		set {
			Minigame1HighScore = value;
		}
	}

	public float minigame1TimesPlayed {
		get {
			return Minigame1TimesPlayed;
		}
		set {
			Minigame1TimesPlayed = value;
		}
	}

	public float minigame2Highscore {
		get {
			return Minigame2HighScore;
		}
		set {
			Minigame2HighScore = value;
		}
	}

	public float minigame2TimesPlayed {
		get {
			return Minigame2TimesPlayed;
		}
		set {
			Minigame2TimesPlayed = value;
		}
	}

	public float minigame3Highscore {
		get {
			return Minigame3HighScore;
		}
		set {
			Minigame3HighScore = value;
		}
	}

	public float minigame3TimesPlayed {
		get {
			return Minigame3TimesPlayed;
		}
		set {
			Minigame3TimesPlayed = value;
		}
	}

	public float minigame4Highscore {
		get {
			return Minigame4HighScore;
		}
		set {
			Minigame4HighScore = value;
		}
	}

	public float minigame4TimesPlayed {
		get {
			return Minigame4TimesPlayed;
		}
		set {
			Minigame4TimesPlayed = value;
		}
	}
}
