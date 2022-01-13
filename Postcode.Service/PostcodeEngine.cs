using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postcode.Service;
/// <summary>
/// <see cref="PostcodeEngine"/> クラスは、Postcode を利用するための基本システムを管理します。
/// </summary>
public class PostcodeEngine
{
    /// <summary>
    /// Postcode を利用するための API キーを取得または設定します。
    /// </summary>
    public static string ApiKey { get; set; } = "";
}
