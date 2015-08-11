using System;
using Core.Enums;
using Core.Mythology;
using Core.Interfaces;

namespace Generate
{
    public class DeityGen
    {
        private Random Random { get; set; }
        private NameGen Names { get; set; }

        public DeityGen()
        {
            Random = new Random(Guid.NewGuid().GetHashCode());
            Names = new NameGen();
        }

        /// <summary>
        /// Generate a single deity.
        /// </summary>
        /// <param name="ChiefDiety">The chief deity of the pantheon. Will accept a null value if no chief deity exists.</param>
        /// <param name="prominence">The promince of the deity. Is it a primary, major, or minor deity? Primary will set the ChiefDeity value to null.</param>
        /// <returns>Returns an IDeity object</returns>
        public IDeity Generate(IDeity ChiefDiety, CoreEnums.Deity prominence)
        {
            IDeity deity = new Deity
            {
                Id = Random.Next(0, 78000000), // I need to ensure this is unique (at least until the database is up and running...
                Name = RandomNameGen(),
                Description = "DESCRIPTION",
                ChiefDiety = (prominence == CoreEnums.Deity.Primary) ? null : ChiefDiety,
                Prominence = prominence,
                Alignment = (CoreEnums.Alignment)Random.Next(0, 8)
            };
            AnnounceCreation(deity);

            return deity;
        }

        private string RandomNameGen()
        {
            switch (Random.Next(0, 4))
            {
                case 0:
                    return Names.SingleName(CoreEnums.Word.DeityNames);
                case 1:
                    // randomize these two choices?
                    return Names.FirstAndLastName(CoreEnums.Word.DeityNames, CoreEnums.Word.ElfFemale);
                case 2:
                    return Names.SingleNameWithAdjective(CoreEnums.Word.DeityNames);
                default:
                    // randomize these two choices?
                    return Names.FirstAndLastNameWithAdjective(CoreEnums.Word.DeityNames, CoreEnums.Word.ElfFemale);
            }
        }

        private void AnnounceCreation(IDeity deity)
        {
            string announcement = "";
            // TODO: I can mix and match some of these - stirred, woken, risen with firmament, slumber, nothingness etc...
            switch (Random.Next(0, 12))
            {
                case 0:
                    announcement = "\n" + deity.Name + " has stirred from the firmament.";
                    break;
                case 1:
                    announcement = "\n" + deity.Name + " has woken from the deepest slumber.";
                    break;
                case 2:
                    announcement = "\n" + deity.Name + " rises from the firmament.";
                    break;
                case 3:
                    announcement = "\n" + deity.Name + " has risen from the nothing of time.";
                    break;
                default:
                    announcement = "\n" + deity.Name + " breathes anew from the empty realm.";
                    break;
            }

            Console.WriteLine(announcement);
        }
    }
}
