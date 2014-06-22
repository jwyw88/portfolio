<?php
include 'Receipt.php';

class ReceiptTest extends PHPUnit_Framework_TestCase {
	
  
   /**
    * Create test receipts that can be used by all the tests
    */
   public function setup() {
      // CASE 1: empty receipt
      $this->empty = new Receipt();
	  

      // CASE 2: simple receipt with exactly one item
      $this->single = new Receipt();
	  
      // TODO: add item to receipt
	  $this->single->addItem('R1',  2,  3,  false);
	  
      // CASE 3: simple receipt with more than one item
      $this->multi = new Receipt();
	  
      // TODO: add items to receipt
	  $this->multi->addItem('R2',  2,  3,  false);
	  $this->multi->addItem('R3',  3,  4,  true);
		

      // CASE 4: complex receipt with at least 4 items that vary ALL parameters
      $this->complex = new Receipt();
      // TODO: add items to receipt
	   $this->complex->addItem('R4',  1,  4,  true);
	   $this->complex->addItem('R5',  2,  5,  false);
	   $this->complex->addItem('R6',  3,  6,  true);
	   $this->complex->addItem('R7',  4,  7,  false);
   }
    
   public function testcalcDiscount() {
      // TODO: test non-zero discount on empty, single, multi and complex receipt
	$this->empty->setDiscount(10);  
	$rv = $this->empty->calcDiscount();
	$this->assertEquals(0, $rv);
	
	$this->single->setDiscount(10); 
	$rv = $this->single->calcDiscount();
	$this->assertEquals(0.60, $rv);
	
	$this->multi->setDiscount(10); 
	$rv = $this->multi->calcDiscount();
	$this->assertEquals(1.80, $rv);	
	
	$this->complex->setDiscount(10); 
	$rv = $this->complex->calcDiscount();
	$this->assertEquals(6.00, $rv);

	
   }
  
   public function testCalcDiscountWhenItsZero() {
      // TODO: test zero discount on empty, single, multi and complex receipt
	$this->empty->setDiscount(0);  
	$rv = $this->empty->calcDiscount();
	$this->assertEquals(0, $rv);
	
	$this->single->setDiscount(0); 
	$rv = $this->single->calcDiscount();
	$this->assertEquals(0, $rv);
	
	$this->multi->setDiscount(0); 
	$rv = $this->multi->calcDiscount();
	$this->assertEquals(0, $rv);	
	
	$this->complex->setDiscount(0); 
	$rv = $this->complex->calcDiscount();
	$this->assertEquals(0, $rv);
   }
    
   public function testCalcSubTotal() {
      // NOTE: sub total is before tax and before discount
      // TODO: test on empty, single, multi and complex receipt
	$rv = $this->empty->calcSubTotal();
	$this->assertEquals(0, $rv);
	
	$rv = $this->single->calcSubTotal();
	$this->assertEquals(6.00, $rv);

	$rv = $this->multi->calcSubTotal();
	$this->assertEquals(18.00, $rv);	

	$rv = $this->complex->calcSubTotal();
	$this->assertEquals(60.00, $rv);	
   }
    
   public function testCalcTax() {
      // NOTE: Tax is 13% 
      // NOTE: don't forget about non-taxable items
      // TODO: test zero discount on empty, single, multi and complex receipt
	$this->empty->setDiscount(0);   
	$rv = $this->empty->calcTax();
	$this->assertEquals(0, $rv);
	
	$this->single->setDiscount(0); 
	$rv = $this->single->calcTax();
	$this->assertEquals(0, $rv);
	
	$this->multi->setDiscount(0); 
	$rv = $this->multi->calcTax();
	$this->assertEquals(1.56, $rv);
	
	$this->complex->setDiscount(0); 
	$rv = $this->complex->calcTax();
	$this->assertEquals(2.86, $rv);
   }
    
   public function testCalcTaxWithDiscount() {
      // NOTE: Tax is 13% 
      // NOTE: Tax is applied after the discount 
      // TODO: test non-zero discount on empty, single, multi and complex receipt 
	$this->empty->setDiscount(10);  
	$rv = $this->empty->calcTax();
	$this->assertEquals(0, $rv);
	
	$this->single->setDiscount(10);
	$rv = $this->single->calcTax();
	$this->assertEquals(0, $rv);

	$this->multi->setDiscount(10); 
	$rv = $this->multi->calcTax();
	$this->assertEquals(1.40, $rv);	

	$this->complex->setDiscount(10);
	$rv = $this->complex->calcTax();
	$this->assertEquals(2.57, $rv);
   }
    
   public function testCalcTotal() {
      // TODO: test zero discount on empty, single, multi and complex receipt
	$this->empty->setDiscount(0);  
	$rv = $this->empty->calcTotal();
	$this->assertEquals(0, $rv);
	
	$this->single->setDiscount(0);  
	$rv = $this->single->calcTotal();
	$this->assertEquals(6.00, $rv);

	$this->multi->setDiscount(0);  
	$rv = $this->multi->calcTotal();
	$this->assertEquals(19.56, $rv);	

	$this->complex->setDiscount(0);  
	$rv = $this->complex->calcTotal();
	$this->assertEquals(62.86, $rv);
   }
    
   public function testCalcTotalWithDiscount() {
      // TODO: test non-zero discount on empty, single, multi and complex receipt
	$this->empty->setDiscount(10);  
	$rv = $this->empty->calcTotal();
	$this->assertEquals(0, $rv);
	
	$this->single->setDiscount(10); 
	$rv = $this->single->calcTotal();
	$this->assertEquals(5.40, $rv);
	
	$this->multi->setDiscount(10); 
	$rv = $this->multi->calcTotal();
	$this->assertEquals(17.60, $rv);
	
	$this->complex->setDiscount(10); 
	$rv = $this->complex->calcTotal();
	$this->assertEquals(56.57, $rv);
   }
}