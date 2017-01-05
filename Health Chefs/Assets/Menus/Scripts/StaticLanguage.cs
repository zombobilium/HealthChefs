using UnityEngine;
using System.Collections;

public static class StaticLanguage  {

	private static string language = "portuguese";

	public static void setLanguage(string languageToSet)
	{
		language = languageToSet;
	}

	public static string getLanguage()
	{
		return language;
	}

}
