namespace UserCloneApp.Domain.Models.ConstantModels
{
    public class ValidationConstantModel : BaseConstantModel
    {
        public ValidationConstantModel(string code, string message) : base(code, message)
        {
        }

        public override string? ToString()
        {
            return $"{Code}<>{Message}";
        }
    }
}
