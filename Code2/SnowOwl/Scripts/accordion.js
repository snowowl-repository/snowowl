;(function($){
	$.fn.msAccordion = function(options) {
		options = $.extend({
			currentDiv:'1',
			previousDiv:'',
			vertical: false,
			defaultid:0,
			currentcounter:0,
			intervalid:0,
			autodelay:0,
			event:"click",
			alldivs_array:new Array()
	}, options);
	$(this).addClass("accordianWrapper");
	var elementid = $(this).attr("id");
	var allDivs = this.children();
	if(options.autodelay>0)  {
		$("#"+ elementid +" > .accordian-item").bind("mouseenter", function(){
			pause();
		});
		$("#"+ elementid +" > .accordian-item").bind("mouseleave", function(){
			startPlay();
		});
	}
	//set ids
	allDivs.each(function(current) {
		var iCurrent = current;
		var sTitleID = elementid+"_msTitle_"+(iCurrent);
		var sContentID = sTitleID+"_msContent_"+(iCurrent);
		var currentDiv = allDivs[iCurrent];
		var totalChild = currentDiv.childNodes.length;
		var titleDiv = $(currentDiv).find(".accordian-item-tile");
		titleDiv.attr("id", sTitleID);
		var contentDiv = $(currentDiv).find(".accordian-item-content");
		contentDiv.attr("id", sContentID);
		options.alldivs_array.push(sTitleID);
		$("#"+sTitleID).bind(options.event, function(){pause();openMe(sTitleID);});
	});
	
	//make vertical
	if(options.vertical) {makeVertical();};
	//open default
	openMe(elementid+"_msTitle_"+options.defaultid);
	if(options.autodelay>0) {startPlay();};
	//alert(allDivs.length);
	function openMe(id) {
		var sTitleID = id;
		var iCurrent = sTitleID.split("_")[sTitleID.split("_").length-1];
		options.currentcounter = iCurrent;
		var sContentID = id+"_msContent_"+iCurrent;
		if($("#"+sContentID).css("display")=="none") {
			if(options.previousDiv!="") {
				closeMe(options.previousDiv);
			};
			if(options.vertical) {
				$("#"+sContentID).slideDown();
			} else {
            $("#"+sContentID).parent().find('.accordian-item-tile > img').attr('src','/Content/images/roundbutton.minus.24x24.png');
				$("#"+sContentID).toggle();
			}
			options.currentDiv = sContentID;
			options.previousDiv = options.currentDiv;
		};
	};
	function closeMe(div) {
		if(options.vertical) {
			$("#"+div).slideUp();
		} else {
			$("#"+div).toggle();
            $("#"+div).parent().find('.accordian-item-tile > img').attr('src','/Content/images/roundbutton.plus.24x24.png');
		};
	};	
	function makeVertical() {
		$("#"+elementid +" > .accordian-item").css({display:"block", float:"none", clear:"both"});
		$("#"+elementid +" > .accordian-item > .accordian-item-tile").css({display:"block", float:"none", clear:"both"});
		$("#"+elementid +" > .accordian-item > .accordian-item-content").css({clear:"both"});
	};
	function startPlay() {
		options.intervalid = window.setInterval(play, options.autodelay*1000);
	};
	function play() {
		var sTitleId = options.alldivs_array[options.currentcounter];
		openMe(sTitleId);
		options.currentcounter++;
		if(options.currentcounter==options.alldivs_array.length) options.currentcounter = 0;
	};
	function pause() {
		window.clearInterval(options.intervalid);
	};
}
})(jQuery);
