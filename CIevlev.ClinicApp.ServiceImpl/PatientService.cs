using System.Collections.Generic;
using System.Linq;
using CIevlev.ClinicApp.ServiceImpl.Export.Docx;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.Dtos;
using SIevlev.ClinicApp.Interfaces.Repositories;
using SIevlev.ClinicApp.Interfaces.Services;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Models;

namespace CIevlev.ClinicApp.ServiceImpl
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMailService _mailService;

        public PatientService(IPatientRepository patientRepository, IMailService mailService)
        {
            _patientRepository = patientRepository;
            _mailService = mailService;
        }

        public PatientViewModel CreatePatient(PatientBindingModel patientBindingModel)
        {
            var model = new Patient
            {
                FirstName = patientBindingModel.FirstName,
                LastName = patientBindingModel.LastName,
                Login = patientBindingModel.Login,
                Bonus = 0,
                Password = patientBindingModel.Password,    // TODO шифровать!!!!!!!!!!!!!!!!
                PatientStatus = PatientStatus.Active,
                Phone = patientBindingModel.Phone
            };

            _patientRepository.CreatePatient(model);

            return new PatientViewModel
            {
                Id = model.Id,
                Login = model.Login,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Bonus = model.Bonus,
                PatientStatus = model.PatientStatus.ToString(),
                Phone = model.Phone
            };
        }

        public PatientViewModel GetPatient(int patientId)
        {
            var patient = _patientRepository.GetPatient(patientId);

            return new PatientViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Bonus = patient.Bonus,
                Login = patient.Login,
                PatientStatus = patient.PatientStatus.ToString(),
                Phone = patient.Phone
            };
        }

        public List<PatientViewModel> GetPatients()
        {
            var patients = _patientRepository.GetPatients();

            return patients.Select(patient => new PatientViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Bonus = patient.Bonus,
                Login = patient.Login,
                PatientStatus = patient.PatientStatus.ToString(),
                Phone = patient.Phone
            }).ToList();
        }

        public void ChangeBonus(int patientId, int newBonusQuantity)
        {
            var patient = _patientRepository.GetPatient(patientId);

            patient.Bonus = newBonusQuantity < 0 ? 0 : newBonusQuantity;
            
            _patientRepository.UpdatePatient(patient);
        }

        public void BlockPatient(int patientId)
        {
            var patient = _patientRepository.GetPatient(patientId);

            patient.PatientStatus = PatientStatus.Blocked;

            _patientRepository.UpdatePatient(patient);
        }
        
        public void UnblockPatient(int patientId)
        {
            var patient = _patientRepository.GetPatient(patientId);

            patient.PatientStatus = PatientStatus.Active;

            _patientRepository.UpdatePatient(patient);
        }
        
        public void SendInvoicesToEmail(PatientInvoicesReportDto patientInvoicesReportDto)
        {
            var title = $"Счета за период с {patientInvoicesReportDto.StartDate.Date} по {patientInvoicesReportDto.EndDate.Date}";
            const string message = "Привет! Вам пришел счет! Оплатите его, пожалуйста :)";
            
            var doc = new PatientInvoicesDocument();
            _mailService.SendFileToPatient(patientInvoicesReportDto.PatientId, title, message, doc.PathToFile);
        }

        public List<PatientInvoicesViewModel> GetAllInvoices(int patientId)
        {
            var patient = _patientRepository.GetPatient(patientId);
            return patient.Orders.Select(order => new PatientInvoicesViewModel()
            {
                CreateDate = order.CreateDate,
                ImplementDate = order.ImplementDate,
                OrderStatus = order.OrderStatus.ToString(),
                Paid = order.PayStores.Sum(story => story.Sum),
                PatientId = order.PatientId,
                Price = order.Price
            }).ToList();
        }
    }
}