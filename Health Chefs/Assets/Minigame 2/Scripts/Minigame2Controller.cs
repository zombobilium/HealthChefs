using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Minigame2Controller : MonoBehaviour {

	public Image correct;
	public Image wrong;
	public GameObject inventory;
	public List<Image> foodButtons;
	public List<Image> fullFoodButtons;
	public Text score;
	public Text time;
	public float roundTime;
	private List<string> proteins;
	private List<string> lacts;
	private List<string> vegetables;
	private List<string> drinks;
	private List<string> fruits;
	private List<string> allFoods;
	private bool gameOn = false;
	private int scoreNumber = 0;
	private SendToServer sendToServer;
	public Text instructions;
	public Text gameEndHighscoreSub;
	public Text instructionHighscoreSub;
	public Text highscore;
	public GameObject instructionsPanel;
	public Text gameEndMessage;
	public GameObject gameEndPanel;
	public Text highscore2;

	public void Start()
	{
		StaticCheckGame.reset ();
		if (StaticMinigame3Controller.getReplay () == true)
			instructionsPanel.SetActive (false);
		StaticCheckGame.reset ();
		if (StaticLanguage.getLanguage ().Equals ("portuguese")) {
			instructions.text = "Organiza o frigorífico o máximo número de vezes dentro do tempo limite, movendos as comidas para o respetivo lugar seguindo estas regras:\n - Bebidas na porta;\n - Apenas os vegetais e frutas podem estar na secção inferior do frigorífico;\n - Na mesma secção apenas pode existir uma família de alimentos.";
			instructionHighscoreSub.text = "Melhor Pontuação";
			gameEndHighscoreSub.text = "Melhor Pontuação";
		} else {
			instructions.text = "Organize the fridge, as many times as you can within the time limit, moving the foods to their respective places following these rules:\n - Drinks on the door;\n - Only vegetables and fruits can stay on the lower section of the fridge;\n - On the same section there can only be one food family."; 
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
		highscore.text = "" + sendToServer.minigame2Highscore;
		setFoods ();
	}

	public void setFoods()
	{
		proteins = new List<string> () { "meat_protein" };
		lacts = new List<string> () { "cheese_lact" };
		vegetables = new List<string> () { "batata_vegetable", "beringela_vegetable", "beterraba_vegetable", "carrot_vegetable", "radish_vegetable" };
		drinks = new List<string> () { "water_drink" };
		fruits = new List<string> () { "pera_fruit", "apple_fruit", "banana_fruit", "cherries_fruit" };
		allFoods = new List<string> () { "meat_protein", "cheese_lact", "batata_vegetable", "water_drink", "pera_fruit", "apple_fruit", "banana_fruit", "beringela_vegetable", "beterraba_vegetable", "carrot_vegetable", "cherries_fruit", "radish_vegetable" }; 

		int randomProtein = Random.Range (0, proteins.Count);
		int randomLact = Random.Range (0, lacts.Count);
		int randomVegetable = Random.Range (0, vegetables.Count);
		int randomDrink = Random.Range (0, drinks.Count);
		int randomFruit = Random.Range (0, fruits.Count);

		List<Sprite> randoms = new List<Sprite> () 
		{ 
			Resources.Load ("Minigame 2/" + proteins[randomProtein], typeof(Sprite)) as Sprite,
			Resources.Load ("Minigame 2/" + lacts[randomLact], typeof(Sprite)) as Sprite,
			Resources.Load ("Minigame 2/" + vegetables[randomVegetable], typeof(Sprite)) as Sprite,
			Resources.Load ("Minigame 2/" + drinks[randomDrink], typeof(Sprite)) as Sprite,
			Resources.Load ("Minigame 2/" + fruits[randomFruit], typeof(Sprite)) as Sprite 
		};

		allFoods.Remove (proteins [randomProtein]);
		allFoods.Remove (lacts [randomLact]);
		allFoods.Remove (vegetables [randomVegetable]);
		allFoods.Remove (fruits [randomFruit]);
		allFoods.Remove (drinks [randomDrink]);

		for (int i = 0; i < randoms.Count; i++) 
		{
			int randomPlace = Random.Range (0, foodButtons.Count);
			foodButtons[randomPlace].GetComponent<Image>().sprite = randoms[i];
			foodButtons.RemoveAt (randomPlace);
		}

		for (int i = 0; i < foodButtons.Count; i++) {
			int randomFood = Random.Range (0, allFoods.Count);
			foodButtons [i].sprite = Resources.Load ("Minigame 2/" + allFoods [randomFood], typeof(Sprite)) as Sprite; 
			allFoods.RemoveAt (randomFood);	
		}
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

			if (inventory.transform.childCount == 0) {
				setReplayFalse ();
				gameOn = true;
				StaticCheckGame.setGameEndedTrue ();
				if (StaticCheckGame.getSlotsChecked () == 7) {
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

	IEnumerator nextRound()
	{
		yield return new WaitForSeconds (0.5f);
		Image[] temp = new Image[8];
		fullFoodButtons.CopyTo (temp);
		foodButtons = new List<Image> ();
		for (int i = 0; i < temp.Length; i++) {
			foodButtons.Add (temp [i]);
		}

		for (int i = 0; i < foodButtons.Count; i++) {
			foodButtons [i].transform.SetParent (inventory.transform);
		}
		wrong.gameObject.SetActive (false);
		correct.gameObject.SetActive (false);
		gameOn = true;
		StaticCheckGame.nextRound ();
		StaticCheckGame.incRoundNumber ();
		setFoods ();
	}

	public void gameEnd()
	{
		for (int i = 0; i < fullFoodButtons.Count; i++) {
			fullFoodButtons [i].gameObject.SetActive (false);
		}

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

		if(scoreNumber > sendToServer.minigame2Highscore)
			sendToServer.minigame2Highscore = scoreNumber;

		sendToServer.minigame2TimesPlayed++;
		FileManager.WriteToBinaryFile (Application.persistentDataPath + "/sendToServer", sendToServer);
		gameOn = false;

		highscore2.text = "" + sendToServer.minigame2Highscore;
		gameEndPanel.SetActive (true);
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
