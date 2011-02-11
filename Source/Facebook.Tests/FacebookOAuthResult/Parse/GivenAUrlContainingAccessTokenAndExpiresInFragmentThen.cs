namespace Facebook.Tests.FacebookOAuthResult.Parse
{
    using Facebook;
    using Xunit;

    public class GivenAUrlContainingAccessTokenAndExpiresInFragmentThen
    {
        [Fact]
        public void TheResultIsSuccessful()
        {
            var url = "http://www.facebook.com/connect/login_success.html#access_token=123|654aaaee068db-100001327642026|sd&expires_in=0";

            var result = FacebookOAuthResult.Parse(url);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void TheAccessTokenOfResultIsEqualToTheValuePassedInTheAccessTokenQuerystring()
        {
            var url = "http://www.facebook.com/connect/login_success.html#access_token=123|654aaaee068db-100001327642026|sd&expires_in=0";

            var result = FacebookOAuthResult.Parse(url);

            Assert.Equal("123|654aaaee068db-100001327642026|sd", result.AccessToken);
        }

        [Fact]
        public void TheExpiresInOfResultIsEqualToTheValuePassedInTheExpiresInQuerystring()
        {
            var url = "http://www.facebook.com/connect/login_success.html#access_token=123|654aaaee068db-100001327642026|sd&expires_in=0";

            var result = FacebookOAuthResult.Parse(url);

            var expiresIn = FacebookUtils.ToUnixTime(result.Expires);
            Assert.Equal(0, expiresIn);
        }

        [Fact]
        public void ErrorReasonTextIsNull()
        {
            var url = "http://www.facebook.com/connect/login_success.html#access_token=123|654aaaee068db-100001327642026|sd&expires_in=0";

            var result = FacebookOAuthResult.Parse(url);

            Assert.Null(result.ErrorReason);
        }
    }
}