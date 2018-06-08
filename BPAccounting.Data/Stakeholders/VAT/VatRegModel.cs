using System.ComponentModel;

namespace BPAccounting.Data.Stakeholders
{
    public class VATRegModel
    {
        [Description("Kwartaal")]
        public int VATQ { get; set; }

        [Description("Jaar")]
        public int VATYr { get; set; }

        [Description("Speciale regeling")]
        public double R0 { get; set; }

        [Description("VK 6 %")]
        public double R1 { get; set; }

        [Description("VK 12 %")]
        public double R2 { get; set; }

        [Description("VK 21 %")]
        public double R3 { get; set; }

        [Description("VK EU diensten")]
        public double R44 { get; set; }

        [Description("Medecontractant")]
        public double R45 { get; set; }

        [Description("VK EU leveringen")]
        public double R46 { get; set; }

        [Description("Uitvoer")]
        public double R47 { get; set; }

        [Description("Correctie 44/46")]
        public double R48 { get; set; }

        [Description("Correcties rest")]
        public double R49 { get; set; }

        [Description("AK handelsgoederen")]
        public double R81 { get; set; }

        [Description("AK diensten")]
        public double R82 { get; set; }

        [Description("AK investeringen")]
        public double R83 { get; set; }

        [Description("Correcties 86/88")]
        public double R84 { get; set; }

        [Description("Correcties rest")]
        public double R85 { get; set; }

        [Description("AK EU leveringen")]
        public double R86 { get; set; }

        [Description("Invoer")]
        public double R87 { get; set; }

        [Description("AK EU diensten")]
        public double R88 { get; set; }

        [Description("BTW 1/2/3")]
        public double R54 { get; set; }

        [Description("BTW 86/88")]
        public double R55 { get; set; }

        [Description("BTW 87")]
        public double R56 { get; set; }

        [Description("BTW invoer VVH")]
        public double R57 { get; set; }

        [Description("BTW regularisaties voor staat")]
        public double R61 { get; set; }

        [Description("BTW CN's")]
        public double R63 { get; set; }

        [Description("Ongebruikt")]
        public double R65 { get; set; }

        [Description("Totaal verschuldigd")]
        public double RXX { get; set; }

        [Description("Aftrekbare BTW")]
        public double R59 { get; set; }

        [Description("BTW regularisaties voor ond")]
        public double R62 { get; set; }

        [Description("BTW CN's")]
        public double R64 { get; set; }

        [Description("Ongebruikt")]
        public double R66 { get; set; }

        [Description("Totaal aftrekbaar")]
        public double RYY { get; set; }

        [Description("XX - YY")]
        public double R71 { get; set; }

        [Description("YY - XX")]
        public double R72 { get; set; }

        [Description("BTW december")]
        public double R91 { get; set; }
    }
}
