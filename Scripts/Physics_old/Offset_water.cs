using UnityEngine;
using System.Collections;

public class Offset_water : MonoBehaviour {

	public float offset;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		offset+=1 * Time.deltaTime;

		transform.renderer.material.mainTextureOffset = new Vector2(0,offset);
	
	}
}
