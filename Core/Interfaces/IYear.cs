using Core.Enums;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IYear : IBase
    {
        int Count { get; set; }
        CoreEnums.Epochs Epoch { get; set; }
        List<IMonth> Months { get; set; }
    }
}
