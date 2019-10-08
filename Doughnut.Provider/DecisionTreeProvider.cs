using Doughnut.Provider.Utilities;
using Doughnut.Provider.ViewModels;

namespace Doughnut.Provider
{
    public class DecisionTreeProvider : IDecisionTreeProvider
    {
        public string GetTheAnswer(ClientViewModel model)
        {
            return MakeDecisionTree(model).Evaluate();
        }

        private DecisionTreeQuery MakeDecisionTree(ClientViewModel model)
        {
            var queryAreYouSure
    = new DecisionTreeQuery("Are you sure?",
                            new DecisionTreeResult("Get it."),
                            new DecisionTreeResult("Do jumping jacks first."),
                            model.Answers[2]);
            var queryIsItAGoodDoughnut
              = new DecisionTreeQuery("Is it a good doughnut?",
                                      new DecisionTreeResult("What are you waiting for? Grab it now."),
                                      new DecisionTreeResult("Wait 'til you find a sinful, unforgettable doughnut."),
                                      model.Answers[2]);
            var queryDoIDeserveIt
              = new DecisionTreeQuery("Do I deserve it?",
                                      queryAreYouSure,
                                      queryIsItAGoodDoughnut,
                                      model.Answers[1]);
            var queryDoYouWantABook
              = new DecisionTreeQuery("DO I WANT A DOUGHNUT?",
                                      queryDoIDeserveIt,
                                      new DecisionTreeResult("Maybe you want an apple."),
                                      model.Answers[0]);
            return queryDoYouWantABook;
        }
    }

    
    

}
