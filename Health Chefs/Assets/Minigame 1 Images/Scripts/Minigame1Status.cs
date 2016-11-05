using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

[System.Serializable]
public class Minigame1Status {

	public Dictionary<string, int> ingredients = new Dictionary<string, int>()
	{
		{"ALFACE", 0},
		{"CENOURA", 0},
		{"COUVE", 0},
		{"TOMATE", 0},
		{"MILHO", 0},
		{"ERVILHA", 0},
		{"PIMENTO", 0},
		{"CEBOLA", 0},
		{"ALHO", 0},
		{"BRÓCULOS", 0},
		{"ESPINAFRE", 0},
		{"PEPINO", 0},
	};

	public void setIngredientAsDone(string ingredient)
	{
		ingredients [ingredient] = 1;
	}
}
