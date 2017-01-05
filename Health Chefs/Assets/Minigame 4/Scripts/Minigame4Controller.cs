using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Minigame4Controller : MonoBehaviour {

	public Image choice1;
	public Image choice2;
	public Image choice3;
	public Image choice4;
	public Image choice5;
	public Text time;
	public Text score;
	public float roundTime;
	private int scoreNumber = 0;
	private List<string> fruit;
	private List<string> legume;
	private List<string> hidrato;
	private List<string> proteinA;
	private List<string> proteinV;
	private SendToServer sendToServer;
	private bool gameOn = false;
	public Text instructions;
	public Text gameEndHighscoreSub;
	public Text instructionHighscoreSub;
	public Text highscore;
	public GameObject instructionsPanel;
	public GameObject inventory;
	public Image correct;
	public Image wrong;
	public List<Image> foodButtons;
	public Text gameEndMessage;
	public GameObject gameEndPanel;
	public Text highscore2;

	public void Start () 
	{
		if (StaticMinigame3Controller.getReplay () == true)
			instructionsPanel.SetActive (false);
		StaticCheckGame.reset ();
		if (StaticLanguage.getLanguage ().Equals ("portuguese")) {
			instructions.text = "Organiza o teu prato, o máximo número de vezes dentro do tempo limite, movendo as comidas para o seu respetivo lugar.";
			instructionHighscoreSub.text = "Melhor Pontuação";
			gameEndHighscoreSub.text = "Melhor Pontuação";
		} else {
			instructions.text = "Organize your plate, as many times as you can within the time limit, moving the foods to their respective places."; 
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
		time.text = "Time Left: " + roundTime;
		score.text = "Score: " + scoreNumber;

		highscore.text = "" + sendToServer.minigame4Highscore;

		setIngredients ();
	}

	public void Update()
	{
		if (gameOn || StaticMinigame3Controller.getReplay() == true) {
			roundTime -= Time.deltaTime;

			if (roundTime > 0) {
				time.text = "Time Left: " + (int)roundTime;
				score.text = "Score: " + scoreNumber;
			} else
				gameEnd ();

			if (inventory.transform.childCount == 0) {
				setReplayFalse ();
				gameOn = true;
				StaticCheckGame.setGameEndedTrue ();
				if (StaticCheckGame.getSlotsChecked () == 5) {
					if (StaticCheckGame.getGameWin () == false) {
						wrong.gameObject.SetActive (true);
						correct.gameObject.SetActive (false);
						gameOn = false;
						StartCoroutine(nextRound ());
					} else {
						correct.gameObject.SetActive (true);
						wrong.gameObject.SetActive (false);
						scoreNumber++;
						gameOn = false;
						StartCoroutine(nextRound ());
					}
				}
			}
		}
	}

	void setIngredients()
	{
		//inicia listas
		fruit = new List<string> () { "ameixa_0", "ananas_0", "banana_0", "cereja_0", "kiwi_0", "laranja_0", "maca_0", "morango_0", "pera_0", "uva_0" };
		legume = new List<string> () { "berinjela_1", "pepino_1", "beterraba_1", "brocolos_1", "cebola_1", "cenoura_1", "couve_1", "pimento_1", "rabanete_1", "tomate_1"};
		hidrato = new List<string> () { "milho_2", "batata_2"};
		proteinA = new List<string> () { "ovos_3"};
		proteinV = new List<string> () { "ervilha_4"};

		int randomFruit = Random.Range (0, fruit.Count);
		int randomLegume = Random.Range (0, legume.Count);
		int randomHidrato = Random.Range (0, hidrato.Count);
		int randomProteinaA = Random.Range (0, proteinA.Count);
		int randomProteinaV = Random.Range (0, proteinV.Count);

		int choice = Random.Range (0, 8);
		 
		switch (choice) {
		case 0:
			choice1.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/frutas/" + fruit [randomFruit], typeof(Sprite)) as Sprite;
			choice2.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/legumes/" + legume [randomLegume], typeof(Sprite)) as Sprite;
			choice3.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/hidratos/" + hidrato [randomHidrato], typeof(Sprite)) as Sprite;
			choice4.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasA/" + proteinA [randomProteinaA], typeof(Sprite)) as Sprite;
			choice5.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasV/" + proteinV [randomProteinaV], typeof(Sprite)) as Sprite;
			break;

		case 1:
			choice5.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/frutas/" + fruit [randomFruit], typeof(Sprite)) as Sprite;
			choice1.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/legumes/" + legume [randomLegume], typeof(Sprite)) as Sprite;
			choice2.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/hidratos/" + hidrato [randomHidrato], typeof(Sprite)) as Sprite;
			choice3.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasA/" + proteinA [randomProteinaA], typeof(Sprite)) as Sprite;
			choice4.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasV/" + proteinV [randomProteinaV], typeof(Sprite)) as Sprite;
		 	break;
		
		case 2:
			choice4.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/frutas/" + fruit [randomFruit], typeof(Sprite)) as Sprite;
			choice5.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/legumes/" + legume [randomLegume], typeof(Sprite)) as Sprite;
			choice1.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/hidratos/" + hidrato [randomHidrato], typeof(Sprite)) as Sprite;
			choice2.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasA/" + proteinA [randomProteinaA], typeof(Sprite)) as Sprite;
			choice3.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasV/" + proteinV [randomProteinaV], typeof(Sprite)) as Sprite;
			break;

		case 3: 
			choice3.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/frutas/" + fruit [randomFruit], typeof(Sprite)) as Sprite;
			choice4.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/legumes/" + legume [randomLegume], typeof(Sprite)) as Sprite;
			choice5.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/hidratos/" + hidrato [randomHidrato], typeof(Sprite)) as Sprite;
			choice1.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasA/" + proteinA [randomProteinaA], typeof(Sprite)) as Sprite;
			choice2.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasV/" + proteinV [randomProteinaV], typeof(Sprite)) as Sprite;
			break;
		case 4:
			choice2.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/frutas/" + fruit [randomFruit], typeof(Sprite)) as Sprite;
			choice3.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/legumes/" + legume [randomLegume], typeof(Sprite)) as Sprite;
			choice4.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/hidratos/" + hidrato [randomHidrato], typeof(Sprite)) as Sprite;
			choice5.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasA/" + proteinA [randomProteinaA], typeof(Sprite)) as Sprite;
			choice1.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasV/" + proteinV [randomProteinaV], typeof(Sprite)) as Sprite;
			break;

		case 5:
			choice1.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/frutas/" + fruit [randomFruit], typeof(Sprite)) as Sprite;
			choice4.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/legumes/" + legume [randomLegume], typeof(Sprite)) as Sprite;
			choice2.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/hidratos/" + hidrato [randomHidrato], typeof(Sprite)) as Sprite;
			choice3.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasA/" + proteinA [randomProteinaA], typeof(Sprite)) as Sprite;
			choice5.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasV/" + proteinV [randomProteinaV], typeof(Sprite)) as Sprite;
			break;

		case 6:
			choice2.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/frutas/" + fruit [randomFruit], typeof(Sprite)) as Sprite;
			choice1.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/legumes/" + legume [randomLegume], typeof(Sprite)) as Sprite;
			choice4.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/hidratos/" + hidrato [randomHidrato], typeof(Sprite)) as Sprite;
			choice5.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasA/" + proteinA [randomProteinaA], typeof(Sprite)) as Sprite;
			choice3.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasV/" + proteinV [randomProteinaV], typeof(Sprite)) as Sprite;
			break;

		case 7:
			choice4.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/frutas/" + fruit [randomFruit], typeof(Sprite)) as Sprite;
			choice2.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/legumes/" + legume [randomLegume], typeof(Sprite)) as Sprite;
			choice5.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/hidratos/" + hidrato [randomHidrato], typeof(Sprite)) as Sprite;
			choice3.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasA/" + proteinA [randomProteinaA], typeof(Sprite)) as Sprite;
			choice1.GetComponent<Image> ().sprite = Resources.Load ("Minigame 4/proteinasV/" + proteinV [randomProteinaV], typeof(Sprite)) as Sprite;
			break;

		}
	}
	  
	IEnumerator nextRound()
	{
		yield return new WaitForSeconds (0.5f);
		for (int i = 0; i < foodButtons.Count; i++) {
			foodButtons [i].transform.SetParent (inventory.transform);
		}
		wrong.gameObject.SetActive (false);
		correct.gameObject.SetActive (false);
		gameOn = true;
		StaticCheckGame.nextRound ();
		StaticCheckGame.incRoundNumber ();
		setIngredients ();
	}

	void gameEnd()
	{
		if (StaticLanguage.getLanguage ().Equals ("portuguese")) {
			if (scoreNumber > sendToServer.minigame4Highscore)
				gameEndMessage.text = "Acabou o tempo!\nFizeste " + scoreNumber + " pontos e bateste a tua antiga melhor pontuação.";
			else
				gameEndMessage.text = "Acabou o tempo!\nFizeste " + scoreNumber + " pontos mas não conseguiste bater a tua melhor pontuação.";
		} 
		else 
		{
			if (scoreNumber > sendToServer.minigame4Highscore)
				gameEndMessage.text = "Time is up!\nYou got " + scoreNumber + " points and you were able to beat your previous highscore.";
			else
				gameEndMessage.text = "Time is up!\nYou got " + scoreNumber + " points but you were not able to beat your previous highscore.";
		}

		if(scoreNumber > sendToServer.minigame4Highscore)
			sendToServer.minigame4Highscore = scoreNumber;

		sendToServer.minigame4TimesPlayed++;
		FileManager.WriteToBinaryFile (Application.persistentDataPath + "/sendToServer", sendToServer);
		gameOn = false;

		highscore2.text = "" + sendToServer.minigame4Highscore;
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
