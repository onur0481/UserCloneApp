namespace UserCloneApp.Application.ViewModels
{
    public class BaseViewModel
    {
        public string ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public BaseViewModel(string id, DateTime createdDate)
        {
            ID = id;
            CreatedDate = createdDate;
        }
    }
}
