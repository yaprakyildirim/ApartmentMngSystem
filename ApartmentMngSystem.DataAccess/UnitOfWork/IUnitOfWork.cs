﻿namespace ApartmentMngSystem.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
        void Clear();
    }
}
