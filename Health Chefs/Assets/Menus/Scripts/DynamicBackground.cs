using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DynamicBackground : MonoBehaviour {

	public GameObject background;
	public Camera cam;

	void Start () {
	

		background.transform.localScale = new Vector3 (1, 1, 1);
		float width = background.GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
		float height = background.GetComponent<SpriteRenderer> ().sprite.bounds.size.y;

		float worldScreenHeight = (float)(cam.orthographicSize * 2.0);
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		background.transform.localScale = new Vector2 (worldScreenWidth / width, worldScreenHeight/height);


		/*
		float worldScreenHeight = (float)(cam.orthographicSize * 250.0);
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		float newLocalScale = (worldScreenWidth / background.GetComponent<SpriteRenderer>().sprite.bounds.size.x);
		background.transform.localScale = new Vector2(newLocalScale, newLocalScale);*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
