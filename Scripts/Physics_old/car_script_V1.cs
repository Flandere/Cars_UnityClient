using UnityEngine;
using System.Collections;

public class car_script_V1 : MonoBehaviour {

	//Camera and camera position (Lerp function)
	public GameObject Cam;
	public GameObject Cam_position_lerper;

	//Create a wheels object
	public GameObject front_left;
	public GameObject back_left;
	public GameObject front_right;
	public GameObject back_right;

	//speed, accerelation, speed_meter, brake and turning are basic variations by float
	public float speed;
	public float speed_meter;
	public float brake;
	public float turning;

	//Engine sound by Engine_meter
	public float Engine_meter;

	//Object main body (attacher)
	public GameObject body;



	//----------------------------------------INFORMATION ABOUT THIS CAR SCRIPT V1----------------------------------------------------
	
	/*
	 * WELCOME TO THE CAR SCRIPT V1!
	 * 
	 * Main: This script using 1 model of cars...
	 * CAR_V1
	 * 
	 * 
	 * CAR_V1
	 * 
	 * CAR_V1 is created from 1 Mesh, 3 Mesh Colliders and 4 Wheels
	 * - using Unity 3D Wheel Collider Components: Wheel Collider
	 * 
	 * - You can see in this script variation named Body (means a main body of the car)
	 * 
	 * - You can see in this script variations named Wheels (means a wheels of the car: front_left...)
	 * - Wheels have a Wheel Colliders: Radius- 0.1368, everything else default or based on the Wheel Obj size...
	 * - Wheels are attached/ parented to the Bodys GameObject...
	 * 
	 * - CONTROLS: Movement- WASD, Brake- Space
	 * 
	 * 
	 * CAR_V1 vs CAR_V2 and CAR_V3
	 * 
	 * CAR_V2: His wheels have locked all Angular motions and Motions (means: A low wheels positioning if you can see...)
	 * CAR_V3: His body is attached on the wheels (means: the wheels are limited so the body is rolling on the wheels if you can see...)
     * CAR_V1: His wheels have Wheel Colliders (means: the wheels havent got any Physically acts...)
	 * 
	 * 
	 * 
	 * IF YOU NEED A MORE HELP, TELL ME ON THE MAIL: matt-s-creations-official@centrum.sk or tell me on my official page MATTS CREATIONS
    */


	void Start () {
	
	}
	

	void Update () {

		//Variation body is a main of the sound engine pitch
		body.transform.GetComponent<AudioSource>().pitch = Engine_meter;

		if(speed_meter<=1)
		{
			Engine_meter = 1;
		}
		if(speed_meter<=7 && speed_meter>=1)
		{
			Engine_meter = speed_meter;
		}
		
		if(speed_meter>=7)
		{
			Engine_meter = 7;
		}

		//Input speed_meter ++ or speed_meter --, Input Up and Down
		if(Input.GetAxis("Vertical")<0)
		{
			speed_meter = Mathf.Lerp(speed_meter,10,0.01F);
		}
		
		if(Input.GetAxis("Vertical")>0)
		{
			speed_meter = Mathf.Lerp(speed_meter,-10,0.01F);
		}

		//Centering a mass of object= center of object down (for holding stability)
		transform.rigidbody.centerOfMass = Vector3.down;

		//Cam positioning and rotationing
		Cam.transform.position = Vector3.Lerp(Cam.transform.position,Cam_position_lerper.transform.position,0.05F);
		Cam.transform.rotation = Quaternion.Lerp(Cam.transform.rotation,Cam_position_lerper.transform.rotation,0.05F);


		//Set front wheels as main ROTATERS
		front_left.transform.GetComponent<WheelCollider>().steerAngle = Input.GetAxis("Horizontal") * turning;
		front_right.transform.GetComponent<WheelCollider>().steerAngle =  Input.GetAxis("Horizontal") * turning;
	
		//Set back wheels as main POSITERS
		back_left.transform.GetComponent<WheelCollider>().motorTorque = -Input.GetAxis("Vertical") * speed;
		back_right.transform.GetComponent<WheelCollider>().motorTorque = -Input.GetAxis("Vertical") * speed;

		//Brake variation by back wheels
		if(Input.GetKey(KeyCode.Space))
		{
			back_left.transform.GetComponent<WheelCollider>().brakeTorque = brake;
			back_right.transform.GetComponent<WheelCollider>().brakeTorque = brake;
		}
		else
		{
			back_left.transform.GetComponent<WheelCollider>().brakeTorque =0;
			back_right.transform.GetComponent<WheelCollider>().brakeTorque =0;
		}



	}
}
