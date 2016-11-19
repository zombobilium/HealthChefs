using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Minigame3Controller : MonoBehaviour {

	public Button choice1;
	public Button choice2;
	public Text time;
	public Text score;
	public float roundTime;
	private int scoreNumber;
	private List<string> healthyIngredients;
	private List<string> unhealthyIngredients;

	void Start () 
	{
		time.text = "Time Left: " + roundTime;
		score.text = "Score: " + scoreNumber;

		healthyIngredients = new List<string> () { "sandwich_0", "apple_0", "water_0" };
		unhealthyIngredients = new List<string> (){ "chocolateChipCookies_1", "pizza_1", "soda_1" };

		choice1.onClick.AddListener (delegate {
			taskOnClick (choice1);
		});

		choice2.onClick.AddListener (delegate {
			taskOnClick (choice2);
		});

		setIngredients ();
	}

	void Update()
	{
		roundTime -= Time.deltaTime;

		if (roundTime > 0) {
			time.text = "Time Left: " + (int)roundTime;
			score.text = "Score: " + scoreNumber;
		}
		else gameEnd ();
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

	void taskOnClick(Button btn)
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
	}
}
