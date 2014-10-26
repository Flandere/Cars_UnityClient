using UnityEngine;
using System.Collections;

public class TANK_MOVEMENT : MonoBehaviour {

	public GameObject MainW_Front_left;
	public GameObject MainW_Front_right;

	public GameObject MainW_Back_left;
	public GameObject MainW_Back_right;

	public float speed;
	public float LEFTDirection;
	public float RIGHTDirection;

	public GameObject cam;
	public GameObject Cam_position_lerper;

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		cam.transform.position = Vector3.Lerp(cam.transform.position,Cam_position_lerper.transform.position,0.05F);
		cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation,Cam_position_lerper.transform.rotation,0.05F);

		if(Input.GetKey(KeyCode.S))
		{
			LEFTDirection = 1;
			RIGHTDirection = 1;

			MainW_Front_left.rigidbody.AddRelativeTorque(transform.up * LEFTDirection * speed);
			MainW_Back_left.rigidbody.AddRelativeTorque(transform.up * LEFTDirection * speed);

			MainW_Front_right.rigidbody.AddRelativeTorque(transform.up * RIGHTDirection * speed);
			MainW_Back_right.rigidbody.AddRelativeTorque(transform.up * RIGHTDirection * speed);
		}
		if(Input.GetKey(KeyCode.W))
		{
			LEFTDirection = -1;
			RIGHTDirection = -1;

			MainW_Front_left.rigidbody.AddRelativeTorque(transform.up * LEFTDirection * speed);
			MainW_Back_left.rigidbody.AddRelativeTorque(transform.up * LEFTDirection * speed);
			
			MainW_Front_right.rigidbody.AddRelativeTorque(transform.up * RIGHTDirection * speed);
			MainW_Back_right.rigidbody.AddRelativeTorque(transform.up * RIGHTDirection * speed);
		}

		if(Input.GetKey(KeyCode.A))
		{
			MainW_Front_left.rigidbody.AddRelativeTorque(transform.up  * speed);
			MainW_Back_left.rigidbody.AddRelativeTorque(transform.up  * speed);
			
			MainW_Front_right.rigidbody.AddRelativeTorque(-transform.up * speed);
			MainW_Back_right.rigidbody.AddRelativeTorque(-transform.up  * speed);
		}
		if(Input.GetKey(KeyCode.D))
		{
			MainW_Front_left.rigidbody.AddRelativeTorque(-transform.up  * speed);
			MainW_Back_left.rigidbody.AddRelativeTorque(-transform.up * speed);
			
			MainW_Front_right.rigidbody.AddRelativeTorque(transform.up  * speed);
			MainW_Back_right.rigidbody.AddRelativeTorque(transform.up  * speed);
		}


	
	}
}
