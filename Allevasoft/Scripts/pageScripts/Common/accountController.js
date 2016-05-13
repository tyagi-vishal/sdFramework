'use strict';

// Controllers //

angular.module('allevaApp', [])
.controller('accountController', function ($scope, $http) {
    $scope.LoginViewModel = {};
    $scope.ForgotPasswordViewModel = {};
    $scope.ResetPasswordViewModel = {};

    $scope.fnLogin = function (LoginViewModel) {

        $http.post("/Account/Authenticate", JSON.stringify({ Modal: LoginViewModel }))
  .success(function (response) {
      if (angular.equals(response.Message, "Success")) {
          window.location.href = "/CRM/CRM/DashBoard";
      }
      else
          toastr["error"]("Login Failed", "Username or Password is wrong.");

  })
 .error(function (data) {
     toastr["error"]("Loading", "Loading Error");
 });


                                                      
    }


    $scope.resetForgetPassword = function (ForgotPasswordViewModel) {

        $http.post("/Account/ForgotPasswordMail", ForgotPasswordViewModel)
        .success(function (response) {
            //alert("in Forget" + response.Message);
            if (angular.equals(response.Message, "Success")) {
                toastr["success"]("Link Sent", "Password reset link is sent to you registered email");

                setTimeout(function () { window.location.href = "/Account/Login"; }, 3000);
            }
            if (angular.equals(response.Message, "NotRegistered")) {
                toastr["error"]("NotRegistered", "You are not registered with us.");
                //alert("Hello");
            }


        })
      .error(function (data) {
          toastr["error"]("Loading", "Loading Error");
      });
    }

    $scope.resetPassword = function (ResetPasswordViewModel) {

        $http.post("/Account/ResetPassword", ResetPasswordViewModel)
        .success(function (response) {
            //alert("in reset"+ response.Message);
            if (angular.equals(response.Message, "Success"))
                setTimeout(function () { window.location.href = "/Account/Login"; }, 3000)
            if (angular.equals(response.Message, "Failed")) {
                toastr["error"]("Link Expired", "This link has already been used to reset the password.");
                setTimeout(function () { window.location.href = "/Account/Login"; }, 2000);
            }

        })
      .error(function (data) {
          toastr["error"]("Loading", "Loading Error");
      });
    }

    $scope.resetPasswordRedirect = function () {
        window.location.href = "/Account/Login";
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