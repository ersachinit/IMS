var app = angular.module("myApp", []);
app.controller("ManageMenu", function ($scope, $http) {
    $scope.Status = true;
    $scope.Test = "Active";

    $scope.GetStatus = function () {
        $scope.Status = $scope.Status;
        if ($scope.Status) {
            $scope.Test = "Active";
        }
        else {
            $scope.Test = "InActive";
        }
    }
    $scope.InsertMenu = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action === "Submit") {
            $scope.Menu = {};
            $scope.Menu.MenuName = $scope.MenuName;
            $scope.Menu.MenuIcon = $scope.MenuIcon;
            $scope.Menu.DisplayOrder = $scope.DisplayOrder;
            $scope.Menu.Status = $scope.Status;
            $http({
                method: "post",
                url: "https://localhost:44369/Account/InsertMenu",
                datatype: "json",
                data: JSON.stringify($scope.Menu)
            }).then(function (response) {
                toastrMsg(response.data, 'success')
                $scope.GetAllMenu();
                $scope.MenuName = "";
                $scope.MenuIcon = "";
                $scope.DisplayOrder = "";
                $scope.Status = true;
                $scope.Test = "Active";

            })
        } else {
            $scope.Menu = {};
            $scope.Menu.MenuName = $scope.MenuName;
            $scope.Menu.MenuIcon = $scope.MenuIcon;
            $scope.Menu.DisplayOrder = $scope.DisplayOrder;
            $scope.Menu.Status = $scope.Status;
            $scope.Menu.MenuId = document.getElementById("MenuId_").value;
            $http({
                method: "post",
                url: "https://localhost:44369/Account/UpdateMenu",
                datatype: "json",
                data: JSON.stringify($scope.Menu)
            }).then(function (response) {
                toastrMsg(response.data, 'success')
                $scope.GetAllMenu();
                $scope.MenuName = "";
                $scope.MenuIcon = "";
                $scope.DisplayOrder = "";
                $scope.Status = true;
                $scope.Test = "Active";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Menu";
            })
        }
    }
    $scope.GetAllMenu = function () {
        $http({
            method: "get",
            url: "https://localhost:44369/Account/GetAllMenu"
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
    $scope.DeleteMenu = function (menu) {
        $http({
            method: "post",
            url: "https://localhost:44369/Account/DeleteMenu",
            datatype: "json",
            data: JSON.stringify(menu)
        }).then(function (response) {
            toastrMsg(response.data, 'success')
            $scope.GetAllMenu();
        })
    };
    $scope.UpdateMenu = function (menu) {
        document.getElementById("MenuId_").value = menu.MenuId;
        $scope.MenuName = menu.MenuName;
        $scope.MenuIcon = menu.MenuIcon;
        $scope.DisplayOrder = menu.DisplayOrder;
        $scope.Status = menu.Status;
        document.getElementById("btnSave").setAttribute("value", "Update");
        //document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Menu";
    }
})

