#region using

using System;

#endregion

namespace PluralSight.Moq.Code.Demo08
{
    public class CustomerCreationException : Exception
    {
        public CustomerCreationException(Exception exception):base("error",exception)
        {
            
        }
    }
}