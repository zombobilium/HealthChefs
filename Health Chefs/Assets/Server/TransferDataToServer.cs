using UnityEngine;
using System.Collections;

public class TransferDataToServer : MonoBehaviour {

	string createUserURL = "http://193.126.172.190/login/createuser.php";
	string minigames = "http://193.126.172.190/login/minigames.php";
	SendToServer sendToServer;

	// Use this for initialization
	IEnumerator Start () {
		
		if (System.IO.File.Exists (Application.persistentDataPath + "/sendToServer")) {
			sendToServer = FileManager.ReadFromBinaryFile<SendToServer> (Application.persistentDataPath + "/sendToServer");
			if (sendToServer.Id < 0) {
				yield return createUser ();
				yield return sendMinigame1Data ();
				yield return sendMinigame2Data ();
				yield return sendMinigame3Data ();
				yield return sendMinigame4Data ();
			}
			yield return sendMinigame1Data ();
			yield return sendMinigame2Data ();
			yield return sendMinigame3Data ();
			yield return sendMinigame4Data ();
		} 
		else 
		{
			sendToServer = new SendToServer ();
			yield return sendMinigame1Data ();
			yield return sendMinigame2Data ();
			yield return sendMinigame3Data ();
			yield return sendMinigame4Data ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator createUser()
	{
		WWW www = new WWW (createUserURL);
		yield return www;
		string urlText = www.text;
		print (urlText);
		sendToServer.Id = float.Parse(urlText);

		FileManager.WriteToBinaryFile (Application.persistentDataPath + "/sendToServer", sendToServer);
	}

	IEnumerator sendMinigame1Data()
	{
		print ("minigame 1 post");
		WWWForm form = new WWWForm ();
		form.AddField ("gameID", "1");
		form.AddField ("userID", sendToServer.Id.ToString());
		form.AddField ("gameName", "Forca");
		form.AddField ("highScore", sendToServer.minigame1Highscore.ToString());
		form.AddField ("timesPlayed", sendToServer.minigame1TimesPlayed.ToString());
		form.AddField ("description", "Minijogo 1 - Forca");

		WWW www = new WWW (minigames, form);
		yield return www;

		print (www.text);
	}

	IEnumerator sendMinigame2Data()
	{
		print ("minigame 2 post");
		WWWForm form = new WWWForm ();
		form.AddField ("gameID", "2");
		form.AddField ("userID", sendToServer.Id.ToString());
		form.AddField ("gameName", "Frigorifico");
		form.AddField ("highScore", sendToServer.minigame2Highscore.ToString());
		form.AddField ("timesPlayed", sendToServer.minigame2TimesPlayed.ToString());
		form.AddField ("description", "Minijogo 2 - Frigorifico");

		WWW www = new WWW (minigames, form);
		yield return www;

		print (www.text);
	}

	IEnumerator sendMinigame3Data()
	{
		print ("minigame 3 post");
		WWWForm form = new WWWForm ();
		form.AddField ("gameID", "3");
		form.AddField ("userID", sendToServer.Id.ToString());
		form.AddField ("gameName", "Lancheira");
		form.AddField ("highScore", sendToServer.minigame3Highscore.ToString());
		form.AddField ("timesPlayed", sendToServer.minigame3TimesPlayed.ToString());
		form.AddField ("description", "Minijogo 3 - Lancheira");

		WWW www = new WWW (minigames, form);
		yield return www;
	
		print (www.text);
	}

	IEnumerator sendMinigame4Data()
	{
		print ("minigame 4 post");
		WWWForm form = new WWWForm ();
		form.AddField ("gameID", "4");
		form.AddField ("userID", sendToServer.Id.ToString());
		form.AddField ("gameName", "Frigorifico");
		form.AddField ("highScore", sendToServer.minigame4Highscore.ToString());
		form.AddField ("timesPlayed", sendToServer.minigame4TimesPlayed.ToString());
		form.AddField ("description", "Minijogo 4 - Jantar");

		WWW www = new WWW (minigames, form);
		yield return www;

		print (www.text);
	}
}
