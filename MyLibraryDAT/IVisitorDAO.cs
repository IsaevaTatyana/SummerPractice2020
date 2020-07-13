using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace PracticeMyLibraryDAT
{
    public interface IVisitorDAO
    {
        IEnumerable<Visitor> GetVisitors();

        void AddVisitor(Visitor visitor);

        void RemoveVisitor(int VisitorID);
    }
}
