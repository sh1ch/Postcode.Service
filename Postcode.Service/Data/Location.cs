using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Postcode.Service.Data;
/// <summary>
/// <see cref="Location"/> クラスは、ロケーション緯度/経度を表現します。
/// </summary>
[DebuggerDisplay("Latitude = {Latitude}, longitude = {Longitude}")]
public class Location
{
    /// <summary>
    /// 緯度を表す値を取得または設定します。
    /// </summary>
    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }
    /// <summary>
    /// 経度を表す値を取得または設定します。
    /// </summary>
    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }
}
