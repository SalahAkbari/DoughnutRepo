using Doughnut.Provider.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Doughnut.Test
{
    public class MockData
    {
        public static MockData Current { get; } = new MockData();
        public List<ClientViewModel> Choices { get; set; }

        public MockData()
        {
            Choices = new List<ClientViewModel>
            {
                new ClientViewModel { Answers = new[] { false, false, false } },
                new ClientViewModel { Answers = new[] { true, true, true } },
                new ClientViewModel { Answers = new[] { true, true, false } },
                new ClientViewModel { Answers = new[] { true, false, true } },
                new ClientViewModel { Answers = new[] { true, false, false } }
            };
        }
    }
}
