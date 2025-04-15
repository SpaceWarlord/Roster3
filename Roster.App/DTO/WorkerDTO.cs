using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.DTO
{
    public class WorkerDTO: BaseDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public AddressDTO? Address { get; set; }
        public string? HighlightColor { get; set; }                       

        public WorkerDTO(string id, string firstName, string middleName, string lastName, string nickname, string gender, string? dateOfBirth, string? phone, string? email, string? highlightColor, AddressDTO? address)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor;
            Address = address;            
        }       
        
        public WorkerDTO(Worker worker)
        {
            Id=worker.Id;
            FirstName = worker.FirstName;
            MiddleName = worker.MiddleName;
            LastName = worker.LastName;
            Nickname = worker.Nickname;
            Gender = worker.Gender;
            DateOfBirth = worker.DateOfBirth;
            Phone = worker.Phone;
            Email = worker.Email;
            HighlightColor = worker.HighlightColor;
            if (worker.Address!=null)
            {
                Address = new AddressDTO(worker.Address.Id, worker.Address.Name, worker.Address.UnitNum, worker.Address.StreetNum, worker.Address.StreetName, worker.Address.StreetType, "");
            }
            else
            {
                Address = null;
            }
            
        }
    }
}
