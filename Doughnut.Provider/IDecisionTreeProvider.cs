using Doughnut.Provider.ViewModels;

namespace Doughnut.Provider
{
    public interface IDecisionTreeProvider
    {
        string GetTheAnswer(ClientViewModel model);
    }
}
