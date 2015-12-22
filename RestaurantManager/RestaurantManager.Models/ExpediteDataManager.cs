using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {

        private List<Order> _OrderItems;

        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
        }

        public List<Order> OrderItems
        {
            get { return this._OrderItems ; }
            set
            {
                if (value != this._OrderItems)
                {
                    this._OrderItems = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
