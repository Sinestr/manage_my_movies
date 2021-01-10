using ManageMyMovies.MVVM.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.MVVM.Models
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Entity : ObservableObject, IEntity
    {
        #region Fields

        /// <summary>
        ///     Identifiant de l'entité.
        /// </summary>
        private long _Identifier;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient ou définit l'identifiant de l'élément.
        /// </summary>
        public long Identifier { get => this._Identifier; set => this.SetProperty(nameof(this.Identifier), ref this._Identifier, value); }

        /// <summary>
        ///     Commence l'édition d'une entité.
        /// </summary>
        public abstract void BeginEdit();

        /// <summary>
        ///     Annule les modifications effectuées sur l'entité.
        /// </summary>
        public abstract void CancelEdit();

        /// <summary>
        ///     Valide les modifications effectuées sur l'entité.
        /// </summary>
        public abstract void EndEdit();

        #endregion
    }
}
