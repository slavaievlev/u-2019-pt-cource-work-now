using System.Collections.Generic;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.Dtos;
using SIevlev.ClinicApp.Interfaces.ViewModel;

namespace SIevlev.ClinicApp.Interfaces.Services
{
    public interface IPatientService
    {
        PatientViewModel CreatePatient(PatientBindingModel patientBindingModel);
        
        PatientViewModel GetPatient(int patientId);

        List<PatientViewModel> GetPatients();
        
        void ChangeBonus(ChangeBonusDto changeBonusDto);

        void BlockPatient(int patientId);

        void UnblockPatient(int patientId);

        void SendInvoicesToEmail(PatientInvoicesReportDto patientInvoicesReportDto);

        List<PatientInvoicesViewModel> GetAllInvoices(int patientId);
    }
}