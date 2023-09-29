using AutoMapper;

namespace Ebra.Server.API.Mappings
{
    public class EbraAutoMapperConfiguration : MapperConfiguration
    {
        public EbraAutoMapperConfiguration(MapperConfigurationExpression configurationExpression) : base(configurationExpression)
        {
            configurationExpression.AddProfile<ArticleAutoMapper>();

#if DEBUG
            try
            {
                AssertConfigurationIsValid();
            }
            catch (Exception)
            {
                throw;
            }
#endif
        }
    }
}
