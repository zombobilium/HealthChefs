using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SlotHandlerMG4 : MonoBehaviour, IDropHandler {

	private int slotChecked = 0;

	public GameObject item {
		get {
			if (transform.childCount > 0)
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
				if (transform.name.Contains ("Fruit")) {
					for (int i = 0; i < transform.childCount; i++) {
						if (!transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("_0")) {
							StaticCheckGame.setGameWinFalse ();
							slotChecked++;
							StaticCheckGame.incSlotsChecked ();
							return;
						}
					}
				}
				else if (transform.name.Contains ("Veg")) {
					for (int i = 0; i < transform.childCount; i++) {
						if (!transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("_1")) {
							StaticCheckGame.setGameWinFalse ();
							slotChecked++;
							StaticCheckGame.incSlotsChecked ();
							return;
						}
					}
				}

				else if (transform.name.Contains ("Grains")) {
					for (int i = 0; i < transform.childCount; i++) {
						if (!transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("_2")) {
							StaticCheckGame.setGameWinFalse ();
							slotChecked++;
							StaticCheckGame.incSlotsChecked ();
							return;
						}
					}
				}

				else if (transform.name.Contains ("ProteinA")) {
					for (int i = 0; i < transform.childCount; i++) {
						if (!transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("_3")) {
							StaticCheckGame.setGameWinFalse ();
							slotChecked++;
							StaticCheckGame.incSlotsChecked ();
							return;
						}
					}
				}

				else if (transform.name.Contains ("ProteinV")) {
					for (int i = 0; i < transform.childCount; i++) {
						if (!transform.GetChild (i).gameObject.GetComponent<Image> ().sprite.name.Contains ("_4")) {
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
