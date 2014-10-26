using UnityEngine;
using System.Collections;

public class car_script_V2 : MonoBehaviour {

	//Camera and camera position (Lerp function)
	public GameObject cam;
	public GameObject Cam_position_lerper;

	//Create a wheels object
	public GameObject front_left;
	public GameObject back_left;
	public GameObject front_right;
	public GameObject back_right;
	
	//speed, accerelation, brake, turning, MAXspeed and MINspeed are basic variations by float
	public float speed;
	public float acceleration;

	public float MAXspeed;
	public float MINspeed;

	public float brake;
	public float turning;

	//Engine sound by Engine_meter
	public float Engine_meter;

	//Object main body (attacher)
	public GameObject body;

	//GUI style for showing car speed
	public GUIStyle style;




	//----------------------------------------INFORMATION ABOUT THIS CAR SCRIPT V2----------------------------------------------------

	/*
	 * WELCOME TO THE CAR SCRIPT V2!
	 * 
	 * Main: This script using 2 models of cars...
	 * CAR_V2 and CAR_V3
	 * 
	 * 
	 * CAR_V2
	 * 
	 * CAR_V2 is created from 1 Mesh, 3 Mesh Colliders and 4 Wheels
	 * - using Unity 3D physically Components: Rigidbody, Configurable joints.
	 * 
	 * - You can see in this script variation named Body (means a main body of the car)
	 * - Body have a Rigidbody: Mass- 1, everything else default...
	 * 
	 * - You can see in this script variations named Wheels (means a wheels of the car)
	 * - Wheels have a Rigidbody: Mass- 5, everything else default... And Configurable joints: YMotion- Limited, Others motions and Angulars Motions Locked, others default...
	 * - Wheels are attached to the Bodys rigidbody...
	 * 
	 * - CONTROLS: Movement- WASD, Brake- Space
	 * 
	 * 
	 * CAR_V3
	 * 
	 * CAR_V3 is created from 1 Mesh, 3 Mesh Colliders and 4 Wheels
	 * - using Unity 3D physically Components: Rigidbody, Configurable joints.
	 * 
	 * - You can see in this script variation named Body (means a main body of the car)
	 * - Body have a Rigidbody: Mass- 50, everything else default... And Configurable joints: 
	 * Creaded 4 Configurable joints for 4 wheels
	 * ZMotion- Limited, Others motions and Angulars Motions Locked...
	 * 
     * - You can see in this script variations named Wheels (means a wheels of the car)
	 * - Wheels have a Rigidbody: Mass- 5, everything else default... 
	 * 
	 * - CONTROLS: Movement- WASD, Brake- Space
	 * 
	 * 
	 * CAR_V2 vs CAR_V3
	 * 
	 * CAR_V2: His wheels have locked all Angular motions and Motions (means: A low wheels positioning if you can see...)
	 * CAR_V3: His body is attached on the wheels (means: the wheels are limited so the body is rolling on the wheels if you can see...)
	 * 
	 * 
	 * 
	 * 
	 * IF YOU NEED A MORE HELP, TELL ME ON THE MAIL: matt-s-creations-official@centrum.sk or tell me on my official page MATTS CREATIONS
    */


	void Start () {

		style.normal.textColor = Color.gray;
		style.fontSize = 40;
	}
	

	void Update () {

		//Variation body is a main of the sound engine pitch
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

		//All wheels speed are attached on the float speed, they are still in the moving
		back_left.transform.position+=back_left.transform.forward * speed * Time.deltaTime;
		back_right.transform.position+=back_right.transform.forward * speed * Time.deltaTime;

		front_left.transform.position+=front_left.transform.forward * speed * Time.deltaTime;
		front_right.transform.position+=front_right.transform.forward * speed * Time.deltaTime;


		//Input speed ++ or speed -- (Lerp function), Input Up and Down
		if(Input.GetAxis("Vertical")>0)
		{
			speed = Mathf.Lerp(speed,MAXspeed,acceleration);
		}

		else
		{
			speed = Mathf.Lerp(speed,0,acceleration);
		}

		if(Input.GetAxis("Vertical")<0)
		{
			speed = Mathf.Lerp(speed,MINspeed,acceleration);
		}


		//Input Left and Right Direction, Input Left and Right (Setting car direction)
		if(Input.GetAxis("Horizontal")>0)
		{
			front_left.transform.Rotate(Vector3.up	 * turning);
			front_right.transform.Rotate(Vector3.up	 * turning);
		}

		if(Input.GetAxis("Horizontal")<0)
		{
			front_left.transform.Rotate(-Vector3.up	 * turning);
			front_right.transform.Rotate(-Vector3.up	 * turning);
		}

		//Brake function- if holding space= float speed will be reLerp to the zero (Lerp function)
		if(Input.GetKey(KeyCode.Space))
		{
			speed = Mathf.Lerp(speed,0,brake);
		}



	}

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width - 500,0,1,1),"SPEED: " + speed + "/10",style);
	}
}
