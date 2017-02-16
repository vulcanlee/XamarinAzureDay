using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFDoggy.ViewModels
{
    public class TravelExpensesListItemViewModel : BindableBase
    {

        #region ID
        private int id;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.SetProperty(ref this.id, value); }
        }
        #endregion

        #region Title
        private string title;
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.SetProperty(ref this.title, value); }
        }
        #endregion


        #region TravelDate
        private DateTime travelDate;
        /// <summary>
        /// TravelDate
        /// </summary>
        public DateTime TravelDate
        {
            get { return this.travelDate; }
            set { this.SetProperty(ref this.travelDate, value); }
        }
        #endregion

        public TravelExpensesListItemViewModel()
        {

        }
    }
}
