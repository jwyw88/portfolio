<?php
/* Simple interactive map
 *  q 				- quit
 *  p 				- print places on map
 *  a x y name 		- adds place to map
 *  d index1 index2 - get distance between places
 */

include 'readline.php'; // you don't need this if you are using *nix

print("Welcome to our map!\n");

$xc=array();
$yc=array();
$names=array();



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
		
		$map=array($xc, $yc, $names);
		print("index \t position\t name \n");
		for($i=0; $i<count($names); $i++){
		
			printf("%d \t (%d, %d) \t %s \n", $i, $xc[$i], $yc[$i], $names[$i]);
				
		}
		
	} else if (($nTokens == 4) && ($tokens[0] == 'a')) {
		// TODO: Add place
		$xc[]=$tokens[1];
		$yc[]=$tokens[2];
		$names[]=$tokens[3];
		
		printf("Added %s.\n", $tokens[3]);

	} else if (($nTokens == 3) && ($tokens[0] == 'd')) {
		// TODO: Cacluate distance
		
		$X=$xc[$tokens[1]]-$xc[$tokens[2]];
		$Y=$yc[$tokens[1]]-$yc[$tokens[2]];
		$distance=sqrt(pow($X, 2)+pow($Y, 2));
		
		
		printf("The distance between %d and %d is %0.3f \n", $tokens[1], $tokens[2], $distance);			
	} else {
		print("invalid command\n");
	}
} while(!isset($quit));

print('goodbye.');
?>