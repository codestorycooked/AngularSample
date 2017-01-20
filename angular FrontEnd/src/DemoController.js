(function () {
    var demoApp = angular.module("DemoApp");
    demoApp.controller("DemoAppController", ['$http', DemoAppController]);
    function DemoAppController($http) {
        var vm = this;
        var apiURL = "http://localhost:61112/api/";
        vm.postDataModel = {};
        vm.input = "This is world";
        vm.recievedResponse = {};
        vm.postData = function () {
            //alert("Hello World");
            sendData();

        }

        var sendData = function () {
            //  console.log(vm.postDataModel);
            $http.post(apiURL + "values", vm.postDataModel).then(function (data) {
                //Once we save data we get data
                alert("Successfully Posted Data");
                getData();
            }, function (error) {
                console.log(error);
                alert(Json.stringify(error));
            })

        }

        var getData = function getData() {
            $http.get(apiURL + "values").then(function (data) {
                //console.log(data);
                vm.recievedResponse = data;
                console.log(vm.recievedResponse)
                alert("Successfully got data");
            }, function (error) {
                alert(JSON.stringify(error));
            });

        }
    }
})();