var app = angular.module("myApp", []);
app.controller("ManageMenu", function ($scope, $http) {
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
    $scope.InsertMenu = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action === "Submit") {
            $scope.Menu = {};
            $scope.Menu.ParentId = $scope.MenuId;
            $scope.Menu.MenuName = $scope.MenuName;
            $scope.Menu.MenuIcon = $scope.MenuIcon;
            $scope.Menu.MenuLink = $scope.MenuLink;
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
                $scope.MenuLink = "";
                $scope.DisplayOrder = "";
                $scope.Status = true;
                $scope.Test = "Active";
            })
        } else {
            $scope.Menu = {};
            $scope.Menu.MenuId = document.getElementById("MenuId_").value;
            $scope.Menu.ParentId = $scope.MenuId;
            $scope.Menu.MenuName = $scope.MenuName;
            $scope.Menu.MenuIcon = $scope.MenuIcon;
            $scope.Menu.MenuLink = $scope.MenuLink;
            $scope.Menu.DisplayOrder = $scope.DisplayOrder;
            $scope.Menu.Status = $scope.Status;
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
                $scope.MenuLink = "";
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
        $scope.GetMenu();
        //testData();
        $http({
            method: "GET",
            url: "https://localhost:44369/Account/GetAllMenu"
        }).then(function (response) {
            $scope.Menus = response.data;
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
        document.getElementById("ParentMenuId_").value = menu.ParentId;
        document.getElementById("MenuId_").value = menu.MenuId;
        //$scope.MenuId = menu.ParentId; 
        $scope.MenuName = menu.MenuName;
        $scope.MenuIcon = menu.MenuIcon;
        $scope.MenuLink = menu.MenuLink;
        $scope.DisplayOrder = menu.DisplayOrder;
        $scope.Status = menu.Status;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("spn").innerHTML = "Update Menu";
    }
})
function SetDropDown(x) {
    //var scope = angular.element('#MenuId').scope();
    $("#MenuId").val("" + $('#ParentMenuId_').val() + "");
}
function testData() {    
    $.ajax({
        url: "https://localhost:44369/Account/GetAllMenu",
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            var result = data.data;
            var table = $('#tblMenu').DataTable();
            table
                .clear()
                .draw();
            var count = 1;
            $.each(result, function (key, item) {               
                table.row.add([
                    count,
                    item.ParentId,
                    item.MenuName,
                    item.MenuIcon,
                    item.MenuLink,
                    item.DisplayOrder,
                    item.Status,
                    ' <a href="javascript:void(0)" ng-click="UpdateMenu(menu)"><i class="far fa-edit fa-2x"></i></a><span style="font-size:xx-large"> | </span><a href="javascript:void(0)" ng-click="DeleteMenu(menu)"><i class="fas fa-trash fa-2x"></i></a>',
                   //'<a href="#" onclick="Edit(' + item.Id + ')"  style="cursor:pointer"><img src="/Image/icons_Edit-24.png" /></a> / <a onclick="Delete(' + item.Id + ')" style="cursor:pointer"><img src="/Image/icons_delete-20.png" /></a>',
                ]).draw(false);
                count++;
            })
        },
        error: function (xhr) {
            alert("error");
        }
    });
}
