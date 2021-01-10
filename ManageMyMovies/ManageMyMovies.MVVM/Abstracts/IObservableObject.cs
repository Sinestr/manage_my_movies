using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyMovies.MVVM.Abstracts
{
    /// <summary>
    /// Interface qui fournit un mécanisme de prévention de changement de valeur des propriétés.
    /// </summary>
    public interface IObservableObject : INotifyPropertyChanged, INotifyPropertyChanging
    {

    }
}
