using Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PeopleViewer.Presentation
{
    public class PeopleReaderViewModel : INotifyPropertyChanged, IPeopleViewModel
    {
        protected IPersonReader Repository;

        private IEnumerable<Person> _people;
        public IEnumerable<Person> People
        {
            get { return _people; }
            set
            {
                if (_people == value)
                    return;
                _people = value;
                RaisePropertyChanged("People");
            }
        }

        public PeopleReaderViewModel(IPersonReader repository)
        {
            Repository = repository;
        }

        public async Task RefreshPeople()
        {
            People = await Repository.GetPeople();
        }

        public void ClearPeople()
        {
            People = new List<Person>();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
