#pragma strict
var rollForce:float = 1.0;
var lastCollisionY:int;
var platformGapSize:float = 1.0;
var wallTweak:float = 1.0;
var wallHitVelocity:float = 1.0;
var movingLeft:boolean = true;
var firstHit:boolean = true;

function Start () {
	lastCollisionY = transform.position.y + 50;
}


//Basic collision detection checking for two differently named objects

    function OnCollisionEnter(theCollision : Collision){
     
     
     if(theCollision.gameObject.name == "ForegroundWall"){
      //Hit the floor
      
      // compare this collision with the last to see if it is a new platform
      var newHit:int = theCollision.transform.position.y;
      if(lastCollisionY > newHit + platformGapSize){
      //Pick direction
      if (Random.value >= 0.5)
        {
            if(firstHit){
            transform.rigidbody.AddForce(Vector3(1,0,0) * rollForce);
            firstHit = false;
            }else if(movingLeft){
            transform.rigidbody.AddForce(Vector3(1,0,0) * rollForce);
            }else{
            transform.rigidbody.AddForce(Vector3(2,0,0) * rollForce);
            }
            movingLeft = true;
            
        }else{
        	if(firstHit){
            transform.rigidbody.AddForce(Vector3(1,0,0) * rollForce);
            firstHit = false;
        	}else if(movingLeft){
        	transform.rigidbody.AddForce(Vector3(-2,0,0) * rollForce);
        	}else{
        	transform.rigidbody.AddForce(Vector3(-1,0,0) * rollForce);
        	}
        	movingLeft = false;
        	
        }
        lastCollisionY = newHit;
        
        
        }else if(lastCollisionY < newHit + wallTweak){
        	if(movingLeft){
        		transform.rigidbody.AddForce(Vector3(-2,0,0) * rollForce);
        	}else{
        		transform.rigidbody.AddForce(Vector3(2,0,0) * rollForce);
        	}
        lastCollisionY = newHit;
        }
     }
    }



function Update () {

}