'use strict';

// Controllers //

allevaApp.controller('leadController', function ($scope, $http) {
    $scope.leadInfo = {};


    $scope.fnSaveLead = function (leadInfo) {

        $http.post("/Lead/SaveLeadInfo", leadInfo)
  .success(function (response) {
      if (angular.equals(response.Message, "Success")) {
          
          toastr["success"]("User Added", "User Added successfuly.");
      }
      else
          toastr["error"]("Failed", "Some Error Occured");

  })
 .error(function (data) {
     toastr["error"]("Loading", "Loading Error");
 });
    }

    $scope.fnClear = function () {
        var JsonContent = [{ FirstName: '', MiddelName: '', LastName: '', EmailAddress: '', HomeNumber: '', OfficeNumber: '', OtherNumber: '', PostalCode: ''}];
        $scope.leadInfo = JsonContent;
    }
});

toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "0",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}