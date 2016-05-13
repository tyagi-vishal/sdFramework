'use strict';

//Controller implementation
//inject allevaApp to controller
allevaApp.controller('layoutCtrl', function ($scope, $http, allevaService) {
    $scope.menus = [];
    $scope.fnLoadMenus = function () {
        var Url = $getUrl.pageHome + $getMethod.Layout_Menus;
        var lstMenus = allevaService.getDatas(Url);
        lstMenus.then(function (response) {
            $scope.lstMenus = true;
            var jsonMenus = [], jsonSubMenus = [], MenuId = 0;
            //Menu Json convert part start
            $.each(response.data, function (item, value) {
                if (value.ISSubMenu != '0') {
                    //Load Sub Menus Json Object
                    jsonSubMenus.push({
                        subMenuName: value.SubMenuName,
                        url: value.SubMenuUrl
                    });
                    if (value.NxtMenuId != value.MenuID) {
                        jsonMenus.push({
                            menuName: value.MenuName,
                            iconClass: value.IconClass,
                            url: "#",
                            subMenus: jsonSubMenus
                        });
                        jsonSubMenus = [];
                    }
                }
                else {
                    //Load Menus Json Object
                    jsonMenus.push({
                        menuName: value.MenuName,
                        iconClass: value.IconClass,
                        url: value.MenuUrl,
                        subMenus: jsonSubMenus
                    });
                    jsonSubMenus = [];
                }
            });
            //Menu Json convert part end
            $scope.menus = jsonMenus;

        }, function () {
            alert('Error in getting records');
        });
    }

})
    .animation('.slide', function () {
    var NG_HIDE_CLASS = 'ng-hide';
    return {
        beforeAddClass: function (element, className, done) {
            if (className === NG_HIDE_CLASS) {
                element.slideUp(done);
            }
        },
        removeClass: function (element, className, done) {
            if (className === NG_HIDE_CLASS) {
                element.hide().slideDown(done);
            }
        }
    }
});
