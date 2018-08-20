var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    $scope.Status = true;
    $scope.Test = "Active";

    $scope.GetValue = function () {
        $scope.Status = $scope.Status;
        if ($scope.Status) {
            $scope.Test = "Active";
        }
        else {
            $scope.Test = "InActive";
        }
    }
    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action === "Submit") {
            $scope.Menu = {};
            $scope.Menu.MenuName = $scope.MenuName;
            $scope.Menu.MenuIcon = $scope.MenuIcon;
            $scope.Menu.Status = $scope.Status;
            $http({
                method: "post",
                url: "https://localhost:44369/Account/Insert_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Menu)
            }).then(function (response) {
                toastrMsg(response.data, 'success')
                $scope.GetAllData();
                $scope.MenuName = "";
                $scope.MenuIcon = "";
                $scope.Status = true;
                $scope.Test = "Active";

            })
        } else {
            $scope.Menu = {};
            $scope.Menu.MenuName = $scope.MenuName;
            $scope.Menu.MenuIcon = $scope.MenuIcon;
            $scope.Menu.Status = $scope.Status;
            $scope.Menu.MenuId = document.getElementById("MenuId_").value;
            $http({
                method: "post",
                url: "https://localhost:44369/Account/Update_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Menu)
            }).then(function (response) {
                toastrMsg(response.data, 'success')
                $scope.GetAllData();
                $scope.MenuName = "";
                $scope.MenuIcon = "";
                $scope.Status = true;
                $scope.Test = "Active";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Menu";
            })
        }
    }
    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "https://localhost:44369/Account/Get_AllEmployee"
        }).then(function (response) {
            $scope.menus = response.data;
            //$(window).on("load", function () {                
            //    var table = $('#tblMenu').DataTable();
            //    table
            //        .clear()
            //        .draw();
            //    var count = 1;
            //    $.each(response.data, function (key, item) {
            //        table.row.add([
            //            count,
            //            item.MenuName,
            //            '<i class="' + item.MenuIcon + '"></i>',
            //            item.Status,
            //            "<a href='javascript:void(0)' onclick='CallAng(" + item.MenuId + ")'><i class='far fa-edit fa-2x'></i></a><span style='font-size:xx-large'> | </span><a href='javascript:void(0)' ng-click='DeleteEmp(" + item.MenuId + ")'><i class='fas fa-trash fa-2x'></i></a>",
            //        ]).draw(false);
            //        count++;
            //    });
            //});
        }, function () {
            toastrMsg("Error Occur", 'error')
        })
    };
    $scope.DeleteEmp = function (Emp) {
        $http({
            method: "post",
            url: "https://localhost:44369/Account/Delete_Employee",
            datatype: "json",
            data: JSON.stringify(Emp)
        }).then(function (response) {
            toastrMsg(response.data, 'success')
            $scope.GetAllData();
        })
    };
    $scope.UpdateEmp = function (Emp) {

        document.getElementById("MenuId_").value = Emp.MenuId;
        $scope.MenuName = Emp.MenuName;
        $scope.MenuIcon = Emp.MenuIcon;
        $scope.Status = Emp.Status;
        document.getElementById("btnSave").setAttribute("value", "Update");
        //document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Menu";
    }
})

