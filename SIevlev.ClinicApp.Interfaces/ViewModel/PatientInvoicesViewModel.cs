using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIevlev.ClinicApp.Interfaces.ViewModel
{
    public class PatientInvoicesViewModel
    {
        public List<string> DoctorFios { get; set; }
        
        public int PatientId { get; set; }
        
        public DateTime CreateDate { get; set; }

        public DateTime? ImplementDate { get; set; }

        [Description("Исходная сумма оплаты")]
        public int Price { get; set; }

        [Description("Оплачено")]
        public int Paid { get; set; }

        public string OrderStatus { get; set; }

        public PatientInvoicesViewModel()
        {
        }

        public PatientInvoicesViewModel(
            int patientId, 
            DateTime date,
            DateTime? implementDate,
            int price,
            int paid,
            string orderStatus,
            string doctorFirstName,
            string doctorLastName, 
            List<string> doctorFios)
        {
            PatientId = patientId;
            CreateDate = date;
            ImplementDate = implementDate;
            Price = price;
            Paid = paid;
            OrderStatus = orderStatus;
            DoctorFios = doctorFios;
            DoctorFios = doctorFios;
        }
    }
}