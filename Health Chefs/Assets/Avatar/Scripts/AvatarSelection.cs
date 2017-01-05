using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AvatarSelection {

	private int head = 0;
	private int torso = 0;
	private int legs = 0;
	private string gender = "Male";
	private string skin = "White";
	private string headSkin = "White";
	private List<string> headImages = new List<string>() { "0", "1", "2", "3" };
	private List<string> torsoImages = new List<string>() { "0", "1", "2", "3", "4", "5", "6" };
	private List<string> legsImages = new List<string>() { "0", "1", "2", "3" };

	public Sprite selectCurrentHead()
	{
		return Resources.Load ("Avatar/Heads/" + gender + "/" + headSkin + "/" + headImages [head], typeof(Sprite)) as Sprite;
	}

	public Sprite selectCurrentTorso()
	{
		return Resources.Load ("Avatar/Torso/" + skin + "/" + torsoImages [torso], typeof(Sprite)) as Sprite;
	}

	public Sprite selectCurrentLegs()
	{
		return Resources.Load ("Avatar/Legs/" + gender + "/" + skin + "/" + legsImages [legs], typeof(Sprite)) as Sprite;
	}

	public Sprite selectHeadAfter() 
	{
		if (head == headImages.Count - 1)
			head = 0;
		else
			head++;

		return Resources.Load ("Avatar/Heads/" + gender + "/" + skin + "/" + headImages [head], typeof(Sprite)) as Sprite;
	}

	public Sprite selectHeadBefore()
	{
		if (head == 0)
			head = headImages.Count - 1;
		else
			head--;

		return Resources.Load ("Avatar/Heads/" + gender + "/" + skin + "/" + headImages [head], typeof(Sprite)) as Sprite;
	}

	public Sprite selectTorsoAfter()
	{
		if (torso == torsoImages.Count - 1)
			torso = 0;
		else
			torso++;

		return Resources.Load ("Avatar/Torso/" + skin + "/" + torsoImages [torso], typeof(Sprite)) as Sprite;
	}

	public Sprite selectTorsoBefore()
	{
		if (torso == 0)
			torso = torsoImages.Count - 1;
		else
			torso--;
		
		return Resources.Load ("Avatar/Torso/" + skin + "/" + torsoImages [torso], typeof(Sprite)) as Sprite;
	}

	public Sprite selectLegsAfter()
	{
		if (legs == legsImages.Count - 1)
			legs = 0;
		else
			legs++;

		return Resources.Load ("Avatar/Legs/" + gender + "/" + skin + "/" + legsImages [legs], typeof(Sprite)) as Sprite;
	}

	public Sprite selectLegsBefore()
	{
		if (legs == 0)
			legs = legsImages.Count - 1;
		else
			legs--;
		
		return Resources.Load ("Avatar/Legs/" + gender + "/" + skin + "/" + legsImages [legs], typeof(Sprite)) as Sprite;
	}

	public void setMale()
	{
		gender = "Male";
	}

	public void setFemale()
	{
		gender = "Female";
	}

	public void setWhiteSkin()
	{
		skin = "White";
		headSkin = "White";
	}

	public void setBlackSkin()
	{
		skin = "Black";
		headSkin = "Black";
	}

	public void setAsianSkin()
	{
		skin = "White";
		headSkin = "Asian";
	}

	public string getHeadSkin()
	{
		return headSkin;
	}

	public string getGender()
	{
		return gender;
	}
}

