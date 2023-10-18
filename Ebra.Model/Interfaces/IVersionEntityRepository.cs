using Ebra.Models.Models;
using System;
using System.Collections.Generic;

namespace Ebra.Models.Interfaces
{
    public interface IVersionEntityRepository
    {
        IEnumerable<VersionEntity> GetAll();
        VersionEntity GetByType(Type type);
        VersionEntity GetById(int versionId);
        void Insert(VersionEntity version);
        void Update(VersionEntity version);
        void Delete(int versionId);
        void Save();
    }
}
