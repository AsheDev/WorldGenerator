using System;
using Core.Utility;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Observer
{
    public class TheAllObserver : IBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ObjectDetails> RegisteredEntities { get; set; }

        public TheAllObserver()
        {
            this.Id = 0;
            this.Name = "The All Observer";
            this.Description = "The All Observer watches and records the history and tapestried fates of the world.";
            RegisteredEntities = new List<ObjectDetails>();
        }

        // when something is created it needs to call this so as to register with the AllObserver
        public void RegisterCreation(ObjectDetails entity)
        {
            RegisteredEntities.Add(entity);
            WriteMessage("{0} have arisen from the tincture of time.", entity.Name);
        }

        // when a milestone is generated it needs to call this so as to register that fact with the AllObserver
        public void RegisterMilestone(HistoricalRecord record)
        {
            // DO SOMETHING
            WriteMessage(record.Information);
        }

        // when something is destroyed it needs to call this so as to register with the AllObserver
        public void RegisterDestruction(ObjectDetails entity)
        {
            RegisteredEntities.Remove(entity);
            Console.WriteLine();
            WriteMessage("{0} have fallen out of favour and entered the nothing.", entity.Name);
        }

        private void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void WriteMessage(string message, string parameter)
        {
            Console.WriteLine(message, parameter);
        }
    }
}
