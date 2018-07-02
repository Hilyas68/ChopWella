using Chopwella.Core;
using System.Collections.Generic;

namespace Chopwella.Infrastructure
{
    public class DummyData
    {
        public static Category category1 = new Category { Name = "Senior Staff" };
        public static Category category2 = new Category { Name = "Contract Staff" };
        public static Category category3 = new Category { Name = "Junior Staff" };
        public static Category category4 = new Category { Name = "CyberAcademy Staff" };
        public static Category category5 = new Category { Name = "IT / NYSC Staff" };

        public static Vendor vendor1 = new Vendor { Name = "vendor A" };
        public static Vendor vendor2 = new Vendor { Name = "vendor B" };

        public static Staff staff1 = new Staff { Name = "Osezuah Winifred", StaffNum = "INT/01", Category = category4, Email = "winifred@gmail.com" };
        public static Staff staff2 = new Staff { Name = "Mabi Chukwuma", StaffNum = "INT/02", Category = category4, Email = "mabichukwua@gmail.com" };
        public static Staff staff3 = new Staff { Name = "Oriahi Emmanuel", StaffNum = "INT/03", Category = category4, Email = "oriahie@gmail.com" };
        public static Staff staff4 = new Staff { Name = "Aremu Omolola", StaffNum = "INT/04", Category = category4, Email = "aremuomolola@gmail.com" };
        public static Staff staff5 = new Staff { Name = "Ochiaka Okechukwu", StaffNum = "INT/05", Category = category4, Email = "okey@gmail.com" };
        public static Staff staff6 = new Staff { Name = "Otega Samul", StaffNum = "SNR/01", Category = category1, Email = "otega@gmail.com" };
        public static Staff staff7 = new Staff { Name = "Isreal DashDash", StaffNum = "SNR/03", Category = category1, Email = "isreal@gmail.com" };
        public static Staff staff8 = new Staff { Name = "Olowoniwa Samuel", StaffNum = "CNT/05", Category = category2, Email = "olowo@gmail.com" };
        public static Staff staff9 = new Staff { Name = "Emmanuel Emamanuel", StaffNum = "JNR/05", Category = category3, Email = "okey@gmail.com" };
        public static Staff staff10 = new Staff { Name = "Adeleye Samuel", StaffNum = "SNR/02", Category = category1, Email = "okey@gmail.com" };

        public static Visitor visitor1 = new Visitor { Name = "Lasisi Elenu", Staff = staff1 };
        public static Visitor visitor2 = new Visitor { Name = "Mark Angel", Staff = staff3 };

        public static CheckIn check1 = new CheckIn { Staff = staff1, IsChecked = true, Vendor = vendor1 };
        public static CheckIn check2 = new CheckIn { Staff = staff2, IsChecked = true, Vendor = vendor1 };
        public static CheckIn check3 = new CheckIn { Staff = staff3, IsChecked = true, Vendor = vendor2 };
        public static CheckIn check4 = new CheckIn { Staff = staff5, IsChecked = true, Vendor = vendor2 };
        public static CheckIn check5 = new CheckIn { Staff = staff8, IsChecked = true, Vendor = vendor2 };

        /*Dummy Data for Roles*/

        public static Role Admin = new Role { Name = "Vendor", Id = 1 };

        public static Role FoodVendor = new Role { Name = "Vendor", Id = 2 };


        public static IEnumerable<Category> GetCategories() => new List<Category> { category1, category2, category3, category4, category5 };

        public static IEnumerable<Vendor> GetVendors() => new List<Vendor> { vendor1, vendor2 };

        public static IEnumerable<Staff> GetStaff() => new List<Staff> { staff1, staff2, staff3, staff4, staff5, staff6, staff7, staff8, staff9, staff10 };
        public static IEnumerable<Visitor> GetVisitors() => new List<Visitor> { visitor1, visitor2 };
        public static IEnumerable<CheckIn> GetCheckIns() => new List<CheckIn> { check1, check2, check3, check4, check5 };

        public IEnumerable<Role> GetRoles = new List<Role> { FoodVendor, Admin };
    }
}
