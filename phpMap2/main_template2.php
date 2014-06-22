<?php
/* Simple interactive map
 *  q 				- quit
 *  p 				- print places on map
 *  a x y name 		- adds place to map
 *  d index1 index2 - get distance between places
 */

include 'readline.php'; // you don't need this if you are using *nix
include 'map.php';

print("Welcome to our map!\n");
$map = new Map();
$P1 = new Map();
$P2 = new Map();
do {
	print ('>');
	$input = readline('>');
	$tokens = explode(' ', $input);
	$nTokens = count($tokens);

	if (($nTokens == 1) && ($tokens[0] == 'q')) {
		$quit = true;
	} else if (($nTokens == 1) && ($tokens[0] == 'p')) {
		print("Places:\n");
		
		// TODO: Print places
		$map->printPlaces();
		
	} else if (($nTokens == 4) && ($tokens[0] == 'a')) {
		// TODO: Add place
		
		$map->addPlaces($tokens[1],$tokens[2],$tokens[3]);
		printf("Added %s.\n", $tokens[3]);
	} else if (($nTokens == 3) && ($tokens[0] == 'd')) {
		// TODO: Cacluate distance
		
		$distance = $map->getDistance($tokens[1], $tokens[2]);
		printf("The distance between %d and %d is %0.3f \n", $tokens[1], $tokens[2], $distance);			
	} else {
		print("invalid command\n");
	}
} while(!isset($quit));

print('goodbye.');

?>