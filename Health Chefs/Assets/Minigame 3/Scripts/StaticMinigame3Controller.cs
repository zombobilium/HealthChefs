using UnityEngine;
using System.Collections;

public class StaticMinigame3Controller {

	private static bool replay = false;

	public static bool getReplay()
	{
		return replay;
	}

	public static void setReplay(bool value)
	{
		replay = value;
	}

}
