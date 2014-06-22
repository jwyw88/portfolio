<?php
require_once 'Product.php';

// Test Product

$ball  = new Product('ball', 'red and bouncy', 12, 1.99);
$bat  = new Product('baseball bat', '', 2, 5.99);

print($ball->getDescription() . "\n");  	// Ball - red and bouncy
print($bat->getDescription() . "\n");  	// Bat

print($ball->calcCost(2) . "\n");  	// $3.98
print($bat->calcCost(1) . "\n");  	// $5.99
print($bat->calcCost(-3) . "\n");  	// $0.00

print($ball->isAvailable(2) . "\n"); 	// yes
print($bat->isAvailable(1) . "\n"); 	// yes
print($bat->isAvailable(3) . "\n"); 	// no

// Test Book
$book = new Book('Oz', 'A tornado ...', 4, 12.49, 'F. Baum', 223);

print($book->getDescription() . "\n");  	// Oz by F. Baum (223 p.) - A tornado ...
print($book->calcCost(2) . "\n");  			// $24.98
print($book->isAvailable(3) . "\n"); 		// yes
print($book->isAvailable(6) . "\n"); 		// no

// Test Movie
$movie = new Movie('X', 'Malcolm X ...', 1, 9.99, true);

print($movie->getDescription() . "\n");  	// X - Malcolm X ...

print($movie->calcCost(1) . "\n");  		// $9.99
print($movie->calcCost(-1) . "\n");  		// $7.49 (25% discount for downloads)

print($movie->isAvailable(1) . "\n"); 		// yes
print($movie->isAvailable(2) . "\n"); 		// no
print($movie->isAvailable(-1) . "\n"); 	// yes