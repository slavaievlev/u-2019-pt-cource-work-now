using SIevlev.ClinicApp.Interfaces.BindingModel;

namespace SIevlev.ClinicApp.Interfaces.Services
{
    public interface IReportService
    {
        void GetPatientInvoices(PatientInvoicesBindingModel patientInvoices);

        void GetPaymentReport(PaymentReportBindingModel paymentReport);
    }
}