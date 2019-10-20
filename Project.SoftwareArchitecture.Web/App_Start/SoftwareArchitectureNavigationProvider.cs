using Abp.Application.Navigation;
using Abp.Localization;
using Project.SoftwareArchitecture.Authorization;

namespace Project.SoftwareArchitecture.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class SoftwareArchitectureNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", SoftwareArchitectureConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "#tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Administrators
                        )
                ).AddItem(
                new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "#tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Administrators
                        )
                 )
                //Menu Tiep nhan
                .AddItem(new MenuItemDefinition(
                        "DangKyKham",
                        L("DangKyKham"),
                       // url: "#dangkykham",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_TiepBenhNhans
                    ).AddItem(new MenuItemDefinition(
                        "QLBenhNhan",
                        L("QLBenhNhan"),
                       // url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_TiepBenhNhans
                    ).AddItem(new MenuItemDefinition(
                        "QLPhieuDangKy",
                        L("QLPhieuDangKy"),
                        //url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_TiepBenhNhans
                    ).AddItem(new MenuItemDefinition(
                        "QLPhieuSuDungDichVu",
                        L("QLPhieuSuDungDichVu"),
                       // url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_TiepBenhNhans
                    ))))
                )
                ///Menu Thu Ngan
                .AddItem(new MenuItemDefinition(
                        "NopPhi",
                        L("NopPhi"),
                      //  url: "#dangkykham",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Cashiers
                    ).AddItem(new MenuItemDefinition(
                        "QLBienLai",
                        L("QLBienLai"),
                        //url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_Cashiers
                    ))
                )
                //Menu Bac Si
                .AddItem(new MenuItemDefinition(
                        "KhamBenh",
                        L("KhamBenh"),
                       // url: "#dangkykham",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Doctors
                    ).AddItem(new MenuItemDefinition(
                        "QLPhieuSuDungDichVu",
                        L("QLPhieuSuDungDichVu"),
                        // url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_Doctors
                    ).AddItem(new MenuItemDefinition(
                        "QLPhieuKhamBenh",
                        L("QLPhieuKhamBenh"),
                        //url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_Doctors
                    ).AddItem(new MenuItemDefinition(
                        "QLBenhNhan",
                        L("QLBenhNhan"),
                        //url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_Doctors
                    )))
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Roles",
                        L("Roles"),
                        url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_Administrators
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", SoftwareArchitectureConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                ));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SoftwareArchitectureConsts.LocalizationSourceName);
        }
    }
}
