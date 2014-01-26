#pragma strict
var graphic:Transform;
var allign:float = -0.5;
var spikeTimer: float = 40; // duration time in seconds
var timing:boolean = false;

function Start () {

}

function Update () {
transform.position = graphic.position + Vector3(0, allign,allign);

if(timing){
	spikeTimer -= Time.deltaTime;
	  	if (spikeTimer < 0){
	  		
	  		// START ANIMATION
	  		// KILL BI-STANDERS
	  		// OPTIONAL EXCESSIVE BLOOD
	  		
	  		
	  		timing = false;
	  	}
	}
}

function OnTriggerEnter (other : Collider) {
     if(other.gameObject.tag == "Player"){
     	//start timer
     	timing = true;
     }
     
}