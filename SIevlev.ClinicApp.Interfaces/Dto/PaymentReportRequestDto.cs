using System;

namespace SIevlev.ClinicApp.Interfaces.Dto
{
    public class PaymentReportRequestDto
    {
        public DateTime StartAt { get; set; }
        
        public DateTime EndAt { get; set; }
    }
}