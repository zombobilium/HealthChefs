using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Avatar : MonoBehaviour {

	public Image head;
	public Image torso;
	public Image legs;
	public Button male;
	public Button female;
	private AvatarSelection avatar;
	public Text genero;
	public Text ethnicity;

	void Start () 
	{
		if (StaticLanguage.getLanguage ().Equals ("portuguese")) {
			genero.text = "Género";
			ethnicity.text = "Etnia";
		} else {
			genero.text = "Gender";
			ethnicity.text = "Ethnicity";
		}
		if (!System.IO.File.Exists(Application.persistentDataPath + "/avatar"))
		{
			avatar = new AvatarSelection ();
		} else 
		{
			avatar = FileManager.ReadFromBinaryFile<AvatarSelection> (Application.persistentDataPath + "/avatar");
		}
		head.sprite = avatar.selectCurrentHead ();
		torso.sprite = avatar.selectCurrentTorso ();
		legs.sprite = avatar.selectCurrentLegs ();
		if (avatar.getGender ().Equals ("Male"))
			male.interactable = false;
		else
			female.interactable = false;
	}

	public void selectHeadAfter()
	{
		head.sprite = avatar.selectHeadAfter();
	}

	public void selectHeadBefore()
	{
		head.sprite = avatar.selectHeadBefore();
	}

	public void selectTorsoAfter()
	{
		torso.sprite = avatar.selectTorsoAfter ();
	}

	public void selectTorsoBefore()
	{
		torso.sprite = avatar.selectTorsoBefore ();
	}

	public void selectLegsAfter()
	{
		legs.sprite = avatar.selectLegsAfter ();
	}

	public void selectLegsBefore()
	{
		legs.sprite = avatar.selectLegsBefore ();
	}

	public void selectSkinAfter()
	{
		if (avatar.getHeadSkin ().Equals("White"))
			selectBlackSkin ();
		else if (avatar.getHeadSkin ().Equals("Black"))
			selectAsianSkin ();
		else
			selectWhiteSkin ();
	}

	public void selectSkinBefore()
	{
		if (avatar.getHeadSkin ().Equals("White"))
			selectAsianSkin ();
		else if (avatar.getHeadSkin ().Equals("Black"))
			selectWhiteSkin ();
		else
			selectBlackSkin ();
	}

	public void selectMaleGender()
	{
		avatar.setMale ();
		head.sprite = avatar.selectCurrentHead ();
		torso.sprite = avatar.selectCurrentTorso ();
		legs.sprite = avatar.selectCurrentLegs ();

		male.interactable = false;
		female.interactable = true;
	}

	public void selectFemaleGender()
	{
		avatar.setFemale ();
		head.sprite = avatar.selectCurrentHead ();
		torso.sprite = avatar.selectCurrentTorso ();
		legs.sprite = avatar.selectCurrentLegs ();

		male.interactable = true;
		female.interactable = false;
	}

	public void selectWhiteSkin()
	{
		avatar.setWhiteSkin ();
		head.sprite = avatar.selectCurrentHead ();
		torso.sprite = avatar.selectCurrentTorso ();
		legs.sprite = avatar.selectCurrentLegs ();
	}

	public void selectBlackSkin()
	{
		avatar.setBlackSkin ();
		head.sprite = avatar.selectCurrentHead ();
		torso.sprite = avatar.selectCurrentTorso ();
		legs.sprite = avatar.selectCurrentLegs ();

	}

	public void selectAsianSkin()
	{
		avatar.setAsianSkin ();
		head.sprite = avatar.selectCurrentHead ();
		torso.sprite = avatar.selectCurrentTorso ();
		legs.sprite = avatar.selectCurrentLegs ();
	}

	public void saveAvatar()
	{
		FileManager.WriteToBinaryFile (Application.persistentDataPath + "/avatar", avatar);
	}
}
