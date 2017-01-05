using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UnitTestsMinigame1 : MonoBehaviour {

	public GameObject picture;
	public GameObject testContainer;
	public GameController game;
	public Button[] ButtonList;
	public GameObject check;
	public GameObject wrong;

	public GameObject lives;
	public UnityEngine.UI.Text text;

	[SetUp]
	public void SetUp()
	{
		testContainer = new GameObject ();
		text = testContainer.AddComponent<UnityEngine.UI.Text> ();
		picture = new GameObject ();
		lives = new GameObject ();
		check = new GameObject ();
		wrong = new GameObject ();
		ButtonList = new Button[15];


		Button button = testContainer.AddComponent<Button> ();

		for (int i = 0; i < 15; i++) { 
			ButtonList [i] = Instantiate(button);
		}
		picture.AddComponent<Image> ();

		GameObject go = new GameObject ();
		Image life = go.AddComponent<Image> ();
		Image life1 = Instantiate (life);
		Image life2 = Instantiate (life);
		Image life3 = Instantiate (life);
		life1.transform.SetParent (lives.transform);
		life2.transform.SetParent (lives.transform);
		life3.transform.SetParent (lives.transform);


		testContainer.AddComponent<GameController> ();
		game = testContainer.GetComponent<GameController> ();

		game.picture = picture;
		game.buttonList = ButtonList;
		game.text = text;

		game.check = check;
		game.wrong = wrong;
		game.lives = lives;
	}

	[Test]
	public void checkImageName()
	{
		StaticSceneManager.setImage ("cenoura_carrot");
		StaticLanguage.setLanguage ("portuguese");
		game.Start();
		Assert.That ("CENOURA" == game.solution);
	}

	[Test]
	public void checkLetterInsertionMiddleOfWord()
	{
		StaticSceneManager.setImage ("cenoura_carrot");
		StaticLanguage.setLanguage ("portuguese");
		game.Start();
		GameObject go = new GameObject ();
		Button button = go.AddComponent<Button> ();
		for (int i = 0; i < 15; i++) {
			if (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text == "E")
				button = ButtonList [i];
		}

		game.taskOnClick (button, game.solution);

		Assert.That (game.text.text [3].ToString () == "E"); 
	}

	[Test]
	public void checkLetterInsertionBegginingOfWord()
	{
		StaticSceneManager.setImage ("cenoura_carrot");
		StaticLanguage.setLanguage ("portuguese");
		game.Start();
		GameObject go = new GameObject ();
		Button button = go.AddComponent<Button> ();
		for (int i = 0; i < 15; i++) {
			if (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text == "C")
				button = ButtonList [i];
		}

		game.taskOnClick (button, game.solution);

		Assert.That (game.text.text [1].ToString () == "C"); 
	}

	[Test]
	public void checkError()
	{
		StaticSceneManager.setImage ("cenoura_carrot");
		StaticLanguage.setLanguage ("portuguese");
		game.Start();
		GameObject go = new GameObject ();
		Button button = go.AddComponent<Button> ();

		for (int i = 0; i < 15; i++) {
			if ((ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text != "C") 
				&& (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text != "E")
				&& (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text != "N")
				&& (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text != "O")
				&& (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text != "U")
				&& (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text != "R")
				&& (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text != "A"))
				button = ButtonList [i];
		}

		game.taskOnClick (button, game.solution);
		game.Update ();
		game.taskOnClick (button, game.solution);
		game.Update ();
		game.taskOnClick (button, game.solution);
		game.Update ();

		Assert.That (game.wrong.activeSelf == true); 
	}

	[Test]
	public void checkWin()
	{
		StaticSceneManager.setImage ("cenoura_carrot");
		StaticLanguage.setLanguage ("portuguese");
		game.Start();
		GameObject go = new GameObject ();
		Button button = go.AddComponent<Button> ();
		Button button1 = Instantiate (button);
		Button button2 = Instantiate (button);
		Button button3 = Instantiate (button);
		Button button4 = Instantiate (button);
		Button button5 = Instantiate (button);
		Button button6 = Instantiate (button);
		Button button7 = Instantiate (button);

		for (int i = 0; i < 15; i++) {
			if (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text == "C")
				button1 = ButtonList [i];
		}
		for (int i = 0; i < 15; i++) {
			if (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text == "E")
				button2 = ButtonList [i];
		}
		for (int i = 0; i < 15; i++) {
			if (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text == "N")
				button3 = ButtonList [i];
		}
		for (int i = 0; i < 15; i++) {
			if (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text == "O")
				button4 = ButtonList [i];
		}
		for (int i = 0; i < 15; i++) {
			if (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text == "U")
				button5 = ButtonList [i];
		}
		for (int i = 0; i < 15; i++) {
			if (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text == "R")
				button6 = ButtonList [i];
		}
		for (int i = 0; i < 15; i++) {
			if (ButtonList [i].GetComponent<UnityEngine.UI.Text> ().text == "A")
				button7 = ButtonList [i];
		}

		game.taskOnClick (button1, game.solution);
		game.taskOnClick (button2, game.solution);
		game.taskOnClick (button3, game.solution);
		game.taskOnClick (button4, game.solution);
		game.taskOnClick (button5, game.solution);
		game.taskOnClick (button6, game.solution);
		game.taskOnClick (button7, game.solution);

		game.Update ();

		Assert.That (game.check.activeSelf == true); 
	}
}

