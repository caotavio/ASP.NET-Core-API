using System;
using System.Collections.Generic;
using OtavioStore.Domain.StoreContext.Entities;
using OtavioStore.Domain.StoreContext.Queries;

namespace OtavioStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);

        IEnumerable<ListCustomerQueryResult> Get();

        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);
    }
}