using UnityEngine;
using System.Collections;

public class MANAGER_SCENES : MonoBehaviour {

	public GameObject CAR_V1;
	public GameObject CAR_V2;
	public GameObject CAR_V3;

	public bool CAR_V1_bool;
	public bool CAR_V2_bool;
	public bool CAR_V3_bool;

	public Material Normal;
	public Material Transparent;

	public GUIStyle Title;
	public GUIStyle names;
	public GUIStyle buttons;


	//---------------------------MANAGER OF THE SCENE...------------------------------

	void Start () {

		CAR_V1_bool = false;
		CAR_V2_bool = true;
		CAR_V3_bool = false;

		CAR_V1.SetActive(false);
		CAR_V2.SetActive(true);
		CAR_V3.SetActive(false);
	}
	

	void Update () {
	    
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			CAR_V1.SetActive(true);
			CAR_V2.SetActive(false);
			CAR_V3.SetActive(false);
			CAR_V3_bool = false;
			CAR_V1_bool = true;
			CAR_V2_bool = false;
		}

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			CAR_V1.SetActive(false);
			CAR_V3.SetActive(false);
			CAR_V3_bool = false;
			CAR_V2.SetActive(true);
			CAR_V1_bool = false;
			CAR_V2_bool = true;

		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			CAR_V1.SetActive(false);
			CAR_V2.SetActive(false);
			CAR_V3.SetActive(true);
			CAR_V1_bool = false;
			CAR_V2_bool = false;
			CAR_V3_bool = true;
		}

		if(CAR_V1_bool)
		{
			if(Input.GetKeyDown(KeyCode.H))
			{
				CAR_V1.transform.FindChild("BODY").renderer.material = Normal;
			}
			if(Input.GetKeyDown(KeyCode.J))
			{
				CAR_V1.transform.FindChild("BODY").renderer.material = Transparent;
			}
		}
		if(CAR_V2_bool)
		{
			if(Input.GetKeyDown(KeyCode.H))
			{
				CAR_V2.transform.FindChild("BODY").renderer.material = Normal;
			}
			if(Input.GetKeyDown(KeyCode.J))
			{
				CAR_V2.transform.FindChild("BODY").renderer.material = Transparent;
			}
		}
		if(CAR_V3_bool)
		{
			if(Input.GetKeyDown(KeyCode.H))
			{
				CAR_V3.transform.FindChild("BODY").renderer.material = Normal;
			}
			if(Input.GetKeyDown(KeyCode.J))
			{
				CAR_V3.transform.FindChild("BODY").renderer.material = Transparent;
			}
		}
	}



	void OnGUI()

	{
		GUI.Label(new Rect(10,10,1,1),"CAR TUTORIAL by matt",Title);

		GUI.Label(new Rect(10,60,1,1),"Press number 1 to change CAR_V1",buttons);
		GUI.Label(new Rect(10,90,1,1),"Press number 2 to change CAR_V2",buttons);
		GUI.Label(new Rect(10,120,1,1),"Press number 3 to change CAR_V3",buttons);

		GUI.Label(new Rect(10,200,1,1),"Press H to change Normal Material",buttons);
		GUI.Label(new Rect(10,230,1,1),"Press J to change Transparent Material",buttons);

		if(GUI.Button(new Rect(Screen.width-550,Screen.height-30,300,50),"MATTS CREATIONS OFFICIAL SITE",buttons))
		{
			Application.OpenURL("http://matts-creations.webnode.sk/");
		}
	}
}
