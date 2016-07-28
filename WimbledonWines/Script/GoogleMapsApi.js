﻿var app = angular.model('myApp', ['ui6mapgoogle-maps']);
app.controller('mapController', function($scope,$http)
{
    //this is for default map focus when load first time
    $scope.map = { center: { latitude: 51.43381195, longitude: -0.19906282 }, zoom: 16 }


    $scope.markers = [];
    $scope.locations = [];

    //Populate all locations

    $http.get('/home/GetAllLocation').then(function (data) {

        $scope.locations = data.data;

    }, function () {
        alert('Error');
    });

    //get marker info
    $scope.ShowLocation = function (locationID) {
        $http.get('/home/GetMarkerInfo', {
            params: {
                locationID: locationID
            }

        }).then(function (data) {
            //clear markers
            $scope.markers = [];
            $scope.markers.push({
                id: data.data.LocationID,
                coords: { latitude: data.data.Lat, longitude: data.data.Long },
                title: data.data.title,
                address: data.data.Address,
                image: data.data.ImagePath

            });

            //set map focus to center
            $scope.map.center.latitude = data.data.Lat;
            $scope.map.center.longitude = data.data.Long;

        }, function () {

            alert('Error');
        });




    }

    //Show / Hide marker on map

    $scope.windowOptions = {
        show: true
    };
    

});