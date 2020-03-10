namespace SIevlev.ClinicApp.Interfaces.Dtos
{
    public class ChangeBonusDto
    {
        public int PatientId { get; }
        
        public int NewBonusQuantity { get; }
        
        public int NewBonusPercent { get; }

        public ChangeBonusDto(int patientId, int newBonusQuantity, int newBonusPercent)
        {
            PatientId = patientId;
            NewBonusQuantity = newBonusQuantity;
            NewBonusPercent = newBonusPercent;
        }
    }
}