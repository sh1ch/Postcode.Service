using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Postcode.Service.Data;
/// <summary>
/// <see cref="Ruby"/> クラスは、住所の読み仮名を表します。
/// </summary>
[DebuggerDisplay("{Address}")]
public class Ruby
{
    /// <summary>
    /// 都道府県のよみがなを取得または設定します。
    /// </summary>
    [JsonPropertyName("pref")]
    public string Prefecture { get; set; } = "";

    /// <summary>
    /// 市町村１のよみがなを取得または設定します。
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; set; } = "";

    /// <summary>
    /// 市町村２のよみがなを取得または設定します。
    /// </summary>
    [JsonPropertyName("town")]
    public string Town { get; set; } = "";

    /// <summary>
    /// 住所のよみがなを表すテキストを取得または設定します。
    /// <para>
    /// 基本的に <see cref="Prefecture"/> + <see cref="City"/> + <see cref="Town"/> をまとめたテキストです。
    /// </para>
    /// </summary>
    [JsonPropertyName("allAddress")]
    public string Address { get; set; } = "";
}
