var app = angular.module('channels', ['ui.bootstrap']);

app.controller("channelController", ['$http', '$q', '$log', '$scope', function ($http, $q, $log, $scope) {
    var getChannelList = function () {
        var defer = $q.defer();
        $http.get('/Service/MobileService.svc/Channels').success(function (data) {
            $log.debug("succeeded!");
            defer.resolve(data);
        }).error(function (err) {
            $log.debug("failed!");
            defer.reject('get channel list failed: ' + err);
        });
        return defer.promise;

    };

    

    $scope.getHistory = function (channelId) {
        var t = getHistoryAsync(channelId);
        t.then(function(data) {
            $log.debug(data);
        });
    };

    function getHistoryAsync(channelId) {
        var defer = $q.defer();
        $http.get('/Service/MobileService.svc/Channel/' + channelId + '/History').success(function (data) {
            $log.debug("succeeded!");
            defer.resolve(data);
        }).error(function (err) {
            $log.debug("failed!");
            defer.reject('get channel list failed: ' + err);
        });
        return defer.promise;
    }

    getChannelList().then(function (data) {
        
        //{
        //    "Error":"String content",
        //    "Ok":true,
        //    "Channels":[{
        //        "Id":"String content",
        //        "IsArchived":"String content",
        //        "IsGeneral":"String content",
        //        "Members":["String content"],
        //        "Name":"String content"
        //    }]
        //}
        $scope.Error = data.Error;
        $scope.Ok = data.Ok;
        $scope.ChannelList = data.Channels;
        $log.debug($scope.Error);
        $log.debug($scope.Ok);
        $log.debug($scope.ChannelList);
        //$log.debug(3);
    });


    //$log.debug(3);
    //$log.debug(this.buildNumber);
    //$log.debug(this.changeSets);

    //this.buildNumber = "12345";
    //this.changeSets = ['change1','change2','change3'];

}]);