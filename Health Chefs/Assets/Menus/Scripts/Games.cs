using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Games : MonoBehaviour {

	public Text menu;

	// Use this for initialization
	void Start () {
		if (StaticLanguage.getLanguage ().Equals ("portuguese"))
			menu.text = "Jogos";
		else
			menu.text = "Games";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
