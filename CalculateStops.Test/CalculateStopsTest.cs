using CalculateStops.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculateStops.Test
{
    [TestClass]
    public class CalculateStopsTest
    {
        [TestMethod]
        public void Test_CalculateStops()
        {
            //Arrange
            GridResultDTO expectedGrid = new GridResultDTO();
            ResultDTO expectedResult = new ResultDTO
            {
                Name = "Y-wing",
                Value = 74
            };
            expectedGrid.ResultDTO = new System.Collections.Generic.List<ResultDTO>
            {
                expectedResult
            };
            string input = "1000000";

            //Act
            GridResultDTO actualGrid = new StopsCalculator().CalculateStops(input);
            ResultDTO actualResult = new ResultDTO();

            foreach (var item in actualGrid.ResultDTO)
            {
                if (item.Name == "Y-wing")
                {
                    actualResult = item;
                    break;
                }
            }

            //Assert
            bool result = expectedResult.Equals(actualResult);            
        }
    }
}
