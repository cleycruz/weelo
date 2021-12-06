using System.Globalization;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.OwnersLists.Queries.ExportOwners;
using CleanArchitecture.Infrastructure.Files.Maps;
using CsvHelper;

namespace CleanArchitecture.Infrastructure.Files;

public class CsvFileBuilderOwner : ICsvFileBuilderOwner
{
    public byte[] BuildOwnersFile(IEnumerable<OwnersRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<OwnersRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
