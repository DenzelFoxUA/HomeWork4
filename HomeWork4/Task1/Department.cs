using System.Collections;
using System.Text;

namespace HomeWork4
{
    public class Department: IEnumerable<Employee>
    {
        private static int ID_INDEXER = 0;
        private List<Employee> _crew;

        public List<Employee> Crew { get => this._crew; }

        public Department()
        {
            _crew = new List<Employee>();
        }
        public void Add(string name, string lastName, decimal estimatedSalary)
        {
            
            _crew.Add(new(ID_INDEXER, name, lastName, estimatedSalary));
            ID_INDEXER++;
        }

        public bool RemoveById(int idValue)
        {
            bool isFound = false;

            try
            {
                var employee = _crew.ElementAt(idValue);
                isFound = _crew.Remove(employee);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                 MyPrinter.PrintExceptionsMessages(ex);
            }
            catch (Exception ex)
            {
                MyPrinter.PrintExceptionsMessages(ex);
            }

            return isFound;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _crew.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 1; i < _crew.Count; i++)
            {
                yield return _crew[i];
            }
        }

        public int Count() => _crew.Count;

       
    }
}
