using CommandLine;

namespace PlanificatorCMD.Verbs
{
    [Verb("add_presentation", HelpText = "adding a new presentation")]
    public class AddPresentationVerb : IAddPresentationVerb
    {
        [Option('t', "title", Required = true, HelpText = "Inserting Title")]
        public string Title { get; set; }

        [Option('s', "short", Required = true, HelpText = "Inserting short description")]
        public string ShortDescription { get; set; }

        [Option('l', "long", Required = true, HelpText = "Inserting long description")]
        public string LongDescription { get; set; }

        [Option('T', "tags", Required = true, HelpText = "Introducting the string of tags")]
        public string Tags { get; set; }

        [Option('o', "presentation Owner", Required = true, HelpText = "Introducting ID of Presentation Owner")]
        public int PresentationOwnerSpeakerId { get; set; }
    }
}