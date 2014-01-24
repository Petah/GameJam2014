#pragma strict
var cameraFocus:Transform;
var dropOffset:float = 1.0;
function Update () {
if(cameraFocus.position.y > transform.position.y + dropOffset){
Destroy(gameObject);
}
}

function OnBecameInvisible () {

}