using CleanArchitecture.Application.OwnersLists.Queries.ExportOwners;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICsvFileBuilderOwner
{
    byte[] BuildOwnersFile(IEnumerable<OwnersRecord> records);
}
