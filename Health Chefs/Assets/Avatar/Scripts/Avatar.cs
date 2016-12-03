using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Avatar : MonoBehaviour {

	public Image head;
	public Image torso;
	public Image legs;
	public Button male;
	public Button female;
	public Button white;
	public Button black;

	void Start () 
	{
		head.sprite = AvatarSelection.selectCurrentHead ();
		torso.sprite = AvatarSelection.selectCurrentTorso ();
		legs.sprite = AvatarSelection.selectCurrentLegs ();
	}

	public void selectHeadAfter()
	{
		head.sprite = AvatarSelection.selectHeadAfter();
	}

	public void selectHeadBefore()
	{
		head.sprite = AvatarSelection.selectHeadBefore();
	}

	public void selectTorsoAfter()
	{
		torso.sprite = AvatarSelection.selectTorsoAfter ();
	}

	public void selectTorsoBefore()
	{
		torso.sprite = AvatarSelection.selectTorsoBefore ();
	}

	public void selectLegsAfter()
	{
		legs.sprite = AvatarSelection.selectLegsAfter ();
	}

	public void selectLegsBefore()
	{
		legs.sprite = AvatarSelection.selectLegsBefore ();
	}

	public void selectMaleGender()
	{
		AvatarSelection.setMale ();
		head.sprite = AvatarSelection.selectCurrentHead ();
		torso.sprite = AvatarSelection.selectCurrentTorso ();
		legs.sprite = AvatarSelection.selectCurrentLegs ();

		male.interactable = false;
		female.interactable = true;
	}

	public void selectFemaleGender()
	{
		AvatarSelection.setFemale ();
		head.sprite = AvatarSelection.selectCurrentHead ();
		torso.sprite = AvatarSelection.selectCurrentTorso ();
		legs.sprite = AvatarSelection.selectCurrentLegs ();

		female.interactable = false;
		male.interactable = true;
	}

	public void selectWhiteSkin()
	{
		AvatarSelection.setWhiteSkin ();
		head.sprite = AvatarSelection.selectCurrentHead ();
		torso.sprite = AvatarSelection.selectCurrentTorso ();
		legs.sprite = AvatarSelection.selectCurrentLegs ();

		white.interactable = false;
		black.interactable = true;
	}

	public void selectBlackSkin()
	{
		AvatarSelection.setBlackSkin ();
		head.sprite = AvatarSelection.selectCurrentHead ();
		torso.sprite = AvatarSelection.selectCurrentTorso ();
		legs.sprite = AvatarSelection.selectCurrentLegs ();

		black.interactable = false;
		white.interactable = true;
	}
}
