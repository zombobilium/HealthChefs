using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class languageButtons : MonoBehaviour {

	public Button engFlag;
	public Button portFlag;

	public Button gameWorld;
	public Button settings;
	public Button avatar;	

	// Use this for initialization
	void Start () {

		if (StaticLanguage.getLanguage ().Equals("portuguese"))
			portFlag.interactable = false;
		else
			engFlag.interactable = false;

		engFlag.onClick.AddListener(delegate {
			taskOnClick("english");
			engFlag.interactable = false;
			portFlag.interactable = true;
		});
		portFlag.onClick.AddListener(delegate {
			taskOnClick("portuguese");
			portFlag.interactable = false;
			engFlag.interactable = true;
		});
	}
	
	void taskOnClick(string language)
	{
		StaticLanguage.setLanguage (language);
		gameWorld.GetComponent<Image>().sprite = Resources.Load ("Menu/" + language + "/gameworld", typeof(Sprite)) as Sprite;
		settings.GetComponent<Image>().sprite = Resources.Load ("Menu/" + language + "/settings", typeof(Sprite)) as Sprite;
		avatar.GetComponent<Image>().sprite = Resources.Load ("Menu/" + language + "/avatar", typeof(Sprite)) as Sprite;
	}

}
