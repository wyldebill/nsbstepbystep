using System;
using NServiceBus;

namespace Shared
{
    #region PlaceOrder

    public class PlaceOrder : ICommand
    {
        public Guid Id { get; set; }
    }

    #endregion
}