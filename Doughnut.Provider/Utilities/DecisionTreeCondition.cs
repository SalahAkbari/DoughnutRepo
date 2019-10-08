namespace Doughnut.Provider.Utilities
{
    public abstract class DecisionTreeCondition
    {
        protected string Sentence { get; private set; }
        public bool Answer { get; set; }
        abstract public string Evaluate();

        public DecisionTreeCondition(string sentence)
        {
            Sentence = sentence;
        }
    }
}
