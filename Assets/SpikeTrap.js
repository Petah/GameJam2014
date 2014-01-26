#pragma strict
var timer: float = 300; // duration time in seconds
private var triggered:boolean = false;
function Start () {

}





function Update(){
  if(triggered){
  timer -= Time.deltaTime;
  if (timer > 0){
    //spikes down
  } else {
    // Time up. spike'em!
  }

}
}

function OnCollisionEnter(theCollision : Collision){
     
     
     if(theCollision.gameObject.name == "Player"){
     //start timer
     triggered = true;
     }
     
}