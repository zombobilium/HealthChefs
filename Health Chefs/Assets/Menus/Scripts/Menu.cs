using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

	public Button gameWorld;
	public Button settings;
	public Button avatar;

	// Use this for initialization
	void Start () {
		gameWorld.GetComponent<Image>().sprite = Resources.Load ("Menu/" + StaticLanguage.getLanguage() + "/gameworld", typeof(Sprite)) as Sprite;
		settings.GetComponent<Image>().sprite = Resources.Load ("Menu/" + StaticLanguage.getLanguage() + "/settings", typeof(Sprite)) as Sprite;
		avatar.GetComponent<Image>().sprite = Resources.Load ("Menu/" + StaticLanguage.getLanguage() + "/avatar", typeof(Sprite)) as Sprite;
	}
}
