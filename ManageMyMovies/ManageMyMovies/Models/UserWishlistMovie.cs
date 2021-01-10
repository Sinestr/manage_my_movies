using ManageMyMovies.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.Models
{
    /// <summary>
    /// 
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class UserWishlistMovie : Entity
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private struct UserWishlistMovieData
        {
            /// <summary>
            /// 
            /// </summary>
            public string _WishlistTitle { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public ObservableCollection<UserMovie> _UserMovies { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        UserWishlistMovieData? _BackupUserWishlistMovieData;

        /// <summary>
        /// 
        /// </summary>
        UserWishlistMovieData _CurrentUserWishlistMovieData;

        #endregion

        #region Properties
        /// <summary>
        /// Obtient ou définit la couverture du film
        /// </summary>
        public string WishlistTitle
        {
            get => this._CurrentUserWishlistMovieData._WishlistTitle;
            set => this.SetProperty(nameof(this.WishlistTitle), () => this._CurrentUserWishlistMovieData._WishlistTitle, (v) => this._CurrentUserWishlistMovieData._WishlistTitle = v, value);
        }

        /// <summary>
        /// Obtient ou définit la couverture du film
        /// </summary>
        [JsonIgnore]
        public ObservableCollection<UserMovie> UserMovies
        {
            get => this._CurrentUserWishlistMovieData._UserMovies;
            set => this.SetProperty(nameof(this.UserMovies), () => this._CurrentUserWishlistMovieData._UserMovies, (v) => this._CurrentUserWishlistMovieData._UserMovies = v, value);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public UserWishlistMovie()
        {
            this.UserMovies = new ObservableCollection<UserMovie>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public override void BeginEdit()
        {
            if (this._BackupUserWishlistMovieData == null)
            {
                this._BackupUserWishlistMovieData = this._CurrentUserWishlistMovieData;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CancelEdit()
        {
            if (this._BackupUserWishlistMovieData != null)
            {
                this._CurrentUserWishlistMovieData = this._BackupUserWishlistMovieData.Value;
                this.OnPropertyChanged("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void EndEdit()
        {
            if (this._BackupUserWishlistMovieData != null)
            {
                this._BackupUserWishlistMovieData = null;
            }
        }
        #endregion
    }
}
