using ManageMyMovies.Models;
using ManageMyMovies.MVVM.Models.Abstracts;
using ManageMyMovies.MVVM.ViewModels;
using ManageMyMovies.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.ViewModels
{
    public class ViewModelMyMovies : ViewModelList<UserMovieManagerContext, IDataContext>, IViewModelMyMovies
    {
        #region Fields

        #endregion

        #region Properties
        /// <summary>
        /// Obtient le titre du vue-modèle
        /// </summary>
        public string Title => "Ma Liste de Films";
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataContext"></param>
        public ViewModelMyMovies(IDataContext dataContext) : base(dataContext)
        {
            this.LoadData();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Méthode de chargement des données.
        /// </summary>
        public override void LoadData()
        {
            this.ItemsSource = new ObservableCollection<UserMovieManagerContext>();
        }

        #region DeleteCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        protected override void Delete(object parameter)
        {
            base.Delete(parameter);
        }
        #endregion

        #endregion
    }
}
