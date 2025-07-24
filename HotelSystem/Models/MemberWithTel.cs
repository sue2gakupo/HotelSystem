using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSystem.Models
{ 
    public class MemberWithTel  //複製Member.cs && MemberTel欄位
    {
       
        public string MemberID { get; set; } = null!;

        
        public string Name { get; set; } = null!;

       
        public string City { get; set; } = null!;

        
        public string Address { get; set; } = null!;

       
        public DateTime Birthday { get; set; }

        public string Tel { get; set; } = null!;  //等於viewmodel的概念，為了呈現某一個view才會去製作這個model
    }
}
