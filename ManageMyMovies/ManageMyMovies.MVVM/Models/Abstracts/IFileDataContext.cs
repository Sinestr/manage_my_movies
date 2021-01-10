using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.MVVM.Models.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFileDataContext : IDataContext
    {
        #region Properties

        /// <summary>
        ///     Obtient le chemin du fichier de données.
        /// </summary>
        string FilePath { get; }


        #endregion
    }
}
