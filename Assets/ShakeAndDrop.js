#pragma strict
var shake:boolean = false;
var toggler:boolean = false;
var shakeIntensity:float = 1.0;
var shakeMax:float = 1.5;
var shakeTimer: float = 40; // duration time in seconds
var finishedShake:boolean = false;
function Start () {

}

function Update () {
	if (shake) {
		if(toggler){
			transform.position.y += 1*shakeIntensity;
		}else{
			transform.position.y -= 1*shakeIntensity;
		}
		toggler = !toggler;
	  	shakeTimer -= Time.deltaTime;
	  	if (shakeTimer < 0){
	  		shake = false;
	  		finishedShake = true;
	  	}
	} 
	if (finishedShake) {
	    // Time up. stop shake and drop
	    gameObject.rigidbody.useGravity = true;
	    gameObject.rigidbody.isKinematic = false;
	}
}

function OnTriggerEnter (other : Collider) {
     if(other.gameObject.tag == "Player"){
     	//start timer
     	shake = true;
     }
     
}