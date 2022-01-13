using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Postcode.Service.Data;
/// <summary>
/// <see cref="ApiResult"/> クラスは、郵便番号 API レスポンス データフォーマットを表現します。
/// </summary>
[DebuggerDisplay("{PostCode} = {Address}")]
public class ApiResult
{
    /// <summary>
    /// API の結果が正常かどうかを示す値を取得します。
    /// </summary>
    [JsonIgnore]
    public bool IsEnabled => !string.IsNullOrEmpty(PostCode) && PostCode.Length == 7;

    /// <summary>
    /// 都道府県コードを取得または設定します。
    /// </summary>
    [JsonPropertyName("prefCode")]
    public string PrefectureCode { get; set; } = "";

    /// <summary>
    /// 市町村コードを取得または設定します。
    /// </summary>
    [JsonPropertyName("cityCode")]
    public string CityCode { get; set; } = "";

    /// <summary>
    /// 郵便番号を取得または設定します。
    /// </summary>
    [JsonPropertyName("postcode")]
    public string PostCode { get; set; } = "";

    /// <summary>
    /// 旧郵便番号を取得または設定します。
    /// </summary>
    [JsonPropertyName("oldPostcode")]
    public string OldPostCode { get; set; } = "";

    /// <summary>
    /// 都道府県の名前を取得または設定します。
    /// </summary>
    [JsonPropertyName("pref")]
    public string Prefecture { get; set; } = "";

    /// <summary>
    /// 市町村１の名前を取得または設定します。
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; set; } = "";

    /// <summary>
    /// 市町村２の名前を取得または設定します。
    /// </summary>
    [JsonPropertyName("town")]
    public string Town { get; set; } = "";

    /// <summary>
    /// 住所を表すテキストを取得または設定します。
    /// <para>
    /// 基本的に <see cref="Prefecture"/> + <see cref="City"/> + <see cref="Town"/> をまとめたテキストです。
    /// </para>
    /// </summary>
    [JsonPropertyName("allAddress")]
    public string Address { get; set; } = "";

    /// <summary>
    /// ルビ（ひらがな）を表すテキストを取得または設定します。
    /// </summary>
    [JsonPropertyName("hiragana")]
    public Ruby Hiragana { get; set; } = new ();

    /// <summary>
    /// ルビ（ｶﾅ）を表すテキストを取得または設定します。
    /// </summary>
    [JsonPropertyName("halfWidthKana")]
    public Ruby KanaHalf { get; set; } = new ();

    /// <summary>
    /// ルビ（カタカナ）を表すテキストを取得または設定します。
    /// </summary>
    [JsonPropertyName("fullWidthKana")]
    public Ruby Katakana { get; set; } = new ();

    /// <summary>
    /// 一般郵便番号かどうかを示す値を取得または設定します。
    /// </summary>
    [JsonPropertyName("generalPostcode")]
    public bool IsGeneral { get; set; }

    /// <summary>
    /// 大口事業所個別番号かどうかを示す値を取得または設定します。
    /// </summary>
    [JsonPropertyName("officePostcode")]
    public bool IsOffice { get; set; }

    /// <summary>
    /// ロケーション 緯度/経度 を取得または設定します。
    /// </summary>
    [JsonPropertyName("location")]
    public Location Location { get; set; } = new ();
}
