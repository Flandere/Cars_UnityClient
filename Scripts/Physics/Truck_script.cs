using UnityEngine;
using System.Collections;

public class Truck_script : MonoBehaviour {

	//Camera and camera position (lerp function)
	public GameObject cam;
	public GameObject Cam_position_lerper;

	//Create a wheel objects
	public GameObject Left1;
	public GameObject Left2;
	public GameObject Left3;
	public GameObject Right1;
	public GameObject Right2;
	public GameObject Right3;

	//speed and acceleration of speed
	public float speed;
	public float acceleration;

	//MAX and MIN speed
	public float MAXspeed;
	public float MINspeed;

	//Brake and Turning
	public float brake;
	public float turning;

	//Engine sound pitch
	public float Engine_meter;

	//Object main body (attacher)
	public GameObject body;

	//Gui style...
	public GUIStyle style;


	/*---------------------------INFO------------------------------
	 * 
	 * TRUCK IS TOO SAME THAN CARS...
	 * Only have a 6 wheels...
     */



	void Start () {

	    style.normal.textColor = Color.gray;
		style.fontSize = 40;

	}
	

	void Update () 
	{
		//Variation body is a main of the sound of engine pitch
		body.transform.GetComponent<AudioSource>().pitch = Engine_meter;

		if(speed<=1)
		{
			Engine_meter = 1;
		}
		if(speed<=7 && speed>=1)
		{
			Engine_meter = speed;
		}

		if(speed>=7)
		{
			Engine_meter = 7;
		}

		//Cam positioning and rotationing
		cam.transform.position = Vector3.Lerp(cam.transform.position,Cam_position_lerper.transform.position,0.05F);
		cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation,Cam_position_lerper.transform.rotation,0.05F);

		//Wheels object movement
		Left2.transform.position+=-Left2.transform.up * speed * Time.deltaTime;
		Left1.transform.position+=-Left1.transform.up * speed * Time.deltaTime;
		Left3.transform.position+=-Left3.transform.up * speed * Time.deltaTime;

		Right1.transform.position+=-Right1.transform.up * speed * Time.deltaTime;
		Right2.transform.position+=-Right2.transform.up * speed * Time.deltaTime;
		Right3.transform.position+=-Right3.transform.up * speed * Time.deltaTime;


		//Input speed ++ or speed -- (Lerp function), Input Up and Down
		if(Input.GetAxis("Vertical")>0)
		{
			speed = Mathf.Lerp(speed,MINspeed,acceleration);
		}

		else
		{
			speed = Mathf.Lerp(speed,0,acceleration);
		}

		if(Input.GetAxis("Vertical")<0)
		{
			speed = Mathf.Lerp(speed,MAXspeed,acceleration);
		}


		//Input Horizontal turning... Left and Right
		if(Input.GetAxis("Horizontal")>0)
		{
			Left1.transform.Rotate(Vector3.right	 * turning);
			Right1.transform.Rotate(Vector3.right	 * turning);
			Left2.transform.Rotate(Vector3.right	 * turning);
			Right2.transform.Rotate(Vector3.right	 * turning);
			Left3.transform.Rotate(Vector3.right	 * turning);
			Right3.transform.Rotate(Vector3.right	 * turning);
		}

		if(Input.GetAxis("Horizontal")<0)
		{
			Left1.transform.Rotate(-Vector3.right	 * turning);
			Right1.transform.Rotate(-Vector3.right	 * turning);
			Left2.transform.Rotate(-Vector3.right	 * turning);
			Right2.transform.Rotate(-Vector3.right	 * turning);
			Left3.transform.Rotate(-Vector3.right	 * turning);
			Right3.transform.Rotate(-Vector3.right	 * turning);
		}



		//Brake variation
		if(Input.GetKey(KeyCode.Space))
		{
			speed = Mathf.Lerp(speed,0,brake);
		}



	}

	void OnGUI()
	{
		//Speed in GUI
		GUI.Label(new Rect(Screen.width - 500,0,1,1),"SPEED: " + speed + "/10",style);
	}
}
