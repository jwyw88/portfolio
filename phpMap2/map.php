<?php

class Place{

//properties
private $x = 0;
private $y = 0;
private $name = "place name";

				
//actions
public function getX(){
	return $this->x;
}

public function getY(){
	return $this->y;
}

public function getName(){
	return $this->name;

}

public function calcDistanceTo($P) {
	
	$P1 = $this->getX()-$P->getX();
	$P2 = $this->getY()-$P->getY();
	$d = sqrt(pow($P1, 2)+pow($P2, 2));
	return $d;
}

public function __construct($x, $y, $name){
	$this->x = $x;
	$this->y = $y;
	$this->name = $name;
}
}



Class Map{

//properties
private $P = array();


//actions
public function addPlaces($x, $y, $name){
	$this->P[] = new Place($x, $y, $name);
}

public function printPlaces(){
	
	print("index \t position\t name \n");
	for($i=0; $i<count($this->P); $i++){
		$x = $this->P[$i]->getX(); 
		$y = $this->P[$i]->getY();
		$name = $this->P[$i]->getName();
		printf("%d \t (%d, %d) \t %s \n", $i, $x, $y, $name);
	}	
}

public function getDistance($i1, $i2){
	$P1=$this->P[$i1];
	$P2=$this->P[$i2];
	$d=$P1->calcDistanceTo($P2);
	return $d;
	
}
}



?>