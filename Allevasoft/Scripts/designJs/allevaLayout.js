// JavaScript Document

//<!--Starts Script for Custom Scrollbar-->
(function($){
        	$(window).load(function(){
            
				$(".scroll").mCustomScrollbar({
    advanced:{updateOnContentResize: true}
    //advanced:{autoExpandHorizontalScroll:true}
});
});
})(jQuery);


//<!--Ends Script for Side Bar and CUstom Scrollbar-->



//<!--Starts Script for Message and Notification icons Tabs , Left Side Navigation and Script inside the Message and Notification icons tabs -->

    $(document).ready(function(){
		
		
		 var abc = false;
			 	$(document.body).click(function(){
					if(abc == true)
{
						abc = false;
}
else
{
					$("#notification_msg1").css("display","none");
}
});
				
    //For the Script of Notifications and message close on click on wrap div 
				$(".wrap").click(function(){
					if(abc == true)
{
						abc = false;
}
else
{
					$("#notification_msg1").css("display","none");
}
});
				
				
	
				$(".dLabel2bell").click(function(){
					abc = true;
					//e.stopPropagation();
});
				$(".dLabel2envelope").click(function(){
					abc = true;
					//e.stopPropagation();
});
				$("#notification_msg1").click(function(){
					abc = true;
					e.stopPropagation();
});

		
		
		  $('#verticalTab').easyResponsiveTabs({
    type: 'vertical',
    width: 'auto',
    fit: true
});
		$('[data-toggle="tooltip"]').tooltip();
		
		//<!--For Custom Select Dropdown		-->
		//$('select').selectric();
		
		//<!-- For Left Navigation Sliding-->
		$(".nav-togle-btn").click(function(){
$(".main-nav").toggleClass("toggle-menu");
//<!--$(".navbar-fixed-top").toggleClass("slideNav")		-->
$(".wrap").toggleClass("toggle-side");	
});	

//<!-- For + plus at the bottom right section-->
	$('.show_hide').mouseover(function () {
        $("#advertisemnt-add").show();
});
	 $('.show_hide').mouseout(function () {
        $("#advertisemnt-add").hide();
});
	 $('#advertisemnt-add').mouseover(function () {
        $(this).show();
});
	$('#advertisemnt-add').mouseout(function () {
        $(this).hide();
});
	
	
	 $(window).scroll(function () {

                    if ($(this).scrollTop() > 120) {
    //$('#back-top').fadeIn();
						 $('footer').css('bottom','0px');
} else {
                        $('footer').css('bottom','-50px');
}
});
				
				
    //+ icon coding starts here
				$('.floatingContainer').hover(function(){
					
    //$('.subActionButton').addClass('display');
}, function(){
  $('.subActionButton').removeClass('display');
  $('.actionButton').removeClass('open');
});
$('.subActionButton').hover(function(){
  $(this).find('.floatingText').addClass('show');
}, function(){
  $(this).find('.floatingText').removeClass('show');
});

$('.actionButton').hover(function(){
  $(this).addClass('open');
  $(this).find('.floatingText').addClass('show');
  $('.subActionButton').addClass('display');
}, function(){
  $(this).find('.floatingText').removeClass('show');
});

$('.floatingContainer').mouseover(function(){
	$(this).css('z-index','99');

$('.addbtns-viewbtns').css('z-index','9999');
$('.referraltop .headingbar .selectric-wrapper').css('z-index','9999');
$('.minimize-reflist').css('z-index','9999');
$('.editbtn' ).css('z-index','9999');
});

$('.floatingContainer').mouseout(function(){
$(this).css('z-index','99');

$('.addbtns-viewbtns').css('z-index','999');
$('.referraltop .headingbar .selectric-wrapper').css('z-index','999');
$('.minimize-reflist').css('z-index','999');
$('.editbtn' ).css('z-index','999');
});

$('.actionButton').mouseover(function(){
	$(this).css('line-height','40px')
});
$('.actionButton').mouseout(function(){
	$(this).css('line-height','40px')
});
    //+ icon coding ends here
	
	
    //$('.nav-togle-btn').click(function(){
    //		alert($('body .main-nav').find('.toggle-menu').length);
    //			if($('body .main-nav').hasClass('.toggle-menu')>0)
    //			{
    //				 alert(1);
    //				
    //				}
    //		})
	
	
	//<!-- For Tabs Inside the Notification and Message Icons at the top right-->
 		$('.tabs-basic li:first-child').addClass('active');
		$('.content_outer .content').hide();
		$('.content_outer .content:first-child').show();
		$('.tabs-basic li').click(function(){
			$('.tabs-basic li').removeClass('active');
			$(this).addClass('active');
			var divid = $(this).find('a').attr('href');
			$('.content_outer .content').hide();
			$(divid).fadeIn(500);
			return false;
});
		
	
		//<!-- For Left Navigation submenu as dropdown and their respective + icon changes-->
		$('.haschild-submenu').click(function(){
				$(this).find('ul').toggle('100', function () {
					if($(this).is(':hidden')) {
						$(this).closest('.haschild-submenu').find('font').html('<i class="fa fa-angle-right" aria-hidden="true"></i>');
} else {
						$(this).closest('.haschild-submenu').find('font').html('<i class="fa fa-angle-down" aria-hidden="true"></i>');
}
});
				
				$( ".haschild-submenu" ).not(this).find('ul').hide();
				$( ".haschild-submenu" ).not(this).find('font').html('<i class="fa fa-angle-right" aria-hidden="true"></i>');
});
			


		//<!-- For Left Navigation submenu in mobile -->

			 if($(window).width() >= 720) {
				
		$(document).on('mouseover', '.toggle-menu li.haschild-submenu', function() {
			$(this).find('ul').css('display','block');
});
		
		$('.toggle-menu li.haschild-submenu ul').mouseover(function () {
        $(this).show();
});
		$('toggle-menu li.haschild-submenu ul').mouseout(function () {
			$(this).show();
});
		
		$(document).on('mouseout', '.toggle-menu li.haschild-submenu', function() {
			$(this).find('ul').css('display','none');
});  
		
		$(".fa-bars").click(function(){
    //alert(IsOpen + "2");
    //IsOpen = true;
					if(IsOpen == true)
{
						$(".fa-bars").css("color","#a4a1a1")
						IsOpen = false;
    //alert('g');
}
else
{
						$(".fa-bars").css("color","#f47248")
						IsOpen = true;						
    //alert('o');
}					
					e.stopPropagation();
});
		
}
		// <!-- For Left Navigation submenu close when click outside in the body anywhere -->
else {
			    var IsOpen = false;
			 	$(document.body).click(function(){
    //alert(IsOpen + "1");
					if(IsOpen == true)
{
						$(".fa-bars").css("color","#a4a1a1")
						
					$(".main-nav").removeClass("toggle-menu");
					$(".wrap").removeClass("toggle-side");
    //alert('g');
}
else
{
    //$(".fa-bars").css("color","orange")
												
    //alert('o');
}
					if(IsOpen == true)
{
						IsOpen = false;
}
else
{
    //alert(IsOpen);
						IsOpen = true;
    //$(".main-nav").removeClass("toggle-menu");
    //$(".wrap").removeClass("toggle-side");
}
					
					$(".main-nav").click(function(){
					IsOpen = false;
					e.stopPropagation();
});
					
});
	
				$(".fa-bars").click(function(){
    //alert(IsOpen + "2");
    //IsOpen = true;
					if(IsOpen == true)
{
						$(".fa-bars").css("color","#a4a1a1")
						$(".main-nav").addClass("toggle-menu");
					$(".wrap").addClass("toggle-side");
    //alert('g');
}
else
{
						$(".fa-bars").css("color","#f47248")
						$(".main-nav").removeClass("toggle-menu");
					$(".wrap").removeClass("toggle-side");
    //alert('o');
}
					e.stopPropagation();
});
				
				
				
				$(".leftnav").click(function(){
					IsOpen = true;
					e.stopPropagation();
});

}
			 

	
});
	
	
	
	
		
	
//<!-- For Notification and Message Tabbing active when click on the respective icon -->
function funNotificationSideMenu(id, classvalue)
{
    //alert(classvalue)
    $("#notification_msg1").show();
    if(classvalue == 'dLabel2bell')
    {
        $("#notification_msg1").find('._notificationTab').removeClass('active');
        $("#notification_msg1").find('#divBell').addClass('active');
        $("#notification_msg1").find('#divBell').click();
    }
    else
    {
        $("#notification_msg1").find('._notificationTab').removeClass('active');
        $("#notification_msg1").find('#divMsg').addClass('active');
        $("#notification_msg1").find('#divMsg').click();
    }
}


//<!--Ends Script for Message and Notification icons Tabs , Left Side Navigation and Script inside the Message and Notification icons tabs -->

	function FunEditMode(e){
		$(e).parent().parent().parent().parent().find("#divviewmode").hide();
		$(e).parent().parent().parent().parent().find("#diveditmode").show();
}
	
	function FunViewMode(e){
		$(e).parent().parent().parent().parent().find("#diveditmode").hide();
		$(e).parent().parent().parent().parent().find("#divviewmode").show();
}
	
	
	
	