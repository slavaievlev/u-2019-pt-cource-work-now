namespace SIevlev.ClinicApp.Interfaces.Dtos
{
    public class ChangeBonusDto
    {
        public int NewBonusQuantity { get; }

        public ChangeBonusDto(int newBonusQuantity)
        {
            NewBonusQuantity = newBonusQuantity;
        }
    }
}