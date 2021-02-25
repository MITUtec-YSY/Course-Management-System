using System;

namespace MRsystem.Exception
{
    public class CollectionsException : SystemException
    {
        private string message { get; set; }

        public CollectionsException(string Mess) { message = Mess; }

        public override string ToString() { return ToString(); }
    }
}
