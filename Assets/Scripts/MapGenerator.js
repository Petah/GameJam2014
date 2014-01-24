#pragma strict
private var currentY:float;
var startY:float = 1.0;
var wallPrefab:Transform;
var stopOffsetY:float = 7.0;
var platformHeight:int = 4;
var minPlatformSize:int = 2;
var maxPlatformSize:int = 6;
var minGapSize:int = 2;
var maxGapSize:int = 6;
var minNoOfPlatforms:int = 1;
var maxNoOfPlatforms:int = 3;
var nextSize:float = 0;

function Start () {

currentY = startY;

}

function Update () {

if(currentY > transform.position.y + stopOffsetY){

}else{

var instanceWall1 =  Instantiate(wallPrefab, Vector3(9,currentY,0), Quaternion.identity);
var instanceWall2 =  Instantiate(wallPrefab, Vector3(-9,currentY,0), Quaternion.identity);
currentY++;

if(currentY % platformHeight == 0){
var gap:boolean;
if (Random.value >= 0.5){
gap = true;
}else{
gap = false;
}


//if (Random.value >= 0.5)
//        {
            var curCube:int = 0;
            var totCubes:int = 19;
            while(totCubes > 0){
            
            if(gap){
            
            for(var i:int = (Random.value * (maxGapSize - minGapSize)) + minGapSize; i > 0; i--){
            	if(totCubes > 0){
            		//var instancePlatform1 =  Instantiate(wallPrefab, Vector3(totCubes - 10,currentY,0), Quaternion.identity);
            	}
            	totCubes--;
            	}
            	gap = !gap;
            
            }else{
            
            for(var j:int = (Random.value * (maxPlatformSize - minPlatformSize)) + minPlatformSize; j > 0; j--){
            	if(totCubes > 0){
            		var instancePlatform1 =  Instantiate(wallPrefab, Vector3(totCubes - 10,currentY,0), Quaternion.identity);
            	}
            	totCubes--;
            	}
            	gap = !gap;
            
            	}
            }

		}
	}
}
