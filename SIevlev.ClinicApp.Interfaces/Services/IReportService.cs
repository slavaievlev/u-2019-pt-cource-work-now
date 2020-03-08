using SIevlev.ClinicApp.Interfaces.BindingModel;

namespace SIevlev.ClinicApp.Interfaces.Services
{
    public interface IReportService
    {
        byte[] GetPatientInvoicesAsByteArray(PatientInvoicesBindingModel patientInvoicesBindingModel);

        string GetPatientInvoicesAsPhysicalPath(PatientInvoicesBindingModel patientInvoicesBindingModel);

        byte[] GetPaymentReport(PaymentReportBindingModel paymentReport);
    }
}