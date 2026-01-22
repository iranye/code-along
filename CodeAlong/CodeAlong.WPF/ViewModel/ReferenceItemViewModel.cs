namespace CodeAlong.WPF.ViewModel
{
    using CodeAlong.Domain.Data.Models;
    using WpfLibrary;

    public class ReferenceItemViewModel : ValidationViewModelBase
    {
        private readonly Reference model;

        public ReferenceItemViewModel(Reference reference)
        {
            this.model = reference;
        }

        public int Id
        {
            get => model.Id;
            set => model.Id = value;
        }

        public string? Title
        {
            get => model.Title;
            set
            {
                model.Title = value;
                RaisePropertyChanged();
                if (string.IsNullOrWhiteSpace(model.Title))
                {
                    AddError("Title is required");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string Description
        {
            get => model.Description;
            set
            {
                model.Description = value;
                RaisePropertyChanged();
            }
        }

        public bool IsPlaceholder()
        {
            return Title == "New";
        }

        public bool HasFilterString(string filter)
        {
            bool ret = false;
            if (Title != null && Title.ToLower().Contains(filter))
            {
                ret = true;
            }
            return ret;
        }
    }
}
