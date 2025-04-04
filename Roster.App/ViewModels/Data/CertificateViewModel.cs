﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Roster.App.ViewModels
{
    public partial class CertificateViewModel: BaseViewModel
    {
        [ObservableProperty]
        private string _id;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Certificate is Required")]
        private string _name;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Certificate Expiry Length is Required")]
        private int _certLength;


        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Certificate Infinite Status is Required")]
        private bool _infinite;
        public CertificateViewModel() { }


        public CertificateViewModel(string id, string name, int certLength, bool infinite)
        {
            Id = id;
            Name = name;
            CertLength = certLength;
            Infinite = infinite;
        }
    }
}
