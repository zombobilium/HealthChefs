using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

[System.Serializable]
public class Minigame1Status {

	public Dictionary<string, int> ingredients = new Dictionary<string, int>()
	{
		{"ABÓBORA", 0},
		{"BATATAS", 0},
		{"BERINGELA", 0},
		{"BETERRABA", 0},
		{"BRÓCOLOS", 0},
		{"CEBOLA", 0},
		{"CENOURA", 0},
		{"COURGETTE", 0},
		{"COUVE", 0},
		{"ERVILHAS", 0},
		{"ESPARGOS", 0},
		{"MILHO", 0},
		{"PEPINO", 0},
		{"PIMENTO", 0},
		{"RABANETE", 0},
		{"TOMATE", 0}
	};

	public void setIngredientAsDone(string ingredient)
	{
		ingredients [ingredient] = 1;
	}
}
