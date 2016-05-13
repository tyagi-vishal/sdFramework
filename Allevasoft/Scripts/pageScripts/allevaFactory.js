/* App Factory Implementaion*/
allevaApp.factory('allevaFactory', function ($http) {
    return {
        GetData: function (type, url, params, header) {
            return $http({
                method: type,
                url: url,
                data: params
            })
        }
    }
})
