using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Roster.App.ViewModels
{
    public partial class AddressViewModel: BaseViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; protected set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Name is Required")]
        private string _name;

        [ObservableProperty]
        private string? _unitNum;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Street Number is Required")]
        private string _streetNum;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Street Name is Required")]
        private string _streetName;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Street Type is Required")]
        private string _streetType;

        public int SuburbId { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Suburb is Required")]
        public SuburbViewModel _suburb;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "City is Required")]
        private string _city;

        public AddressViewModel() { }

        public AddressViewModel(string name, string? unitNum, string streetNum, string streetName, string streetType, SuburbViewModel suburb, string city)
        {
            Name = name;
            UnitNum = unitNum;
            StreetNum = streetNum;
            StreetName = streetName;
            StreetType = streetType;
            Suburb = suburb;
            City = "Adelaide";            
        }
    }
}
