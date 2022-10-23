namespace CaseStudy.WebApi.HelperMethods
{
    public static class TokenGenerator
    {
        public static string Generate()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}
