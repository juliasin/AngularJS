// Defining angularjs module
var app = angular.module('demoModule', []);

function Set($scope, $http, BooksService) {
    $scope.booksData = null;
    BooksService.GetAllRecords().then(function (d) {
        $scope.booksData = d.data; // Success
    }, function () {
        alert('Error Occured !!!'); // Failed
    });

    $scope.Book = {
        ID: '',
        Name: '',
        Author: '',
        Year: '',
        PublishingOffice: '',
        Genre:''
    };

    // Reset books details
    $scope.clear = function () {
        $scope.Book.ID = '';
        $scope.Book.Name = '';
        $scope.Book.Author = '';
        $scope.Book.Year = '';
        $scope.Book.PublishingOffice = '';
        $scope.Book.Genre = ''
    }

    //Add New Item
    $scope.save = function () {
        if ($scope.Book.Name != "" &&
       $scope.Book.Author != "" && $scope.Book.Year != "" && $scope.Book.PublishingOffice != "") {

            $http({
                method: 'POST',
                url: 'api/Books/PostBook/',
                data: $scope.Book
            }).then(function successCallback(response) {
                $scope.booksData.push(response.data);
                $scope.clear();
                alert("Book Added Successfully !!!");
                window.location.reload()
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };

    // Edit book details
    $scope.edit = function (data) {
        $scope.Book = { ID: data.ID, Name: data.Name, Author: data.Author, Year: data.Year, PublishingOffice: data.PublishingOffice, Genre:data.Genre };
    }

    // Cancel book details
    $scope.cancel = function () {
        $scope.clear();
    }

    // Update book details
    $scope.update = function () {
        if ($scope.Book.Name != "" &&
       $scope.Book.Author != "" && $scope.Book.Year != "" && $scope.Book.PublishingOffice != "") {
            $http({
                method: 'PUT',
                url: 'api/Books/PutBook/' + $scope.Book.ID,
                data: $scope.Book
            }).then(function successCallback(response) {
                $scope.booksData = response.data;
                $scope.clear();
                alert("Book Updated Successfully !!!");
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };

    // Delete product details
    $scope.delete = function (index) {
        $http({
            method: 'DELETE',
            url: 'api/Books/DeleteBook/' + $scope.booksData[index].ID,
        }).then(function successCallback(response) {
            $scope.booksData.splice(index, 1);
            alert("Book Deleted Successfully !!!");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };


}


app.controller('DemoCtrl', function ($scope, $http, BooksService) {
    Set($scope, $http, BooksService)

});
app.controller('NovelCtrl', function ($scope, $http, BooksService1) {
    Set($scope, $http, BooksService1)

});
app.controller('ScFictCtrl', function ($scope, $http, BooksService2) {
    Set($scope, $http, BooksService2)
   
});

app.controller('PhiFictCtrl', function ($scope, $http, BooksService3) {
    Set($scope, $http, BooksService3)

});

  
app.factory('BooksService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('api/Books/GetAllBooks');
    }
    return fac;
});
    app.factory('BooksService1', function ($http) {
        var fac = {};
        fac.GetAllRecords = function () {
            return $http.get('api/Books/GetBooksNovel');
        }
        return fac;
    });
    app.factory('BooksService2', function ($http) {
        var fac = {};
        fac.GetAllRecords = function () {
            return $http.get('api/Books/GetBooksScFict');
        }
        return fac;
    });
    app.factory('BooksService3', function ($http) {
        var fac = {};
        fac.GetAllRecords = function () {
            return $http.get('api/Books/GetBooksPhiFict');
        }
        return fac;
    });