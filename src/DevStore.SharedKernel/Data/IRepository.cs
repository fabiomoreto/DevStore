using System;
using DevStore.SharedKernel.Domain;

namespace DevStore.SharedKernel.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}