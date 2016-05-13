'use strict';


allevaApp.controller('dashBoardController', ['$scope', '$http', '$filter', '$log', function ($scope, $http, $filter, $log) {

    $scope.Dashboard = [];
    $scope.Appointments = [];
    var date = new Date();


    $scope.CurrentDateObj = $filter('date')(new Date(), 'yyyy-MM-dd');
    var CurrentDate = $scope.CurrentDateObj;
    var actionParameter = '';

    //$scope.$on('scrollbar.show', function () {
    //    console.log('Scrollbar show');
    //});
    //$scope.$on('scrollbar.hide', function () {
    //    console.log('Scrollbar hide');
    //});


    $scope.fnDashBord = function () {
        actionParameter = 1;//for complete record
       
        $http.post("/CRM/CRM/GetWidgetDetails", { 'actionParameter': actionParameter, 'CurrentDate': CurrentDate })
        .success(function (response) {
            //$("ul.scroll.appointment-widget").mCustomScrollbar();
            $scope.Appointments = response.CRMDetails._Appointments;
            $scope.Dashboard = response;            
           // $("ul.scroll.appointment-widget").mCustomScrollbar(); 
           
        })
        .error(function (data) {
            alert("Error in loading");
        });
   
    }
    $scope.fnRefillAppointments = function (currentDate) {
     
        actionParameter = '';//for Only Appointments
        $http.post("/CRM/CRM/GetWidgetDetails", { 'actionParameter': actionParameter, 'currentDate': currentDate })
        .success(function (response) {
          
            $scope.Appointments = response.CRMDetails._Appointments;
            
            //alert(1);
          //  $("ul.scroll.appointment-widget").mCustomScrollbar();
       
        })
        .error(function (data) {
            alert("Error in loading");
        });
       
    }
    
   // $scope.completeJson = { "Leads": [{ "HotLeads": "29", "LostLeads": "40", "NewLeads": "h" }], "Oppor": [{ "Sales": "29", "Psych": "40", "Billing": "60", "Cost": "70" }] };

   

}]);