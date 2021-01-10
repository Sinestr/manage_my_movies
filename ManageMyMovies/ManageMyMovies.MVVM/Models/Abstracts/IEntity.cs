using ManageMyMovies.MVVM.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.MVVM.Models.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEntity : IObservableObject, IEditableObject
    {
        #region Properties

        /// <summary>
        ///     Obtient ou définit l'identifiant de l'élément.
        /// </summary>
        long Identifier { get; set; }

        #endregion
    }
}
