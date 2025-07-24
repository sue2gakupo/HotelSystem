using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSystem.Models
{
    public  class EmployeeRoleData  //partial class 用來將類別的定義分割成多個檔案，這樣可以讓程式碼更有組織性和可讀性
    {
        [Display(Name = "角色代碼")]
        [RegularExpression("[A-Z]", ErrorMessage = "角色代碼只能填A-Z")] //RegularExpression 用來驗證字串是否符合指定的正則表達式（Regular Expression）模式
        public string RoleCode { get; set; } = null!;

        [Display(Name = "角色")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "角色名稱最少要2個字")]
        public string RoleName { get; set; } = null!;
    }

    [ModelMetadataType(typeof(EmployeeRoleData))]  //寫在partial class 裡面的內容就會等於寫在 EmployeeRole 類別裡面，這樣就可以將 EmployeeRoleData 的屬性和驗證規則應用到 EmployeeRole 類別上
    public partial class EmployeeRole { }



}
