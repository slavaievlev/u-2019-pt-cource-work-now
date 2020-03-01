using System;
using System.ComponentModel;

namespace SIevlev.ClinicApp.Interfaces.ViewModel
{
    public class PatientInvoicesViewModel
    {
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

        public PatientInvoicesViewModel(int patientId, DateTime date, DateTime? implementDate, int price, int paid, string orderStatus)
        {
            PatientId = patientId;
            CreateDate = date;
            ImplementDate = implementDate;
            Price = price;
            Paid = paid;
            OrderStatus = orderStatus;
        }
    }
}