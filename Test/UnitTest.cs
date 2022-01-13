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

    [TestCase(1001701, "“Œ‹“sÂƒ–“‡‘º")]
    [TestCase(0121100, "H“cŒ§—YŸŒS‰HŒã’¬")]
    public async Task —X•Ö”Ô†_To_ZŠ(int postcode, string address)
    {
        var result = await PostcodeClient.GetResourceAsync(ApiKey, postcode);

        Assert.IsTrue(result.IsEnabled);
        Assert.AreEqual(result.Address, address);
    }

    [TestCase(0)]
    public async Task —X•Ö”Ô†_—áŠO(int postcode)
    {
        var result = await PostcodeClient.GetResourceAsync(ApiKey, postcode);

        Assert.IsFalse(result.IsEnabled);
    }
}