angular
.module('AngApp')
.controller('GameCtrl', ['$scope', 'AngAppCoreFactory', GameCtrl]);

function GameCtrl($scope, AngAppCoreFactory) {

    var startGame = function () {

        $scope.N = 4;
        var arr = [];
        for (var i = 0; i < $scope.N; i++) {
            var a = { Id: i, Value: null, Status: null };
            arr.push(a);
        }

        $scope.Number = arr;
        $scope.ShowFinish = false;
        $scope.Stap = 0;

        AngAppCoreFactory.StartGame($scope.N)
        .then(function (r) {
            if (r.data.error) {
                console.log(r.data.error);
            }
            else {
                console.log(r.data.a);
                console.log(r.data.genNumber);
                $scope.a = r.data.a;
            }
        })
        .catch(function (error) {
            console.log(error);
        })
    }

    startGame();

    $scope.BtnCheck = function (arr) {
        AngAppCoreFactory.Check(arr)
        .then(function (r) {
            if (r.data.error) {
                console.log(r.data.error);
            }
            else {
                console.log(r.data.res);
                $scope.Number = r.data.res;
                $scope.Stap = r.data.stap;
                if (r.data.finish) {
                    $scope.ShowFinish = true;
                }
            }
        })
        .catch(function (error) {
            console.log(error);
        })
    }

    $scope.BtnNewGame = function () {
        startGame();
    }

}
