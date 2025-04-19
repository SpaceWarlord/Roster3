using Microsoft.EntityFrameworkCore;
using Roster.App.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.Main
{
    public class DummyData
    {
        private readonly RosterDBContext _db;
        public ObservableCollection<WorkerViewModel> Workers { get; set; }
        public ObservableCollection<ClientViewModel> Clients { get; set; }
        public ObservableCollection<ShiftViewModel> Shifts { get; set; }
        public ObservableCollection<AddressViewModel> Addresses { get; set; }
        public ObservableCollection<CertificateViewModel> Certificates { get; set; }
        public DummyData()
        {         
            _db = new RosterDBContext();
            Workers = new ObservableCollection<WorkerViewModel>();
            Clients = new ObservableCollection<ClientViewModel> { };
            Shifts = new ObservableCollection<ShiftViewModel>();
            Addresses = new ObservableCollection<AddressViewModel>();
            Certificates = new ObservableCollection<CertificateViewModel>();

            GenerateWorkers();
            GenerateClients();
            GenerateShifts();
            GenerateAddresses();
            GenerateCertificates();            
        }

        public void GenerateWorkers()
        {            
            _db.Database.ExecuteSqlRaw("DELETE FROM Worker");
            Workers.Add(new WorkerViewModel("1", "Fred", "R", "Smith", "Fredo", "M", null, "04919191", "fredo@gmail.com", null, null));
            Workers.Add(new WorkerViewModel("2", "John", "F", "Trump", "Trumpy", "M", null, "", "trump@whitehouse.com", null, null));
            Workers.Add(new WorkerViewModel("3", "Richard", "", "Hamilton", "Richie", "M", null, "04919191", "", null, null));
            Workers.Add(new WorkerViewModel("4", "Pamela", "", "Anderson", "Pam", "F", null, "90210", "baywatch@yahoo.com", null, null));
            Workers.Add(new WorkerViewModel("5", "Harry", "", "Windsor", "Harry", "M", null, "082922", "royalty@hotmail.com", null, null));
            Workers.Add(new WorkerViewModel("6", "Chuck", "", "Roberts", "Chucky", "M", null, "", "killerdoll@gmail.com", null, null));
            Workers.Add(new WorkerViewModel("7", "Clint", "", "Eastwood", "Fredo", "M", null, "09872122", "wildwest@gmail.com", null, null));
            Workers.Add(new WorkerViewModel("8", "Fritz", "R", "Gerver", "Gerbs", "M", null, "", "fritz@yahoo.com", null, null));
        }

        public void GenerateClients()
        {
            _db.Database.ExecuteSqlRaw("DELETE FROM Client");
        }

        public void GenerateShifts()
        {
            _db.Database.ExecuteSqlRaw("DELETE FROM Shift");
        }
        
        public void GenerateAddresses()
        {
            _db.Database.ExecuteSqlRaw("DELETE FROM Address");
        }

        public void GenerateCertificates()
        {
            _db.Database.ExecuteSqlRaw("DELETE FROM Certificate");
        }
    }
}
