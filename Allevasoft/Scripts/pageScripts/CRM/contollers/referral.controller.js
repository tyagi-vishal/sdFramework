'use strict';
// Controllers //


allevaApp.controller('referralCtrl', function ($scope, $http, allevaFactory, allevaService, $timeout) {
    var Id = 0;
    $scope.refLists = [];
    $scope.refContactView = false;
    $scope.refContactEdit = true;
    $scope.divCompanyContent = true;
    $scope.divContactContent = false;
    $scope.refCompanyView = false;
    $scope.refCompanyEdit = true;
    $scope.ddlCategory = true;

    $scope.fnLoadDefault = function () {
        fnResetData();
        fnGetGridData('Company');
        fnGetReferralType();
        fnGetReferralCategory(1000);
        fnPopulateCountries();
        fnPopulateStates(1);
        //$timeout(function () {
          //  $('select').selectric();
        //}, 500);
    }

    $scope.fnEdit = function (list) {
        Id = list.Id;
        if (list.ReferralType == 'Company') {
            var lstMenus = function (data, status) {
                fnEditMode();
                $scope.lstContent = data;
            }
            lstMenus = allevaFactory.GetData('Post', $getUrl.pageReferal + $getMethod.refCompById, { Id: list.Id }).success(lstMenus);
        }
        else {
            var lstMenus = function (data, status) {
                fnEditMode();
                $scope.lstContent = data;
            }
            lstMenus = allevaFactory.GetData('Post', $getUrl.pageReferal + $getMethod.refContById, {}).success(lstMenus);fnEditData();
        }
    }

    $scope.fnAdd = function () {

       
        $scope.divGrid = false;
        $scope.divContent = true;
        $scope.divView = false;
        var JsonContent = [{Number: '', Cost: '', Address1: '', Email: '', Address1: '', Address2: '', City: '', Reason: '' }];
        $scope.lstContent = JsonContent;
        $scope.btnSave = "Save";

    }

    $scope.fnView = function (list) {
        Id = list.Id;
        if (list.ReferralType == 'Company') {
            $scope.lstReferalView = [];
            var lstMenus = function (data, status) {
                $scope.lstReferalView = data;
            }
            lstMenus = allevaFactory.GetData('Post', $getUrl.pageReferal + $getMethod.refCompById, { Id: list.Id }).success(lstMenus);
            fnViewMode();
        }
        else {
            $scope.lstReferalView = [];
            var lstMenus = function (data, status) {
                $scope.lstReferalView = data;
            }
            lstMenus = allevaFactory.GetData('Post', $getUrl.pageReferal + $getMethod.refContById, {}).success(lstMenus);
            fnViewMode();
        }
    }

    $scope.fnCancel = function () {
        fnResetData();
    }

    $scope.fnClear = function () {
        var JsonContent = [{Number: '', Cost: '', Address1: '', Email: '', Address1: '', Address2: '', City: '', Reason: '' }];
        $scope.lstContent = JsonContent;
    }

    $scope.fnSaveReferral = function (referralView) {
        if ($scope.btnSave == "Save") {
            allevaFactory.GetData('Post', $getUrl.pageReferal + $getMethod.refCompInsert,referralView).success();
        }
        if ($scope.btnSave == "Update") {
            allevaFactory.GetData('Post', $getUrl.pageReferal + $getMethod.refCompUpdate, referralView).success();
        }
    }

    $scope.fnChangeData = function (referralType) {
        fnGetGridData(referralType);
    }

    $scope.fnChangeLayout = function (CodeName, GlobalCodeId) {
        fnGetReferralCategory(GlobalCodeId);
        if (CodeName == 'Company') {
            $scope.ddlCategory = true;
            $scope.divCompanyContent = true;
            $scope.divContactContent = false;
        } else {
            $scope.ddlCategory = false;
            $scope.divCompanyContent = false;
            $scope.divContactContent = true;
        }
    }

    $scope.fnChangeState = function (CountryId) {
        fnPopulateStates(CountryId);
    }

    function fnGetReferralType() {
        var Url = $getUrl.pageReferal + $getMethod.refType;
        var lstTypeMenus = allevaService.getDatas(Url);
        lstTypeMenus.then(function (response) {
            $scope.referralTypes = response.data;
            $scope.selected_type = $scope.referralTypes[0];
        }, function () {
            alert('Error in getting records');
        });
    }
    function fnGetReferralCategory(GlobalCodeId) {
        var Url = $getUrl.pageReferal + $getMethod.refCategory;
        var lstData = allevaService.getData(Url, { TypeId: GlobalCodeId });
        lstData.then(function (response) {
            $scope.referralCategories = response.data;
            $scope.selected_category = $scope.referralCategories[0];
        }, function () {
            alert('Error in getting records');
        });
    }
    function fnGetGridData(referralType) {
        if (referralType == 'Company') {
            var Url = $getUrl.pageReferal + $getMethod.refCompMenus;
        }
        else
            var Url = $getUrl.pageReferal + $getMethod.refContactMenus;
        var lstMenus = allevaService.getDatas(Url);
        lstMenus.then(function (response) {
            $scope.refLists = response.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    //Used for populate countries
    function fnPopulateCountries() {
        var Url = $getUrl.pageHome + $getMethod.getCountries;
        var lstData = allevaService.getDatas(Url);
        lstData.then(function (response) {
            $scope.countriesList = response.data;
            $scope.selected_country = $scope.countriesList[0];
        }, function () {
            alert('Error in getting records');
        });
    }

    //Used for populate states
    function fnPopulateStates(CountryId) {       
        var Url = $getUrl.pageHome + $getMethod.getStates;
        var lstData = allevaService.getData(Url, { CountryId: CountryId });
        lstData.then(function (response) {
            $scope.statesList = response.data;
            $scope.selected_state = $scope.statesList[0];
        }, function () {
            alert('Error in getting records');
        });
    }

    function fnResetData() {
        $scope.divGrid = true;
        $scope.divContent = false;
        $scope.divView = false;
        $scope.btnSave = "Save";
    }

    function fnViewMode() {
        $scope.divGrid = false;
        $scope.divContent = false;
        $scope.divView = true;
    }

    function fnEditMode() {
        $scope.fnAdd();
        $scope.btnSave = "Update";
    }


});

