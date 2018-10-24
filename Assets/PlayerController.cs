using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	//Enumerate lists are nice if you have a set number of states the player will ever be in
	//They're like arrays but you have to access the entries by their names which prevents a lot of coding errors
	private enum States {idle, lp, lp_lp, lp_hp, hp, hp_lp, hp_hp, finisher};	//These are the possible states that the player can be in
	private States myState;	//This is where we store the current state
	private int idle_return_timer=0;

	public Text text;

	void Start () {
		myState = States.idle; //This is how you access an enum state
	}
	void Update () {
		if(myState != States.idle){	//This part just checks to see if you're in the idle state
			idle_return_timer++;
			if(idle_return_timer > 100){//if not you have ~1 second to continue comboing before you get returned to idle
				myState = States.idle;
				text.text = "idle";
				idle_return_timer = 0;
			}
		}
		//if a punch connects the player is moved to the correct state where they have new moves that occur when hitting fire1 or fire2
		//3 successful hits leads to 1 of 8 finishers
		//This is a pretty simple implmentation with just 2 attack buttons
		//You can simplify the code by moving the Fire1 and Fire2 switch statements into a method that takes the button pressed as a parameter
		if(Input.GetButtonDown("Fire1")){
			switch(myState){
				case States.idle:	//from idle
					print("light_punch1");	//throws a normal light punch
					myState = States.lp;	//moves to the state where the lp connected
					text.text = "Light Punch 1";
					break;
				case States.lp:	//from lp state
					print("light_punch2");	//throws a combo animated lp
					myState = States.lp_lp;	//moves to the state where 2 lp's connected
					text.text = "Light Punch 2";
					break;
				case States.lp_lp:	//from lp_lp state
					print("Finisher 1");	//combo finisher
					myState = States.finisher;			//returns to idle after 1 second while finisher animation plays state	
					text.text = "Combo Finisher 1";
					break;
				case States.lp_hp: //from lp_hp state
					print("Finisher 2");	//combo finisher
					myState = States.finisher;			//returns to idle after 1 second while finisher animation plays state
					text.text = "Combo Finisher2";
					break;
				case States.hp: //from hp state
					print("light_punch_after_heavy_punch");	//throws a combo animated lp
					myState = States.hp_lp;	//moves to the state where 2 lp's connected
					text.text = "Light Punch after heavy punch";
					break;			
				case States.hp_lp: //from hp_lp state
					print("Finisher 3");	//combo finisher
					myState = States.finisher;			//returns to idle after 1 second while finisher animation plays state
					text.text = "Combo Finisher 3";
					break;
				case States.hp_hp: //from hp_hp state
					print("Finisher 4");	//combo finisher
					myState = States.finisher;			//returns to idle after 1 second while finisher animation plays state
					text.text = "Combo Finisher 4";
					break;						
			}
		}


		if(Input.GetButtonDown("Fire2")){
			switch(myState){
				case States.idle:	//from idle
					print("heavy_punch1");	//throws a normal heavy punch
					myState = States.hp;	//moves to the state where the lp connected
					text.text = "Heavy Punch 1";
					break;
				case States.lp:	//from lp state
					print("heavy_punch_after_light_punch");	//throws a combo animated hp
					myState = States.lp_hp;	//moves to the state where 2 lp's connected
					text.text = "Heavy punch after light punch";
					break;
				case States.lp_lp:	//from lp_lp state
					print("Finisher 5");	//combo finisher
					myState = States.finisher;			//returns to idle after 1 second while finisher animation plays state
					text.text = "Combo Finisher 5";
					break;
				case States.lp_hp: //from lp_hp state
					print("Finisher 6");	//combo finisher
					myState = States.finisher;			//returns to idle after 1 second while finisher animation plays state
					text.text = "Combo Finisher 6";
					break;
				case States.hp: //from hp state
					print("heavy_punch2");	//throws a combo animated hp
					myState = States.hp_hp;	//moves to the state where 2 lp's connected
					text.text = "heavy punch 2";
					break;			
				case States.hp_lp: //from hp_lp state
					print("Finisher 7");	//combo finisher
					myState = States.finisher;			//returns to idle after 1 second while finisher animation plays state
					text.text = "Combo finisher 7";
					break;
				case States.hp_hp: //from hp_hp state
					print("Finisher 8");	//combo finisher
					myState = States.finisher;		//returns to idle after 1 second while finisher animation plays state
					text.text = "Combo Finisher 8";
					break;						
			}		
		}
	}
}
