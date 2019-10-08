namespace Doughnut.Provider.Utilities
{
    public class DecisionTreeQuery : DecisionTreeCondition
    {
        public DecisionTreeCondition Positive { get; set; }
        public DecisionTreeCondition Negative { get; set; }
        public override string Evaluate()
        {
            return Answer ? Positive.Evaluate() : Negative.Evaluate();
        }

        public DecisionTreeQuery(string sentence,
                           DecisionTreeCondition positive,
                           DecisionTreeCondition negative,
                           bool userAnswer)
    : base(sentence)
        {
            Positive = positive;
            Negative = negative;
            Answer = userAnswer;
        }
    }
}
