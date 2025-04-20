using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ValueObjectTests
{
    public class HealthStatusTest
    {
        [Fact]
        public void HealthStatus_PredefinedValues_ShouldBeCorrect()
        {
            // Assert
            Assert.True(HealthStatus.Healthy.IsHealthy);
            Assert.False(HealthStatus.Unhealthy.IsHealthy);
        }
    }
}
