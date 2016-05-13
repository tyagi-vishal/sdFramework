allevaApp.service("allevaService", function ($http) {
    // get Data
    this.getDatas = function (pageUrl) {
        return $http.get(pageUrl);
    };

    // get Data with params
    this.getData = function (pageUrl, pageParam) {
        var response = $http({
            method: "post",
            url: pageUrl,
            data: JSON.stringify(pageParam),
            dataType: "json"
        });
        return response;
    }

    // Update Data 
    this.updateData = function (pageUrl, pageParam) {
        var response = $http({
            method: "post",
            url: pageUrl,
            data: JSON.stringify(pageParam),
            dataType: "json"
        });
        return response;
    }

    // Add Data 
    this.AddData = function (pageUrl, pageParam) {
        var response = $http({
            method: "post",
            url: pageUrl,
            data: JSON.stringify(pageParam),
            dataType: "json"
        });
        return response;
    }

    // Delete Data 
    this.AddData = function (pageUrl, pageParam) {
        var response = $http({
            method: "post",
            url: pageUrl,
            data: JSON.stringify(pageParam),
            dataType: "json"
        });
        return response;
    }
  
});