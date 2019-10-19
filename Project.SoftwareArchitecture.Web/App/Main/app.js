(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');
            $qProvider.errorOnUnhandledRejections(false);

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in SoftwareArchitectureNavigationProvider
                    })
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in SoftwareArchitectureNavigationProvider
                    })
                    .state('roles', {
                        url: '/roles',
                        templateUrl: '/App/Main/views/roles/index.cshtml',
                        menu: 'Roles' //Matches to name of 'Tenants' menu in SoftwareArchitectureNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            //if (abp.auth.hasPermission('Pages.Roles')) {
            //    $stateProvider
            //        .state('roles', {
            //            url: '/roles',
            //            templateUrl: '/App/Main/views/roles/index.cshtml',
            //            menu: 'Roles' //Matches to name of 'Tenants' menu in SoftwareArchitectureNavigationProvider
            //        });
            //    $urlRouterProvider.otherwise('/roles');
            //}
            if (abp.auth.hasPermission('Pages.TiepBenhNhans')) {
                $stateProvider
                    .state('ql-benh-nhan', {
                        url: '/ql-benh-nhan',
                        templateUrl: '/App/Main/views/Test.cshtml',
                        menu: 'Users' //Matches to name of 'Tenants' menu in SoftwareArchitectureNavigationProvider
                    })
                    .state('ql-phieu-dang-ky', {
                        url: '/ql-phieu-dang-ky',
                        templateUrl: '/App/Main/views/Test.cshtml',
                        menu: 'Roles' //Matches to name of 'Tenants' menu in SoftwareArchitectureNavigationProvider
                    })
                    .state('ql-phieu-su-dung-dich-vu', {
                        url: '/ql-phieu-su-dung-dich-vu',
                        templateUrl: '/App/Main/views/Test.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in SoftwareArchitectureNavigationProvider
                    });
                $urlRouterProvider.otherwise('/about');
            }

            //if (abp.auth.hasPermission('Pages.Tenants')) {
            //    $stateProvider
            //        .state('tenants', {
            //            url: '/tenants',
            //            templateUrl: '/App/Main/views/tenants/index.cshtml',
            //            menu: 'Tenants' //Matches to name of 'Tenants' menu in SoftwareArchitectureNavigationProvider
            //        });
            //    $urlRouterProvider.otherwise('/tenants');
            //}

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in SoftwareArchitectureNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in SoftwareArchitectureNavigationProvider
                });
        }
    ]);

})();