using UnityEngine;
using System.Collections;

public class Minigame1MenuController : MonoBehaviour {

	public GameObject instructionsPanel;

	public void Start()
	{
		if (StaticMinigame3Controller.getReplay () == true)
			instructionsPanel.SetActive (false);

		StaticMinigame3Controller.setReplay (false);
	}
}
