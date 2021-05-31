using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Idiom.ValueObject.Raw
{
    public enum Currency
    {
        RMB,
        Dollar,
        Euro
    }

    public struct Money
    {
        public decimal Amount;
        public Currency Currency;
    }
}
