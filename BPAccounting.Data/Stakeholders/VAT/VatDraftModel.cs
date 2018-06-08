using System.Collections.Generic;
using System.ComponentModel;

namespace BPAccounting.Data.Stakeholders
{
    public class VATDraftModel
    {
        [Description("Kwartaal")]
        public int VATQ { get; set; }

        [Description("Jaar")]
        public int VATYr { get; set; }

        [Description("Speciale regeling")]
        public List<double> R0 { get; set; } = new List<double>();

        [Description("VK 6 %")]
        public List<double> R1 { get; set; } = new List<double>();

        [Description("VK 12 %")]
        public List<double> R2 { get; set; } = new List<double>();

        [Description("VK 21 %")]
        public List<double> R3 { get; set; } = new List<double>();

        [Description("EU diensten")]
        public List<double> R44 { get; set; } = new List<double>();

        [Description("Medecontractant")]
        public List<double> R45 { get; set; } = new List<double>();

        [Description("EU leveringen")]
        public List<double> R46 { get; set; } = new List<double>();

        [Description("Uitvoer")]
        public List<double> R47 { get; set; } = new List<double>();

        [Description("Correctie 44/46")]
        public List<double> R48 { get; set; } = new List<double>();

        [Description("Correcties rest")]
        public List<double> R49 { get; set; } = new List<double>();

        [Description("AK handelsgoederen")]
        public List<double> R81 { get; set; } = new List<double>();

        [Description("AK diensten")]
        public List<double> R82 { get; set; } = new List<double>();

        [Description("AK investeringen")]
        public List<double> R83 { get; set; } = new List<double>();

        [Description("Correcties 86/88")]
        public List<double> R84 { get; set; } = new List<double>();

        [Description("Correcties rest")]
        public List<double> R85 { get; set; } = new List<double>();

        [Description("EU leveringen")]
        public List<double> R86 { get; set; } = new List<double>();

        [Description("Uitvoer")]
        public List<double> R87 { get; set; } = new List<double>();

        [Description("EU diensten")]
        public List<double> R88 { get; set; } = new List<double>();

        [Description("BTW 1/2/3")]
        public List<double> R54 { get; set; } = new List<double>();

        [Description("BTW 86/88")]
        public List<double> R55 { get; set; } = new List<double>();

        [Description("BTW 87")]
        public List<double> R56 { get; set; } = new List<double>();

        [Description("BTW invoer VVH")]
        public List<double> R57 { get; set; } = new List<double>();

        [Description("BTW regularisaties voor staat")]
        public List<double> R61 { get; set; } = new List<double>();

        [Description("BTW CN's")]
        public List<double> R63 { get; set; } = new List<double>();

        [Description("Ongebruikt")]
        public List<double> R65 { get; set; } = new List<double>();

        [Description("Totaal verschuldigd")]
        public List<double> RXX { get; set; } = new List<double>();

        [Description("Aftrekbare BTW")]
        public List<double> R59 { get; set; } = new List<double>();

        [Description("BTW regularisaties voor ond")]
        public List<double> R62 { get; set; } = new List<double>();

        [Description("BTW CN's")]
        public List<double> R64 { get; set; } = new List<double>();

        [Description("Ongebruikt")]
        public List<double> R66 { get; set; } = new List<double>();

        [Description("Totaal aftrekbaar")]
        public List<double> RYY { get; set; } = new List<double>();

        [Description("XX - YY")]
        public List<double> R71 { get; set; } = new List<double>();

        [Description("YY - XX")]
        public List<double> R72 { get; set; } = new List<double>();

        [Description("BTW december")]
        public List<double> R91 { get; set; } = new List<double>();
    }
}
