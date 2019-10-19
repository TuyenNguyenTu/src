(function () {
    var controllerId = 'app.views.layout.sidebarNav';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'appSession',
        function ($rootScope, $state, appSession) {
            var vm = this;

            vm.menuItems = [
                createMenuItem(App.localize("HomePage"), "", "home", "home"),

                //createMenuItem(App.localize("Tenants"), "Pages.Administrators", "business", "tenants"),
                createMenuItem(App.localize("Tenants"), "Pages.Administrators", "business", "tenants"),
                createMenuItem(App.localize("Users"), "Pages.Administrators", "people", "users"),
                createMenuItem(App.localize("Roles"), "Pages.Administrators", "local_offer", "roles"),
                createMenuItem(App.localize("About"), "", "info", "about"),

                ///Menu Tiep Nhan
                createMenuItem(App.localize("DangKyKham"), "Pages.TiepBenhNhans", "menu", "", [
                    createMenuItem(App.localize("QLBenhNhan"), "Pages.TiepBenhNhans", "local_offer", "ql-benh-nhan"),
                    createMenuItem(App.localize("QLPhieuDangKy"), "Pages.TiepBenhNhans", "local_offer", "ql-phieu-dang-ky"),
                    createMenuItem(App.localize("QLPhieuSuDungDichVu"), "Pages.TiepBenhNhans", "local_offer", "ql-phieu-su-dung-dich-vu")
                ]),
                //Menu Thu Ngan
                createMenuItem(App.localize("Nộp phí"), "Pages.Cashiers", "menu", "", [
                    createMenuItem(App.localize("QLBienLai"), "Pages.Cashiers", "local_offer", "ql-bien-lai")
                ]),
                //Menu bac Si
                createMenuItem(App.localize("Khám Bệnh"), "Pages.Doctors", "menu", "", [
                    createMenuItem(App.localize("QLPhieuKhamBenh"), "Pages.Doctors", "local_offer", "ql-phieu-kham-benh"),
                    createMenuItem(App.localize("QLPhieuSuDungDichVu"), "Pages.Doctors", "local_offer", "ql-phieu-su-dung-dich-vu")
                ]),

                createMenuItem(App.localize("MultiLevelMenu"), "", "menu", "", [
                    createMenuItem("ASP.NET Boilerplate", "", "", "", [
                        createMenuItem("Home", "", "", "https://aspnetboilerplate.com/?ref=abptmpl"),
                        createMenuItem("Templates", "", "", "https://aspnetboilerplate.com/Templates?ref=abptmpl"),
                        createMenuItem("Samples", "", "", "https://aspnetboilerplate.com/Samples?ref=abptmpl"),
                        createMenuItem("Documents", "", "", "https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl")
                    ]),
                    createMenuItem("ASP.NET Zero", "", "", "", [
                        createMenuItem("Home", "", "", "https://aspnetzero.com?ref=abptmpl"),
                        createMenuItem("Description", "", "", "https://aspnetzero.com/?ref=abptmpl#description"),
                        createMenuItem("Features", "", "", "https://aspnetzero.com/?ref=abptmpl#features"),
                        createMenuItem("Pricing", "", "", "https://aspnetzero.com/?ref=abptmpl#pricing"),
                        createMenuItem("Faq", "", "", "https://aspnetzero.com/Faq?ref=abptmpl"),
                        createMenuItem("Documents", "", "", "https://aspnetzero.com/Documents?ref=abptmpl")
                    ])
                ])
            ];

            vm.showMenuItem = function (menuItem) {
                if (menuItem.permissionName) {
                    return abp.auth.isGranted(menuItem.permissionName);
                }

                return true;
            }

            function createMenuItem(name, permissionName, icon, route, childItems) {
                return {
                    name: name,
                    permissionName: permissionName,
                    icon: icon,
                    route: route,
                    items: childItems
                };
            }
        }
    ]);
})();