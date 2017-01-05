using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimeTest : MonoBehaviour {

	public Text text;
	private DateTime date;

	// Use this for initialization
	void Start () {
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
