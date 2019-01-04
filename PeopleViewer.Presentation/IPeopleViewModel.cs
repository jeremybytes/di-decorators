using System.Collections.Generic;
using System.Threading.Tasks;
using Common;

namespace PeopleViewer.Presentation
{
    public interface IPeopleViewModel
    {
        IEnumerable<Person> People { get; set; }

        Task RefreshPeople();
        void ClearPeople();
    }
}