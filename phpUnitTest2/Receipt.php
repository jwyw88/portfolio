<?php

	error_reporting(E_ALL);
/**
 * Used to calculate totals for a Cash Register.
 * All cash values are rounded to two decimal places using PHP_ROUND_HALF_EVEN.   
 */
class Receipt {
   const TAX_RATE = 0.13; // i.e. 13% tax
   protected $receiptItems = array(); // 0 = name, 1 = quantity, ...
   protected $discount;
   
   /**
    * Add an item to the recept.
    *
    * $name - describes the item being purchased; must not be empty
    * $quantity - number of items being purchased; must be an integer greater than 0
    * $price - cost per item; must be a float greater than 0
    * $isTaxable - does sales tax have to be paid
    *
    * Rerturns true if the item was added, false if it was not (i.e. bad parameters)
    */
   public function addItem($name, $quantity, $price, $isTaxable) {
      // TODO: implement this function 
	  if($this->receiptItems[] = array($name, $quantity, $price, $isTaxable)){
		  return true;
			} else {
				return false;
			}

	  }
   
    
   /** 
    * Set a discount that is applied to all items in the list.
    *   $percent - integer value between 0 and 100
    */
   public function setDiscount($percent) {
      // TODO: implement this function
		
		$this->discount = $percent / 100;
		
   }
    
   
   /**
    * Returns the 'before tax' and 'before discount' total of all the items in the list.
    */
   public function calcSubTotal() {
      // TODO: implement this function
   		$subTotal = 0;  		
		for($i=0; $i<count($this->receiptItems); $i++){
			$p = $this->receiptItems[$i][2];
			$q = $this->receiptItems[$i][1];
			$subTotal = $subTotal + ($p * $q);
		}
		
		return round($subTotal, 2, PHP_ROUND_HALF_EVEN);
   }
    
   /**
    * Returns the amount of money saved by the discount.  
    * i.e. if the subtotal is $10.00 and the discount is %20, this returns $2.00
    */
	public function calcDiscount() {
      // TODO: implement this function
	  
	  $disTotal = $this->calcSubTotal() * $this->discount;
	  return round($disTotal, 2, PHP_ROUND_HALF_EVEN);
   }
   
   
   /**
    * Returns the total sales tax that must be paid for all the items in the list.
    *  If there is a discount, it is applied BEFORE calculating sales tax.
    *  If items are not taxable, they must not be included when calculating sales tax. 
    */
   public function calcTax() {
      // TODO: implement this function
   		$subTotal = 0;  		
		for($i=0; $i<count($this->receiptItems); $i++){
			if ($this->receiptItems[$i][3]) {  // true means taxable, false means not taxable
				$p = $this->receiptItems[$i][2];
				$q = $this->receiptItems[$i][1];
				$subTotal = $subTotal + ($p * $q);
			}
		}
		// $subtotal only contains taxable items 
		// apply discount to subtotal
		// calculate tax on discounted subtotal
		$calcT = 0;
		$calcT += $subTotal * (1-$this->discount) * self::TAX_RATE;
		return round($calcT, 2, PHP_ROUND_HALF_EVEN);
   }
    
   /**
    * Returns the 'after tax' and 'after discount' total of all the items in the list.
    */
   public function calcTotal() {
      // TODO: implement this function
		$subTotal = $this->calcSubTotal();
		$disTotal = $this->calcDiscount();
		$calcT = $this->calcTax();
		$total = $subTotal - $disTotal + $calcT;
		return round($total, 2, PHP_ROUND_HALF_EVEN);
   
}
}
?>