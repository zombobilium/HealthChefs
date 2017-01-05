using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AvatarDisplayOnly : MonoBehaviour {

	public Image head;
	public Image torso;
	public Image legs;
	private AvatarSelection avatar;

	void Start () 
	{
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
	}
}
