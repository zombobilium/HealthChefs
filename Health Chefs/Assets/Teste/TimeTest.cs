using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimeTest : MonoBehaviour {

	public Text text;
	private DateTime date;
	public Text message;

	// Use this for initialization
	void Start () {
		if (StaticLanguage.getLanguage ().Equals ("portuguese"))
			message.text = "Já jogaste muito hoje!\nAmanhã espera-te mais diversão!";
		else
			message.text = "You have played for too long!\nTomorrow you can have some more fun!";

		DateTime nextDay = new DateTime (System.DateTime.Now.AddDays (1).Year,
			                   System.DateTime.Now.AddDays (1).Month,
			                   System.DateTime.Now.AddDays (1).Day, 0, 0, 0);

		TimeSpan counter = nextDay - System.DateTime.Now;
		text.text = string.Format ("{0:D2}:{1:D2}:{2:D2}", counter.Hours, counter.Minutes, counter.Seconds);
	}
	
	// Update is called once per frame
	void Update () {
		DateTime nextDay = new DateTime (System.DateTime.Now.AddDays (1).Year,
			System.DateTime.Now.AddDays (1).Month,
			System.DateTime.Now.AddDays (1).Day, 0, 0, 0);
		
		TimeSpan counter = nextDay - System.DateTime.Now;
		text.text = string.Format ("{0:D2}:{1:D2}:{2:D2}", counter.Hours, counter.Minutes, counter.Seconds);
	}
}
