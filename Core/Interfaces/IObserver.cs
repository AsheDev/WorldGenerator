using Core.Utility;
using Core.Observer;

namespace Core.Interfaces
{
    public interface IObserver
    {
        void CreationInfo(TheAllObserver observer);
        void MilestoneInfo(TheAllObserver observer, HistoricalRecord record);
        void DestructionInfo(TheAllObserver observer);
    }
}
