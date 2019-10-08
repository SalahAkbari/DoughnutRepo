namespace Doughnut.Provider.Utilities
{
    public class DecisionTreeResult : DecisionTreeCondition
    {
        public override string Evaluate()
        {
            return Sentence;
        }

        public DecisionTreeResult(string sentence) : base(sentence)
        {
        }
    }
}
