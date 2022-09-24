using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreReactAdmin.Controllers
{
    /// <summary>
    /// React Admin の バックエンド用インターフェースです。
    /// </summary>
    /// <typeparam name="T">対象となるモデルの型</typeparam>
    /// <remarks>
    /// <para>https://marmelab.com/react-admin/Tutorial.html#connecting-to-a-real-api</para>
    /// </remarks>
    public interface IReactAdminController<T>
    {
        /// <summary>
        /// 対象となるモデルのリストを取得します。
        /// </summary>
        /// <param name="filter">検索条件, JSONオブジェクト形式 例) {"Name":"Taro"}</param>
        /// <param name="range">取得範囲条件 (ページング), JSON配列形式 例) [0,9]</param>
        /// <param name="sort">ソート条件, JSON配列形式 例) ["id","ASC"]</param>
        /// <returns>モデルのリスト</returns>
        /// <remarks>
        /// <para>Get list に相当します。</para>
        /// </remarks>
        Task<ActionResult<IEnumerable<T>>> Get(string filter = "", string range = "", string sort = "");

        /// <summary>
        /// 対象となるモデルの単一要素を取得します。
        /// </summary>
        /// <param name="id">Id値</param>
        /// <returns>モデル</returns>
        /// <remarks>
        /// <para>Get one record に相当します。</para>
        /// </remarks>
        Task<ActionResult<T>> Get(int id);

        /// <summary>
        /// 対象となるモデルを更新します。
        /// </summary>
        /// <param name="id">Id値</param>
        /// <param name="entity">モデル</param>
        /// <returns>モデル</returns>
        /// <remarks>
        /// <para>Update a record に相当します。</para>
        /// </remarks>
        Task<IActionResult> Put(int id, T entity);

        /// <summary>
        /// 対象となるモデルを登録します。
        /// </summary>
        /// <param name="entity">モデル</param>
        /// <returns>モデル</returns>
        /// <remarks>
        /// <para>Create a record に相当します。</para>
        /// </remarks>
        Task<ActionResult<T>> Post(T entity);

        /// <summary>
        /// 対象となるモデルを削除します。
        /// </summary>
        /// <param name="id">Id値</param>
        /// <returns>モデル</returns>
        /// <remarks>
        /// <para>Delete a record に相当します。</para>
        /// </remarks>
        Task<ActionResult<T>> Delete(int id);
    }
}
