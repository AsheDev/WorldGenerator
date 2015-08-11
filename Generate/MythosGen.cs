using System;
using Core.Enums;
using System.Linq;
using Core.Utility;
using Core.Mythology;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Generate
{
    public class MythosGen
    {
        private Random Random { get; set; }
        private NameGen Names { get; set; }

        public MythosGen()
        {
            Random = new Random(Guid.NewGuid().GetHashCode());
            Names = new NameGen();
        }

        public IMythology GenerateSingle()
        {
            DeityGen deityGenerator = new DeityGen();
            IMythology mythos = new Mythology();
            mythos.Id = Random.Next(0, 78000000);
            mythos.Name = Names.SingleName(CoreEnums.Word.ElfPlace);
            mythos.Description = "DESCRIPTION";
            mythos.Deities = new List<IDeity> { deityGenerator.Generate(null, CoreEnums.Deity.Primary) };
            if (mythos.MythosType != CoreEnums.MythologicalType.Monotheistic)
            {
                // add multiple major deities
                int numberOfMajorDeities = Random.Next(2, 7);
                for (int n = 0; n < numberOfMajorDeities - 1; n++)
                {
                    mythos.Deities.Add(deityGenerator.Generate(mythos.Deities.First(), CoreEnums.Deity.Major));
                }

                // add multiple minor deities for each major deity
                for (int n = 0; n < mythos.Deities.Where(d => d.Prominence == CoreEnums.Deity.Major).ToList().Count - 1; n++)
                {
                    int numberOfMinorDeities = Random.Next(1, 4);
                    for (int x = 0; x < numberOfMinorDeities; x++)
                    {
                        mythos.Deities.Add(deityGenerator.Generate(mythos.Deities.Where(d => d.Prominence == CoreEnums.Deity.Major).ToList()[n], CoreEnums.Deity.Minor));
                    }
                }
            }
            return mythos;
        }

        // TODO: this should generate singles or doubles?..
        // TODO: I don't think the random name is working quite well enough...
        public List<IMythology> GenerateMultiple()
        {
            CancellationTokenSource cts = new CancellationTokenSource(); // do I really need this?
            //Task<List<IPerson>> populationTask = new Task<List<IPerson>>(() => populace.GenerateMultiple(civilizations.First(), populationCount, personInfo), cts.Token);
            //populationTask.Start();

            List<IMythology> mythologies = new List<IMythology>();
            int numberOfMyths = Random.Next(1, 6);
            for (int n = 0; n < numberOfMyths; n++)
            {
                Task<IMythology> myth = new Task<IMythology>(() => GenerateSingle(), cts.Token);
                myth.Start();

                mythologies.Add(myth.Result);
            }
            return mythologies;
        }

        private void AnnounceCreation()
        {

        }
    }
}
