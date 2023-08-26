using DockerInfnetDevOpsSample.Controllers;

namespace TestApi
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void DeveFazerGetComSucesso()
        {
            var controller = new WeatherForecastController();

            var result = controller.Get();

            Assert.True(result.Count() > 0);

        }
    }
}