using Postcode.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Postcode.Service;

/// <summary>
/// <see cref="PostcodeClient"/> クラスは、Postcode API 用のクライアント接続を提供します。
/// </summary>
public class PostcodeClient
{
    private const string _BaseUrl = "https://apis.postcode-jp.com/";

    /// <summary>
    /// 郵便番号 API 要求を非同期操作として送信します。
    /// </summary>
    /// <param name="postcode">郵便番号 (７桁整数値)。</param>
    /// <returns>郵便番号 API レスポンス データフォーマット。取得に失敗した場合、空のデータを返却します。</returns>
    public static async Task<ApiResult> GetResourceAsync(string postcode) => await GetResourceAsync(PostcodeEngine.ApiKey, postcode);

    /// <summary>
    /// 郵便番号 API 要求を非同期操作として送信します。
    /// </summary>
    /// <param name="key">API キー。</param>
    /// <param name="postcode">郵便番号 (７桁整数値)。</param>
    /// <returns>郵便番号 API レスポンス データフォーマット。取得に失敗した場合、空のデータを返却します。</returns>
    /// <exception cref="ArgumentException">無効な郵便番号であったときに発生する例外です。</exception>
    public static async Task<ApiResult> GetResourceAsync(string key, string postcode)
    {
        string postcodeUri = "api/v5/postcodes/";
        string url = _BaseUrl + postcodeUri + postcode; // ７桁
        string response = await GetHttpResponse(key, url);

        ApiResult[]? result = null;

        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException($"Postcode is empty or null.");
        }

        if (response != null)
        {
            var options = new JsonSerializerOptions();

            result = JsonSerializer.Deserialize<ApiResult[]>(response, options);
        }

        return (result?.Count() ?? 0) == 1 ? result?[0] ?? new () : new ();
    }

    private static async Task<string> GetHttpResponse(string key, string url)
    {
        using (var client = new HttpClient())
        {
            // client.DefaultRequestHeaders.Add("-G", $"-v \\");
            client.DefaultRequestHeaders.Add("-d", $"apiKey={key}");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response1 = await client.GetAsync(url);
            var response2 = await response1.Content.ReadAsStringAsync();

            return response2;
        }
    }
}
