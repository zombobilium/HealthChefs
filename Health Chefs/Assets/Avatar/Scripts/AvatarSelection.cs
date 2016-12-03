using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AvatarSelection {

	private static int head = 0;
	private static int torso = 0;
	private static int legs = 0;
	private static string gender = "Male";
	private static string skin = "White";
	private static List<string> headImages = new List<string>() { "0", "1", "2" };
	private static List<string> torsoImages = new List<string>() { "0" };
	private static List<string> legsImages = new List<string>() { "0" };

	public static Sprite selectCurrentHead()
	{
		return Resources.Load ("Avatar/Heads/" + gender + "/" + skin + "/" + headImages [head], typeof(Sprite)) as Sprite;
	}

	public static Sprite selectCurrentTorso()
	{
		return Resources.Load ("Avatar/Torso/" + skin + "/" + torsoImages [torso], typeof(Sprite)) as Sprite;
	}

	public static Sprite selectCurrentLegs()
	{
		return Resources.Load ("Avatar/Legs/" + skin + "/" + legsImages [legs], typeof(Sprite)) as Sprite;
	}

	public static Sprite selectHeadAfter() 
	{
		if (head == headImages.Count - 1)
			head = 0;
		else
			head++;

		return Resources.Load ("Avatar/Heads/" + gender + "/" + skin + "/" + headImages [head], typeof(Sprite)) as Sprite;
	}

	public static Sprite selectHeadBefore()
	{
		if (head == 0)
			head = headImages.Count - 1;
		else
			head--;

		return Resources.Load ("Avatar/Heads/" + gender + "/" + skin + "/" + headImages [head], typeof(Sprite)) as Sprite;
	}

	public static Sprite selectTorsoAfter()
	{
		if (torso == torsoImages.Count - 1)
			torso = 0;
		else
			torso++;

		return Resources.Load ("Avatar/Torso/" + skin + "/" + torsoImages [torso], typeof(Sprite)) as Sprite;
	}

	public static Sprite selectTorsoBefore()
	{
		if (torso == 0)
			torso = torsoImages.Count - 1;
		else
			torso--;
		
		return Resources.Load ("Avatar/Torso/" + skin + "/" + torsoImages [torso], typeof(Sprite)) as Sprite;
	}

	public static Sprite selectLegsAfter()
	{
		if (legs == legsImages.Count - 1)
			legs = 0;
		else
			legs++;

		return Resources.Load ("Avatar/Legs/" + skin + "/" + legsImages [legs], typeof(Sprite)) as Sprite;
	}

	public static Sprite selectLegsBefore()
	{
		if (legs == 0)
			legs = legsImages.Count - 1;
		else
			legs--;
		
		return Resources.Load ("Avatar/Legs/" + skin + "/" + legsImages [legs], typeof(Sprite)) as Sprite;
	}

	public static void setMale()
	{
		gender = "Male";
	}

	public static void setFemale()
	{
		gender = "Female";
	}

	public static void setWhiteSkin()
	{
		skin = "White";
	}

	public static void setBlackSkin()
	{
		skin = "Black";
	}
}

