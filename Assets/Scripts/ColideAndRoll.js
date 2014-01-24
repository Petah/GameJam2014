#pragma strict
var rollForce:float = 1.0;
var lastCollisionY:int;
var platformGapSize:float = 1.0;
var wallTweak:float = 1.0;
var wallHitVelocity:float = 1.0;
var movingLeft:boolean = true;
var firstHit:boolean = true;
var nudgeVelocity:float = 5;

function Start () {
	lastCollisionY = transform.position.y;
	Debug.Log(lastCollisionY);
}


//Basic collision detection checking for two differently named objects

    function OnCollisionEnter(theCollision : Collision){
     
     
     if(theCollision.gameObject.name == "ForegroundWall"){
      //Hit the floor
      if(firstHit){
      	if (Random.value >= 0.5)
        	{
        		transform.rigidbody.AddForce(Vector3(1,0,0) * rollForce);
        		movingLeft = true;
      		}else{
      			transform.rigidbody.AddForce(Vector3(-1,0,0) * rollForce);
      			movingLeft = false;
      		}
      		firstHit = false;
      	}
      // compare this collision with the last to see if it is a new platform
      var newHit:int = theCollision.transform.position.y;
      if(lastCollisionY > newHit + (platformGapSize/2)){
      //Pick direction
      if (Random.value >= 0.5){
            
            if(movingLeft){
            transform.rigidbody.AddForce(Vector3(1,0,0) * rollForce);
            }else{
            transform.rigidbody.AddForce(Vector3(2,0,0) * rollForce);
            }
            movingLeft = true;
            
        }else{
        	if(movingLeft){
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
        //lastCollisionY = newHit;
        }else{
        
        }
     }
    }



function Update () {

if(-nudgeVelocity < transform.rigidbody.velocity.x && transform.rigidbody.velocity.x < nudgeVelocity && transform.rigidbody.velocity.y == 0 ){

	if (Random.value >= 0.5){

		transform.rigidbody.AddForce(Vector3(-1,0,0) * rollForce);
	}else{
		transform.rigidbody.AddForce(Vector3(1,0,0) * rollForce);
	}
}

}

