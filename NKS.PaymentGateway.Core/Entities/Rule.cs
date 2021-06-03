namespace NKS.Payments.Core.Entities
{
    public class Rule
    {
        public Rule(string ruleDescription)
        {
            RuleDescription = ruleDescription;
        }

        public string RuleDescription { get; }
    }
}
