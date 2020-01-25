using SIevlev.ClinicApp.Interfaces.Dto;

namespace SIevlev.ClinicApp.Interfaces.Services
{
    public interface IReportService
    {
        void GetPatientInvoices(PatientInvoicesRequestDto patientInvoices);

        void GetPaymentReport(PaymentReportRequestDto paymentReport);
    }
}