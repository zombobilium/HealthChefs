using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DynamicGrid : MonoBehaviour {

	public GameObject panel;
	public Button button;
	public int col, row;

	void Start () {

		//button.transform.SetParent (panel.transform);
		updateGrid ();
	}

	void updateGrid() {

		RectTransform panelRectTransform = panel.GetComponent<RectTransform> ();
		GridLayoutGroup grid = panel.GetComponent<GridLayoutGroup> ();
		int numberOfCells = panel.transform.childCount;
		grid.cellSize = new Vector2 (panelRectTransform.rect.width /col, panelRectTransform.rect.height/row);

	}
		
}
