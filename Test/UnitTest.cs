using NUnit.Framework;
using Postcode.Service;
using System.Threading.Tasks;

namespace Test;

public class Tests
{
    private string ApiKey { get; set; } = "";

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // var api = Environment.GetEnvironmentVariable("RESAS_API", EnvironmentVariableTarget.User);
        DotNetEnv.Env.Load(".env");
        var key = DotNetEnv.Env.GetString("POSTCODE_API");

        ApiKey = key;
    }

    [TestCase(1001701, "�����s������")]
    [TestCase(0121100, "�H�c���Y���S�H�㒬")]
    public async Task �X�֔ԍ�_To_�Z��(int postcode, string address)
    {
        var result = await PostcodeClient.GetResourceAsync(ApiKey, postcode);

        Assert.IsTrue(result.IsEnabled);
        Assert.AreEqual(result.Address, address);
    }

    [TestCase(0)]
    public async Task �X�֔ԍ�_��O(int postcode)
    {
        var result = await PostcodeClient.GetResourceAsync(ApiKey, postcode);

        Assert.IsFalse(result.IsEnabled);
    }
}