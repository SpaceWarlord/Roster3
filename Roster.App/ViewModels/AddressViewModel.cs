using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Roster.App.DTO;
using System.Reflection;
using Windows.Networking;

namespace Roster.App.ViewModels
{
    public partial class AddressViewModel: DataViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; protected set; }

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
        public string _suburb;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "City is Required")]
        private string _city;

        public AddressViewModel() { }

        public AddressViewModel(string name, string? unitNum, string streetNum, string streetName, string streetType, string suburb, string city)
        {
            Name = name;
            UnitNum = unitNum;
            StreetNum = streetNum;
            StreetName = streetName;
            StreetType = streetType;
            Suburb = suburb;
            City = "Adelaide";            
        }

        public override T ToDTO<T>()
        {
            //return new AddressDTO(Id, Name, UnitNum, StreetNum, StreetName, StreetType, Suburb);
            return (T)Convert.ChangeType(new AddressDTO(Id, Name, UnitNum, StreetNum, StreetName, StreetType, Suburb), typeof(T));
        }
    }
}
