using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Minigame3Controller : MonoBehaviour {

	public Text instructions;
	public GameObject instructionsPanel;
	public GameObject gameEndPanel;
	public Text gameEndMessage;
	public Text instructionHighscoreSub;
	public Text gameEndHighscoreSub;
	public Button choice1;
	public Button choice2;
	public Text time;
	public Text score;
	public Text highscore;
	public Text highscore2;
	public float roundTime;
	private int scoreNumber = 0;
	private List<string> healthyIngredients;
	private List<string> unhealthyIngredients;
	private bool gameOn = false;
	SendToServer sendToServer;

	public void Start () 
	{
		if (StaticMinigame3Controller.getReplay () == true)
			instructionsPanel.SetActive (false);

		if (StaticLanguage.getLanguage ().Equals ("portuguese")) {
			instructions.text = "Em cada ronda, escolhe a comida que deves levar na lancheira. A cada resposta correta ganharás 1 ponto.";
			instructionHighscoreSub.text = "Melhor Pontuação";
			gameEndHighscoreSub.text = "Melhor Pontuação";
		} else {
			instructions.text = "In each round, choose the food you should take on your lunchbox. Each correct answear awards you with 1 point."; 
			instructionHighscoreSub.text = "Highscore";
			gameEndHighscoreSub.text = "Highscore";
		}

		if (!System.IO.File.Exists(Application.persistentDataPath + "/sendToServer"))
		{
			sendToServer = new SendToServer();
		} else 
		{
			sendToServer = FileManager.ReadFromBinaryFile<SendToServer> (Application.persistentDataPath + "/sendToServer");
		}
		time.text = roundTime.ToString();
		score.text = scoreNumber.ToString();

		highscore.text = "" + sendToServer.minigame3Highscore;

		healthyIngredients = new List<string> () { "banana_0", "carrot_0", "cucumber_0", "grapes_0", "kiwi_0", "orange_0", "pear_0", "sandwich_0", "tomato_0" };
		unhealthyIngredients = new List<string> (){ "candy_1", "candyStick_1", "hamburger_1", "hotdog_1", "pizza_1", "popcorn_1" };

		choice1.onClick.AddListener (delegate {
			taskOnClick (choice1);
		});

		choice2.onClick.AddListener (delegate {
			taskOnClick (choice2);
		});

		setIngredients ();
	}

	public void Update()
	{
		if (gameOn || StaticMinigame3Controller.getReplay() == true) {
			roundTime -= Time.deltaTime;

			if (roundTime > 0) {
				time.text = "" + (int)roundTime;
				score.text = scoreNumber.ToString();
			} else
				gameEnd ();
		}
	}

	void setIngredients()
	{
		choice1.interactable = true;
		choice2.interactable = true;

		int randomNumberHealthy = Random.Range (0, healthyIngredients.Count);
		int randomNumberUnhealthy = Random.Range (0, unhealthyIngredients.Count);

		int choice = Random.Range (0, 2);

		switch (choice) {
		case 0:
			choice1.GetComponent<Image> ().sprite = Resources.Load ("Minigame 3/healthyIngredients/" + healthyIngredients [randomNumberHealthy], typeof(Sprite)) as Sprite;
			choice2.GetComponent<Image> ().sprite = Resources.Load ("Minigame 3/unhealthyIngredients/" + unhealthyIngredients [randomNumberUnhealthy], typeof(Sprite)) as Sprite;
			break;

		case 1:
			choice2.GetComponent<Image> ().sprite = Resources.Load ("Minigame 3/healthyIngredients/" + healthyIngredients [randomNumberHealthy], typeof(Sprite)) as Sprite;
			choice1.GetComponent<Image> ().sprite = Resources.Load ("Minigame 3/unhealthyIngredients/" + unhealthyIngredients [randomNumberUnhealthy], typeof(Sprite)) as Sprite;
			break;
		}
	}

	public void taskOnClick(Button btn)
	{
		if (btn.GetComponent<Image> ().sprite.name.Contains ("_0")) {
			btn.transform.GetChild (0).gameObject.SetActive (true);
			scoreNumber++;
			choice1.interactable = false;
			choice2.interactable = false;
		}
		else if (btn.GetComponent<Image> ().sprite.name.Contains ("_1")) {
			btn.transform.GetChild (1).gameObject.SetActive (true);
			choice1.interactable = false;
			choice2.interactable = false;
		}

		StartCoroutine (nextRound ());
	}

	IEnumerator nextRound()
	{
		yield return new WaitForSeconds (0.5f);

		setIngredients ();

		choice1.transform.GetChild (0).gameObject.SetActive (false);
		choice1.transform.GetChild (1).gameObject.SetActive (false);

		choice2.transform.GetChild (0).gameObject.SetActive (false);
		choice2.transform.GetChild (1).gameObject.SetActive (false);
	}

	void gameEnd()
	{
		choice1.interactable = false;
		choice2.interactable = false;
		if (StaticLanguage.getLanguage ().Equals ("portuguese")) {
			if (scoreNumber > sendToServer.minigame2Highscore) {
				gameEndMessage.text = "Acabou o tempo!\nFizeste ";
				if (scoreNumber != 1) {
					gameEndMessage.text += scoreNumber + " pontos";
				} else
					gameEndMessage.text += scoreNumber + " ponto";
				gameEndMessage.text += " e bateste a tua antiga melhor pontuação.";
			} else {
				gameEndMessage.text = "Acabou o tempo!\nFizeste ";
				if (scoreNumber != 1) {
					gameEndMessage.text += scoreNumber + " pontos";
				} else
					gameEndMessage.text += scoreNumber + " ponto";
				gameEndMessage.text += " e não conseguiste bater a tua melhor pontuação.";
			}
		} 
		else 
		{
			if (scoreNumber > sendToServer.minigame2Highscore) {
				gameEndMessage.text = "Time is up!\nYou got ";
				if (scoreNumber != 1) {
					gameEndMessage.text += scoreNumber + " points";
				} else
					gameEndMessage.text += scoreNumber + " point";
				gameEndMessage.text += " and you were able to beat your previous highscore.";
			} else {
				gameEndMessage.text = "Time is up!\nYou got ";
				if (scoreNumber != 1) {
					gameEndMessage.text += scoreNumber + " points";
				} else
					gameEndMessage.text += scoreNumber + " point";
				gameEndMessage.text += " and you were not able to beat your previous highscore.";
			}
		}

		if(scoreNumber > sendToServer.minigame3Highscore)
			sendToServer.minigame3Highscore = scoreNumber;

		sendToServer.minigame3TimesPlayed++;
		FileManager.WriteToBinaryFile (Application.persistentDataPath + "/sendToServer", sendToServer);
		gameOn = false;

		highscore2.text = "" + sendToServer.minigame3Highscore;
		gameEndPanel.SetActive (true);
	}

	public int getScoreNumber()
	{
		return scoreNumber;
	}

	public void turnOffInstructions()
	{
		instructionsPanel.SetActive (false);
		gameOn = true;
	}

	public void setReplayTrue()
	{
		StaticMinigame3Controller.setReplay (true);
	}

	public void setReplayFalse()
	{
		StaticMinigame3Controller.setReplay (false);
	}
}
