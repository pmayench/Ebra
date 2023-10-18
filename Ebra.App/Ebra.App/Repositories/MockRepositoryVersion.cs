using Ebra.App.Exceptions;
using Ebra.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ebra.App.Repositories
{
    public class MockRepositoryVersion : IVersionEntityRepository
    {
        List<VersionEntity> table;
        public MockRepositoryVersion()
        {
            table = new List<VersionEntity>
            {
                new VersionEntity()
                {
                    id = 1,
                    version = "1.0",
                    type = typeof(Article)
                }
            };
        }

        public void Delete(int versionId)
        {
            table.Remove(GetById(versionId));
        }

        public IEnumerable<VersionEntity> GetAll()
        {
            return table;
        }

        public VersionEntity GetById(int versionId)
        {
            return table.Single(c => c.id == versionId);
        }

        public VersionEntity GetByType(Type type)
        {
            var result = table.FirstOrDefault(x => x.type == type);

            if (result != null) return result;

            throw new NotFoundVersionException();
        }

        public void Insert(VersionEntity version)
        {
            var item = table.FirstOrDefault(x => x.type == version.type);
            if(item == null) 
            {
                table.Add(version);
            }
            else
            {
                Update(version);
            }
        }

        public void Save()
        {

        }

        public void Update(VersionEntity version)
        {
            table.Remove(GetByType(version.type));
            table.Add(version);
        }
    }
}
