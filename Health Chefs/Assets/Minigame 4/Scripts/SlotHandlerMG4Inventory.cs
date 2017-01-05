using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SlotHandlerMG4Inventory : MonoBehaviour, IDropHandler {

	public GameObject item {
		get {
			if (transform.childCount > 3)
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
}
