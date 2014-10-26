using UnityEngine;
using System.Collections;

public class ActorInstanciator : MonoBehaviour {

    public static ActorInstanciator Instance;

    public GameObject TestCar_Item;

    public GameObject Instanciate_TestCar() 
    {
        GameObject GO= Instantiate(TestCar_Item) as GameObject;
        return GO;
    }
	// Use this for initialization
	void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
