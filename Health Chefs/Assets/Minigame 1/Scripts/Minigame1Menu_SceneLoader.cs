using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

public class Minigame1Menu_SceneLoader : MonoBehaviour {

	public Button abobora;
	public Button batata;
	public Button beringela;
	public Button beterraba;
	public Button brocolos;
	public Button cebola;
	public Button cenoura;
	public Button courgette;
	public Button couve;
	public Button ervilhas;
	public Button espargos;
	public Button milho;
	public Button pepino;
	public Button pimento;
	public Button rabanete;
	public Button tomate;

	public GameObject instructionsPanel;
	public Text instructions;

	Minigame1Status status;

	public void loadScene(string image)
	{
		StaticSceneManager.LoadScene ("Guess_Scene", image);
	}

	void Start()
	{
		if (!System.IO.File.Exists(Application.persistentDataPath + "/data"))
		{
			status = new Minigame1Status ();
		} else 
		{
			status = FileManager.ReadFromBinaryFile<Minigame1Status> (Application.persistentDataPath + "/data");
		}

		if(StaticLanguage.getLanguage().Equals("portuguese"))
			instructions.text = "Clique em cada uma das imagens e tente adivinhar o nome do vegetal respetivo.";
		else
			instructions.text = "Click on each image and try to guess the name of the respective vegetable.";

		if (status.ingredients ["ABÓBORA"] == 1)
			abobora.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["BATATAS"] == 1)
			batata.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["BERINGELA"] == 1)
			beringela.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["BETERRABA"] == 1)
			beterraba.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["BRÓCOLOS"] == 1)
			brocolos.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["CEBOLA"] == 1)
			cebola.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["CENOURA"] == 1)
			cenoura.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["COURGETTE"] == 1)
			courgette.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["COUVE"] == 1)
			couve.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["ERVILHAS"] == 1)
			ervilhas.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["ESPARGOS"] == 1)
			espargos.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["MILHO"] == 1)
			milho.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["PEPINO"] == 1)
			pepino.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["PIMENTO"] == 1)
			pimento.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["RABANETE"] == 1)
			rabanete.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		if (status.ingredients ["TOMATE"] == 1)
			tomate.gameObject.transform.GetChild (0).gameObject.SetActive (true);
	}

	public void turnOffInstructions()
	{
		instructionsPanel.SetActive (false);
	}
}
