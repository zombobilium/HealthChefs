using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class SlotHandler : MonoBehaviour, IDropHandler {

	private int slotChecked = 0;

	public GameObject item 
	{
		get {
			if (transform.childCount > 2)
				return transform.GetChild (0).gameObject;
			return null;
		}
	}

	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		if (!item) {
			DragHandler.itemBeingDragged.transform.SetParent (transform);
		}
	}

	#endregion

	public void Update()
	{
		string type = "";
		if (slotChecked == StaticCheckGame.getRoundNumber()) {
			if (StaticCheckGame.getGameEnded() == true) {
				if (transform.name.Contains ("Drinks")) {
					for (int i = 0; i < transform.childCount; i++) {
						if (!transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("drink")) {
							StaticCheckGame.setGameWinFalse ();
							slotChecked++;
							StaticCheckGame.incSlotsChecked ();
							return;
						}
					}
				}
				if (transform.name.Contains ("Bottom")) {
					for (int i = 0; i < transform.childCount; i++) {
						if (!transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("vegetable")
							&& !transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("fruit")) {
							StaticCheckGame.setGameWinFalse ();
							slotChecked++;
							StaticCheckGame.incSlotsChecked ();
							return;
						}
					}
				}
				if (transform.name.Contains ("Panel")) {
					for (int i = 0; i < transform.childCount; i++) {
						if (!transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("protein")
							&& !transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("lact")) {
							StaticCheckGame.setGameWinFalse ();
							slotChecked++;
							StaticCheckGame.incSlotsChecked ();
							return;
						}
					}
				}
				for (int i = 0; i < transform.childCount; i++) {
					if (i == 0) {
						if (transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("protein"))
							type = "protein";
						else if (transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("vegetable"))
							type = "vegetable";
						else if (transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("fruit"))
							type = "fruit";
						else if (transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("lact"))
							type = "lact";
					}
					if (i > 0) {
						if (!transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains (type)) {
							StaticCheckGame.setGameWinFalse ();
							slotChecked++;
							StaticCheckGame.incSlotsChecked ();
							return;
						}
					}
				}
				slotChecked++;
				StaticCheckGame.incSlotsChecked ();
			}
		}
	}
}

