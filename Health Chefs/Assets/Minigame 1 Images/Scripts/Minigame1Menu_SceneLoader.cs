using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

public class Minigame1Menu_SceneLoader : MonoBehaviour {

	public Button alface;
	public Button cenoura;
	public Button couve;
	public Button tomate;
	public Button milho;
	public Button ervilha;
	public Button pimento;
	public Button cebola;
	public Button alho;
	public Button broculos;
	public Button espinafre;
	public Button pepino;

	Minigame1Status status;

	public void loadScene(string image)
	{
		StaticSceneManager.LoadScene ("Guess_Scene", image);
	}

	void Start()
	{
		if (!System.IO.File.Exists(Application.persistentDataPath + "/cenas"))
		{
			status = new Minigame1Status ();
		} else 
		{
			status = FileManager.ReadFromBinaryFile<Minigame1Status> (Application.persistentDataPath + "/cenas");
		}

		if (status.ingredients ["ALFACE"] == 1)
			alface.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["CENOURA"] == 1)
			cenoura.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["COUVE"] == 1)
			couve.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["TOMATE"] == 1)
			tomate.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["MILHO"] == 1)
			milho.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["ERVILHA"] == 1)
			ervilha.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["PIMENTO"] == 1)
			pimento.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["CEBOLA"] == 1)
			cebola.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["ALHO"] == 1)
			alho.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["BRÓCULOS"] == 1)
			broculos.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["ESPINAFRE"] == 1)
			espinafre.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["PEPINO"] == 1)
			pepino.gameObject.transform.GetChild (0).gameObject.SetActive (true);
	}

}
