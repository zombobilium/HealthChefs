using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UnitTestsMinigame3 : MonoBehaviour {

	public GameObject testContainer;
	public Minigame3Controller game;
	public Button choice1;
	public Button choice2;
	public UnityEngine.UI.Text time;
	public UnityEngine.UI.Text score;
	public float roundTime;
	public Image right1, wrong1, right2, wrong2;

	[SetUp]
	public void SetUp()
	{
		testContainer = new GameObject ();

		GameObject go = new GameObject ();
		Button button = go.AddComponent<Button> ();
		button.gameObject.AddComponent<Image> ();
		choice1 = Instantiate (button);
		choice2 = Instantiate (button);

		go = new GameObject ();
		Image image = go.AddComponent<Image> ();
		right1 = Instantiate (image);
		wrong1 = Instantiate (image);
		right2 = Instantiate (image);
		wrong2 = Instantiate (image);

		right1.transform.SetParent (choice1.transform);
		wrong1.transform.SetParent (choice1.transform);
		right2.transform.SetParent (choice2.transform);
		wrong2.transform.SetParent (choice2.transform);


		UnityEngine.UI.Text text = testContainer.AddComponent<UnityEngine.UI.Text> ();
		time = Instantiate (text);
		score = Instantiate (text);

		testContainer.AddComponent<Minigame3Controller> ();
		game = testContainer.GetComponent<Minigame3Controller> ();

		game.choice1 = choice1;
		game.choice2 = choice2;
		game.time = time;
		game.score = score;
		game.roundTime = 30;
	}

	[Test]
	public void testGameEnd()
	{
		game.roundTime = 0;
		game.Start ();
		game.Update ();
		Assert.That (game.choice1.interactable == false); 
		Assert.That (game.choice2.interactable == false); 
	}

	[Test]
	public void testHealthyUnhealthyExist()
	{
		game.Start ();
		if (game.choice1.GetComponent<Image> ().sprite.name.Contains ("_0")) {
			Assert.That (game.choice1.GetComponent<Image> ().sprite.name.Contains ("_0"));
			Assert.That (game.choice2.GetComponent<Image> ().sprite.name.Contains ("_1"));
		} else {
			Assert.That (game.choice2.GetComponent<Image> ().sprite.name.Contains ("_0"));
			Assert.That (game.choice1.GetComponent<Image> ().sprite.name.Contains ("_1"));
		}
	}

	[Test]
	public void testHealthyGivesPoints()
	{
		game.Start ();
		if (game.choice1.GetComponent<Image> ().sprite.name.Contains ("_0")) {
			game.taskOnClick (choice1);
			Assert.That (game.getScoreNumber () == 1);
		} else {
			game.taskOnClick (choice2);
			Assert.That (game.getScoreNumber () == 1);
		}
	}

	[Test]
	public void testUnhealthyDoesNotGivePoints()
	{
		game.Start ();
		if (game.choice1.GetComponent<Image> ().sprite.name.Contains ("_1")) {
			game.taskOnClick (choice1);
			Assert.That (game.getScoreNumber () == 0);
		} else {
			game.taskOnClick (choice2);
			Assert.That (game.getScoreNumber () == 0);
		}
	}
}
