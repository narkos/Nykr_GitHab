using UnityEngine;
using System.Collections;

public class EventActivater : Event {
	public GameObject[] objects_Event_Applied; //dessa object är de som kommer stängas on/off
	public bool activeStart = true; //är dessa object aktiverade från start

	private bool isActive;
	// Use this for initialization
	void Start () {
		Initialize ();
	}

	public override void Initialize ()
	{
		base.Initialize ();
		Reset ();
	}
	
	public override void StartEvent(){
		base.StartEvent (); //varför funkar inte cooldown???

		if (isActive == true) {
			isActive = false;
			for (int i = 0; i < objects_Event_Applied.Length; i++) {
				objects_Event_Applied [i].SetActive (false);
			}
		} else {
			isActive = true;
			for (int i = 0; i < objects_Event_Applied.Length; i++) {
				objects_Event_Applied [i].SetActive (true);
			}
		}

	}
	public override void PlayerInteract(){
		StartEvent ();
	}
	public override void Interact(){
		
	}
	
	public override void Reset(){
		isActive = activeStart;

		for (int i = 0; i < objects_Event_Applied.Length; i++) {
			objects_Event_Applied[i].SetActive(activeStart);
		}
	}
}
