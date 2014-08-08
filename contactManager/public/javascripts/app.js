angular.module('contactmanager',['filters','ngRoute'])
	.config(function($routeProvider){
		$routeProvider.when('/',{
			controller:'ListController',
			templateUrl:'list.html'
		}).when('/contacts',{
			controller:'ListController',
			templateUrl:'list.html'
		}).when('/contacts/:id',{
			controller:'ViewController',
			templateUrl: 'contact.html'
		}).when('/add', {
			controller: 'AddController',
			templateUrl: 'add.html'
		}).when('/update/:id', {
			controller: 'EditController',
			templateUrl: 'edit.html'
		}).when('/delete/:id', {
			controller:'DeleteController',
			templateUrl:'delete.html'
		}).otherwise({redirectTo:'/'});
	});

function DeleteController($scope, $http, $location, $routeParams){
	$scope.form = {};
	$http({
		method:'jsonp',
		url:'http://localhost:3000/contacts/' + $routeParams.id + '?callback=JSON_CALLBACK'
	}).success(function(data, status, headers, config){
		$scope.form.name = data.name;
		$scope.form.phone = data.phone;
		$scope.contact = data;
	}).error(function(data, status, headers, config){
		console.log('error loading data for delete view ' + status)
	});

	$scope.deleteContact = function(){
		$http.delete('/contacts/' + $routeParams.id, $scope.form)
		.success(function(data){
		$location.path('/');
		}).error(function(data, status, headers, config){
			console.log('error loading deleting contact ' + status);
		
	});

}
}

function EditController($scope, $http, $location, $routeParams){
	$scope.form = {};
	//request contact based on ID
	$http({
		method:'jsonp',
		url:'http://localhost:3000/contacts/' + $routeParams.id + '?callback=JSON_CALLBACK'
	}).success(function(data, status, headers, config){
		$scope.form.name = data.name;
		$scope.form.phone = data.phone;
		$scope.contact = data;
	}).error(function(data, status, headers, config){
		console.log('error retrieving contact ' + status)
	});
	
	$scope.editContact = function(){
		$http.put('/contacts/'+$routeParams.id, $scope.form)
			.success(function(data){
				$location.path('/');
			}).error(function(data, status, headers, config){
				console.log('error updating contact ' + status);
		});
}
}
function AddController($scope, $http, $location){
	$scope.form = {};
	$scope.addContact = function(){
		$http.post('/contacts',$scope.form).success(function(data){
			$location.path('/');
		}).error(function(data, status, headers, config){
			console.log('error inserting contact ' + status);
		});
	};
}

function ListController($scope,$http){
	$scope.headers=['name','phone'];

	$scope.sort = {
		column:'name',
		descending:false
	};

	$scope.changeSortOrder = function(column){
		var sort = $scope.sort;
		if(sort.column == column){
			sort.descending = !sort.descending;
		}else{
			sort.column = column;
			sort.descending = false;
		}
	};

	$http({method:'jsonp',url:'http://localhost:3000/contacts?callback=JSON_CALLBACK'}).success(function(data,status,headers,config){
			$scope.contacts = data;
		}).error(function(data,status,headers,config){
			console.log('error getting data');
		});
}

function ViewController($scope, $http, $routeParams){
	$http({
		method:'jsonp',
		url:'http://localhost:3000/contacts/' + $routeParams.id + '?callback=JSON_CALLBACK'
	}).success(function(data,status,headers,config){
		$scope.contact = data;
	}).error(function(data,status,headers,config){
		console.log('error loading contact' + status);
	});
}

angular.module("filters",[]).filter('capitalise',function(){
	return function(input){
		if(input != null){
			//capitalise first letter using javascript substring method
			return input.substring(0,1).toUpperCase() + input.substring(1);
		}
	}
});