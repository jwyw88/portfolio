/*
	OCMC 2013 Website
	- create a dynamic effect of move in and out banner texts
	
	author:Ge YU
	date:June 4, 2013
	filename:bnTxtControls.js
*/
/*Functions
   addEvent(object, evName, fnName, cap)
      Run the function fnName when the event evName occurs in object.
   closeObject(objID)
      Sets the display style of the object with id, objID, to "none"
      hiding it from the user.
   showObject(objID)
      Sets the display style of the object with id, objID, to "block"
   setOpacity(objID, value)  
      Set the opacity of the document object with the id, objID to value.
   fadeIn(objID, maxOpacity, fadeTime)
      Fades in an object with the id, objID up to a maximum opacity of 
      maxOpacity over an interval of fadeTime seconds.
   fadeOut(objID, maxOpacity, fadeTime)
      Fades out an object with the id, objID from a maximum opacity of 
      maxOpacity down to 0 over an interval of fadeTime seconds.
*/
function addEvent(object, evName, fnName, cap) {
   if (object.attachEvent)
       object.attachEvent("on" + evName, fnName);
   else if (object.addEventListener)
       object.addEventListener(evName, fnName, cap);
}


addEvent(window, "load", setUp, false);
var srcFiles = new Array("images/bnTxt_0.png","images/bnTxt_1.png");
var current = 0;
var txtImgs = new Array();

function setUp() {
	var bannerId = document.getElementById("banner");
	for (i=0; i<srcFiles.length; i++) {
		var img = document.createElement("img");
		img.src = srcFiles[i];
		img.className = "bnTxt";
		img.id = "bnTxt"+i;
		bannerId.appendChild(img);
		txtImgs.push(img);
	}
	txtImgs[current].style.display = "block";
	fadeIn("bnTxt"+current,100,3);
	var change = setInterval("changeTxt()",8000);
//	changeTxt();
}

function changeTxt() {
	fadeOut("bnTxt"+current,100,3);
	closeObject("bnTxt"+current);
	current++;
	if (current == srcFiles.length) current = 0;
	showObject("bnTxt"+current);
	fadeIn("bnTxt"+current,100,3);
}

function closeObject(objID) {
   document.getElementById(objID).style.display = "none";
}

function showObject(objId) {
   document.getElementById(objId).style.display = "block";
}
function setOpacity(objId, value) {
	var object = document.getElementById(objId);
   // Apply the opacity value for IE and non-IE browsers
   object.style.filter = "alpha(opacity = " + value + ")";
   object.style.opacity = value/100;
}
function fadeIn(objId, maxOpacity, fadeTime) {
   // Calculate the interval between opacity changes
   var fadeInt = Math.round(fadeTime*1000)/maxOpacity;
   var delay = 0;
   // Loop up the range of opacity values
   for (var i = 0; i <= maxOpacity; i++) {
      setTimeout("setOpacity('" + objId + "', " + i + ")", delay);
      delay += fadeInt;
   }
}
function fadeOut(objId, maxOpacity, fadeTime) {
   // Calculate the interval between opacity changes
   var fadeInt = Math.round(fadeTime*1000)/maxOpacity;
   var delay = 0;
   // Loop up the range of opacity values
   for (var i = maxOpacity; i >= 0; i--) {
      setTimeout("setOpacity('" + objId + "', " + i + ")", delay);
      delay += fadeInt;
   }
}
