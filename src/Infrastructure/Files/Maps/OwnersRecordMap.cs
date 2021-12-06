using System.Globalization;
using CleanArchitecture.Application.OwnersLists.Queries.ExportOwners;
using CsvHelper.Configuration;

namespace CleanArchitecture.Infrastructure.Files.Maps;

public class OwnersRecordMap : ClassMap<OwnersRecord>
{
    public OwnersRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
