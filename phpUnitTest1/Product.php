<?php
Class Product{

//properties
protected $name, $description, $quantity, $price;


//actions
public function __construct($name, $description, $quantity, $price){
	$this->name = ucwords(trim($name));
	$this->description = trim($description);
	$this->quantity = max(0, $quantity);
	$this->price = max(0, $price);

}

public function getDescription(){
	if (empty($description)) {
		return sprintf('%s - %s', $this->name, $this->description);
	}else {
		
		return $this->name;
		
		
	}
		
}

public function calcCost($numItems){

	$cost = $this->price * max(0, $numItems);
	return round($cost, 2);
	
}

public function isAvailable($numItems){
	if (($numItems > 0) && ($this->quantity>=$numItems)){
		return 'yes';
		
	}else {
		
		return 'no';
	}	
	
}

}

class Book extends Product{
	
//properties
Protected $author, $numPages;
	
	

//actions	
public function __construct($name, $description, $quantity, $price, $author, $numPages){
	
	parent::__construct($name, $description, $quantity, $price);
	$this->author = trim($author);
	$this->numPages = max(0, $numPages);
}	
	
public function getDescription(){
	
	if (empty($description)){
	return sprintf('%s by %s (%d p.) - %s',
		$this->name, $this->author,
		$this->numPages, $this->description);
											
	}else {
		return printf('%s by %s (%d p.)',
				$this->name, $this->author,
				$this->numPages);
		
	}
}	
}

class Movie extends Product{
	
//properties
const DOWNLOAD_FLAG = -1; //can be passed to represent dl
const DOWNLOAD_PRICE = 0.75; //25% discount	
protected $isDownloadable;
	
//actions	
public function __construct($name, $description, $quantity, $price, $isDownloadable){
	
	parent::__construct($name, $description, $quantity, $price);
	$this->isDownloadable = (bool)$isDownloadable;
	
}

public function isAvailable($numItems=1){
	if ($numItems==self::DOWNLOAD_FLAG){
		return $this->isDownloadable ? 'yes' : 'no';
		
	}else {
		return parent::isAvailable($numItems);
	}	
}

public function calcCost($numItems=1){
	if ($numItems==self::DOWNLOAD_FLAG) {
		return sprintf('$%0.2f', $this->price * self::DOWNLOAD_PRICE);
	}else {
		return parent::calcCost($numItems);
	}
	
}

}





















?>