using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaList
{
    internal class Phone
    {
        public string TypeNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Phone Next { get; set; }
        public Phone(string typeNumber, string phoneNumber)
        {
            TypeNumber = typeNumber;
            PhoneNumber = phoneNumber;
            Next = null;
        }
        public override string ToString()
        {
            return TypeNumber + ": " + PhoneNumber;
        }
    }
}
