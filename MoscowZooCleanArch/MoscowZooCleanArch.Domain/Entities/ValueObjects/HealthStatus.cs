using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Domain.Entities.ValueObjects
{
    /// <summary>
    /// Represents the health status of an animal in the zoo.
    /// </summary>

    public sealed record HealthStatus
    {
        public bool IsHealthy { get; }
        private HealthStatus(bool isHealthy)
        {
            IsHealthy = isHealthy;
        }

        public static readonly HealthStatus Healthy = new(true); // Predefined value of a healthy animal
        public static readonly HealthStatus Unhealthy = new(false); // Predefined value of an unhealthy animal   

        /// <summary>
        /// Implicitly converts a HealthStatus object to a boolean representation.
        /// </summary>
        /// <param name="healthStatus"></param>

        public static implicit operator bool(HealthStatus healthStatus) => healthStatus.IsHealthy;

        /// <summary>
        /// Implicitly converts a boolean to a HealthStatus object.
        /// </summary>
        /// <param name="isHealthy"></param>

        public static explicit operator HealthStatus(bool isHealthy) => isHealthy ? Healthy : Unhealthy;

        public override string ToString() => IsHealthy ? "Healthy" : "Unhealthy";
    }
}
