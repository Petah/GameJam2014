#pragma strict
var oldX:float;


function Start () {
	oldX = transform.localScale.x;
}

function Update () {
	if(Input.GetButton("left")){
	
	transform.localScale.x = -oldX;
	
	}else if(Input.GetButton("right")){
	
	transform.localScale.x = oldX;
	
	}
}