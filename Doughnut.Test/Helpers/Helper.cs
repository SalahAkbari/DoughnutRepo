using System.Collections.Generic;

namespace Doughnut.Test.Helpers
{
    public static class Helper
    {
        public static IEnumerable<object[]> GetUserChoiceTestData()
        {
            yield return new object[] { MockData.Current.Choices[0], "Maybe you want an apple." };
            yield return new object[] { MockData.Current.Choices[1], "Get it." };
            yield return new object[] { MockData.Current.Choices[2], "Do jumping jacks first." };
            yield return new object[] { MockData.Current.Choices[3], "What are you waiting for? Grab it now." };
            yield return new object[] { MockData.Current.Choices[4], "Wait 'til you find a sinful, unforgettable doughnut." };
        }
    }
}
