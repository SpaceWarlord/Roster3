using CommunityToolkit.Mvvm.ComponentModel;
using Roster.App.DTO;
using Roster.App.Services;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Display;

namespace Roster.App.ViewModels.Data
{
    public partial class WorkerViewModel : PersonViewModel
    {


        //protected override Person _model => throw new NotImplementedException();

#nullable enable

        /*
        [ObservableProperty]
        private List<CertificateViewModel>? _certificates = new List<CertificateViewModel>();
        */

        /*
        public WorkerViewModel() : base(string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }
        */
        //bool hasManualHandlingCert = true;

        //public WorkerViewModel(string id, string firstName, string middleName, string lastName, string nickname, string gender, string dateOfBirth, string phone, string email, Color highlightColor, List<CertificateViewModel>? certificates)

        public WorkerViewModel() //Needed for SyncFusion
        {

        }

        public WorkerViewModel(string id, string firstName, string middleName, string lastName, string nickname, string gender, string dateOfBirth, string phone, string email, string? highlightColor, AddressViewModel? address)
            : base(id, firstName, middleName, lastName, nickname, gender, dateOfBirth, phone, email, highlightColor, address)
        {
            //Certificates = certificates;            
        }

        public override T ToDTO<T>()
        {
            AddressDTO aDTO = null;
            if (Address == null)
            {
                Debug.WriteLine("Address is null");
            }
            else
            {
                aDTO = Address.ToDTO<AddressDTO>();
            }
            Debug.WriteLine("worker id is " + Id);
            
            return (T)Convert.ChangeType(new WorkerDTO(Id, FirstName, MiddleName, LastName, Nickname, Gender, DateOfBirth, Phone, Email, HighlightColor, aDTO), typeof(T));
        }

        public override T ToModel<T>()
        {
            AddressDTO aDTO = null;
            if (Address == null)
            {
                Debug.WriteLine("Address is null");
            }
            else
            {
                aDTO = Address.ToDTO<AddressDTO>();
            }
            Debug.WriteLine("worker id is " + Id);
            Worker w = new Worker()
            {
                Id = Id,
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Nickname = Nickname,
                Gender = Gender,
                DateOfBirth = DateOfBirth,
                Phone = Phone,
                Email = Email,
                HighlightColor = HighlightColor,
                Address = null,
            };
            return (T)Convert.ChangeType(w, typeof(T));
        }

        
        public static Worker ModelFromDTO(WorkerDTO dto)
        {
            Worker worker = new Worker()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                Nickname = dto.Nickname,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                Phone = dto.Phone,
                Email = dto.Email,
                HighlightColor = dto.HighlightColor,
                Address = null,
            };
            return worker;
        }

        public async Task AddUpdate(WorkerService workerService)
        {
            Debug.WriteLine("Called Save Async. Name: " + FirstName);
            IsModified = false;
            if (IsNew)
            {
                Debug.WriteLine("its new");
                IsNew = false;
                await workerService.AddUpdate(ToDTO<WorkerDTO>());
            }
        }

        public static WorkerViewModel Create(WorkerDTO w)
        {
            return new WorkerViewModel(w.Id, w.FirstName, w.MiddleName, w.LastName, w.Nickname,
                        w.Gender, w.DateOfBirth, w.Phone, w.Email, w.HighlightColor, AddressViewModel.Create(w.Address));
        }

        /*
        public override string ToString()
        {
            //return "Id: " + Id + " First Name: " + FirstName + " Middle Name: " + MiddleName + " Last Name: " + LastName + " Nickname: " + Nickname + " Gender: " + Gender + 
        }*/
    }
}