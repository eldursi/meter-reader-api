using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace Meter.Api.UnitTests
{
    internal class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture()
                .Customize(new AutoNSubstituteCustomization()))
        {
        }
    }
}