var app = angular.module("myApp", []);
app.controller("ManageSubMenu", function ($scope, $http) {
    $scope.Status = true;
    $scope.Test = "Active";
    $scope.GetMenu = function () {
        $http({
            method: "get",
            url: "https://localhost:44369/Account/GetAllMenu"
        }).then(function (response) {
            $scope.MenuList = response.data;
        }, function () {
            toastrMsg("Error Occur", 'error')
        })
    };
    $scope.GetStatus = function () {
        $scope.Status = $scope.Status;
        if ($scope.Status) {
            $scope.Test = "Active";
        }
        else {
            $scope.Test = "InActive";
        }
    }
    $scope.InsertSubMenu = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action === "Submit") {
            $scope.SubMenu = {};
            $scope.SubMenu.MenuId = $scope.MenuId;
            $scope.SubMenu.SubMenuName = $scope.SubMenuName;
            $scope.SubMenu.SubMenuIcon = $scope.SubMenuIcon;
            $scope.SubMenu.DisplayOrder = $scope.DisplayOrder;
            $scope.SubMenu.Status = $scope.Status;
            $http({
                method: "post",
                url: "https://localhost:44369/Account/InsertSubMenu",
                datatype: "json",
                data: JSON.stringify($scope.SubMenu)
            }).then(function (response) {
                toastrMsg(response.data, 'success')
                $scope.GetAllSubMenu();
                $scope.SubMenuName = "";
                $scope.SubMenuIcon = "";
                $scope.DisplayOrder = "";
                $scope.Status = true;
                $scope.Test = "Active";
            })
        } else {
            $scope.SubMenu = {};
            $scope.SubMenu.MenuId = $scope.MenuId;
            $scope.SubMenu.SubMenuName = $scope.SubMenuName;
            $scope.SubMenu.SubMenuIcon = $scope.SubMenuIcon;
            $scope.SubMenu.DisplayOrder = $scope.DisplayOrder;
            $scope.SubMenu.Status = $scope.Status;
            $scope.SubMenu.SubMenuId = document.getElementById("SubMenuId_").value;
            $http({
                method: "post",
                url: "https://localhost:44369/Account/UpdateSubMenu",
                datatype: "json",
                data: JSON.stringify($scope.SubMenu)
            }).then(function (response) {
                toastrMsg(response.data, 'success')
                $scope.GetAllSubMenu();
                $scope.SubMenuName = "";
                $scope.SubMenuIcon = "";
                $scope.DisplayOrder = "";
                $scope.Status = true;
                $scope.Test = "Active";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New SubMenu";
            })
        }
    }
    $scope.GetAllSubMenu = function () {
        $scope.GetMenu();
        $http({
            method: "get",
            url: "https://localhost:44369/Account/GetAllSubMenu"
        }).then(function (response) {
            $scope.subMenus = response.data;
        }, function () {
            toastrMsg("Error Occur", 'error')
        })
    };
    $scope.DeleteSubMenu = function (submenu) {
        $http({
            method: "post",
            url: "https://localhost:44369/Account/DeleteSubMenu",
            datatype: "json",
            data: JSON.stringify(submenu)
        }).then(function (response) {
            toastrMsg(response.data, 'success')
            $scope.GetAllSubMenu();
        })
    };
    $scope.UpdateSubMenu = function (menu) {
        document.getElementById("SubMenuId_").value = menu.SubMenuId;
        $scope.MenuId = $scope.MenuList[menu.MenuId];
        $scope.SubMenuName = menu.SubMenuName;
        $scope.SubMenuIcon = menu.SubMenuIcon;
        $scope.DisplayOrder = menu.DisplayOrder;
        $scope.Status = menu.Status;
        document.getElementById("btnSave").setAttribute("value", "Update");
        //document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update SubMenu";
    }
})

