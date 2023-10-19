﻿using Ebra.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebra.App.Services.Interfaces
{
    public interface IOrderService
    {
        //obtener pedido
        Task<List<Order>> GetOrdersAsync();

        //obtener pedidos
        Task<string> GetVersionAsync();
    }

}